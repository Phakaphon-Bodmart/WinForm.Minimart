using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Minimart
{
    public partial class FrmPOS : Form
    {
        public FrmPOS()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlTransaction tr;

        private void FrmPOS_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();
            ListViewFormat();
            ClearProductData();
        }

        private void ListViewFormat() // สำหรับจัดรูปแบบ ListView
        {
            IsvProducts.Columns.Add("รหัสสินค้า", 100, HorizontalAlignment.Left);
            IsvProducts.Columns.Add("สินค้า", 150, HorizontalAlignment.Left);
            IsvProducts.Columns.Add("ราคา", 65, HorizontalAlignment.Right);
            IsvProducts.Columns.Add("จํานวน", 50, HorizontalAlignment.Right);
            IsvProducts.Columns.Add("รวมเป็นเงิน", 70, HorizontalAlignment.Right);
            IsvProducts.View = View.Details;
            IsvProducts.GridLines = true;
            IsvProducts.FullRowSelect = true;
        }

        private void ClearProductData() //เอาไว้เคลียร์ข้อมูลสินค้าใน Textbox
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtUnitPrice.Text = "0";
            txtQuantity.Text = "1";
            txtTotal.Text = "0";
        }

        private void clearEmployeeData() //สำหรับเคลียร์ข้อมูลใน textbox พนักงานขาย
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
        }

        private void CalculateTotal() //เอาไว้คำนวณราคารวม ของรายการแต่ละบรรทัด
        {
            double total = Convert.ToDouble(txtUnitPrice.Text) * Convert.ToDouble(txtQuantity.Text);
            txtTotal.Text = total.ToString("#,##0.00");
            txtProductID.Focus();
        }
        private void CalulateNetPrice() //เอาไว้ค่านวณราคารวมทั้งหมด
        {
            int i = 0;
            double tmpNetPrice = 0.0;
            for (i = 0; i <= IsvProducts.Items.Count - 1; i++)
            {
                tmpNetPrice += Convert.ToDouble(IsvProducts.Items[i].SubItems[4].Text);
            }
            lblNetPrice.Text = tmpNetPrice.ToString("#,##0.00");
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "Select EmployeeID, Title+FirstName+ SPACE(2)+ LastName as empName, Position from employees where employeeID = @employeeID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtEmployeeID.Text = dt.Rows[0][0].ToString();
                    txtEmployeeName.Text = dt.Rows[0][1].ToString();
                    txtProductID.Focus();
                }
                else
                {
                    clearEmployeeData();
                    txtEmployeeName.Focus();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "Select ProductID,ProductName,unitPrice from products where productID = @ProductID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtProductID.Text = dt.Rows[0][0].ToString();
                    txtProductName.Text = dt.Rows[0][1].ToString();
                    txtUnitPrice.Text = dt.Rows[0][2].ToString();
                    CalculateTotal();
                    txtProductID.Focus();
                }
                else
                {
                    MessageBox.Show("ไม่พบสินค้านี้", "ผิดพลาด");
                    ClearProductData();
                    txtProductID.Focus();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim() == "") txtQuantity.Text = "1";
            if (Convert.ToInt16(txtQuantity.Text) == 0) txtQuantity.Text = "1";
            CalculateTotal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Trim() == "" || txtProductName.Text.Trim() == "")
            {
                txtProductID.Focus();
                return;
            }
            if (Convert.ToInt16(txtQuantity.Text) == 0)
            {
                txtProductID.Focus();
                return;
            }
            ListViewItem Ivi;
            int i = 0;
            string tmpProductID = "";
            for (i = 0; i <= IsvProducts.Items.Count - 1; i++)
            {
                tmpProductID = IsvProducts.Items[i].SubItems[0].Text;
                if (txtProductID.Text.Trim() == tmpProductID)
                {
                    int qty = Convert.ToInt16(IsvProducts.Items[i].SubItems[3].Text)
                        + Convert.ToInt16(txtQuantity.Text);
                    double newTotal = Convert.ToDouble(IsvProducts.Items[i].SubItems[4].Text)
                        + Convert.ToDouble(txtTotal.Text); //**
                    IsvProducts.Items[i].SubItems[3].Text = qty.ToString();
                    IsvProducts.Items[i].SubItems[4].Text = newTotal.ToString("#,##0.00");
                    ClearProductData();
                    CalculateTotal();
                    CalulateNetPrice();
                    return;
                }
            }
            string[] anyData;
            anyData = new string[] { txtProductID.Text, txtProductName.Text, txtUnitPrice.Text, txtQuantity.Text, txtTotal.Text };
            Ivi = new ListViewItem(anyData);
            IsvProducts.Items.Add(Ivi);
            CalulateNetPrice(); ClearProductData(); btnSave.Enabled = true;
            txtProductID.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProductData();
        }

        private void IsvProducts_DoubleClick(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i <= IsvProducts.SelectedItems.Count - 1; i++)
            {
                ListViewItem Ivi = IsvProducts.SelectedItems[i];
                IsvProducts.Items.Remove(Ivi);
            }
            CalulateNetPrice();
            txtProductID.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsvProducts.Clear();
            clearEmployeeData();
            ClearProductData();
            ListViewFormat();
            lblNetPrice.Text = "0.00";
            txtEmployeeID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int lastOrderID = 0;
            if(txtEmployeeID.Text.Trim() == "")
            {
                MessageBox.Show("โปรดระบุผู้ขายสินค้าก่อน", "มีข้อผิดพลาด");
                txtEmployeeID.Focus();
                return;
            }
            if(IsvProducts.Items.Count >0)
            {
                if (MessageBox.Show("ต้องการบันทึกรายการสั่งซื้อหรือไม่", "กรุณายืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    tr = conn.BeginTransaction(); 
                    string sql = "insert into Receipts(ReceiptDate, EmployeeID, TotalCash) values (getdate(),@EmployeeID,@TotalCash)"; 

                    SqlCommand comm = new SqlCommand(sql, conn, tr);    
                    comm.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text.Trim()); 
                    comm.Parameters.AddWithValue("@TotalCash", lblNetPrice.Text); 
                    comm.ExecuteNonQuery(); 

                    string sql1 = "select top 1 ReceiptID from Receipts order by ReceiptID desc"; 
                    SqlCommand comm1 = new SqlCommand(sql1, conn, tr); 
                    SqlDataReader dr = comm1.ExecuteReader(); //อ่าน OrderID ล่าสุดใส่ไว้ในตัวแปร lastOrderID
                    if (dr.HasRows) 
                    { 
                        dr.Read(); 
                        lastOrderID = dr.GetInt32(dr.GetOrdinal("ReceiptID")); 
                    } 
                    dr.Close();
                    //เพิ่มข้อมูลรายการสินค้า OrderDetail ที่ตรงกับ lastOrderID
                    for (int i = 0; i <= IsvProducts.Items.Count - 1; i++)
                    {
                        string sql2 = "insert into Details (ReceiptID, ProductID, UnitPrice, Quantity) values(@ReceiptID, @ProductID, @UnitPrice, @Quantity)";
                        SqlCommand comm3 = new SqlCommand(sql2, conn, tr);
                        comm3.Parameters.AddWithValue("@ReceiptID", lastOrderID);
                        comm3.Parameters.AddWithValue("@ProductID", IsvProducts.Items[i].SubItems[0].Text);
                        comm3.Parameters.AddWithValue("@UnitPrice", IsvProducts.Items[i].SubItems[2].Text);
                        comm3.Parameters.AddWithValue("@Quantity", IsvProducts.Items[i].SubItems[3].Text);
                        comm3.ExecuteNonQuery();
                    }
                    tr.Commit(); 
                    conn.Close(); 
                    MessageBox.Show("บันทึกรายการขายเรียบร้อยแล้ว", "ผลการทํางาน"); 
                } 
                btnCancel.PerformClick(); //สั่งให้ไปกดปุ่ม cancel เคลีย์หน้าจอทั้งหมดใหม่เพื่อเริ่มรายการใหม่
            }
        }
    }
}
