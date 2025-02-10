namespace WinForm.Minimart
{
    partial class FrmPOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtEmployeeID = new TextBox();
            txtEmployeeName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblNetPrice = new Label();
            groupBox1 = new GroupBox();
            IsvProducts = new ListView();
            txtUnitPrice = new TextBox();
            txtQuantity = new TextBox();
            txtTotal = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtProductName = new TextBox();
            label6 = new Label();
            txtProductID = new TextBox();
            label5 = new Label();
            btnAdd = new Button();
            btnClear = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(194, 41);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(100, 27);
            txtEmployeeID.TabIndex = 0;
            txtEmployeeID.KeyDown += txtEmployeeID_KeyDown;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(395, 41);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.ReadOnly = true;
            txtEmployeeName.Size = new Size(169, 27);
            txtEmployeeName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(106, 44);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = "รหัสพนักงาน";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 44);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 3;
            label2.Text = "ชื่อ-สกุล";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(627, 9);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 4;
            label3.Text = "รวมเป็นเงิน";
            // 
            // lblNetPrice
            // 
            lblNetPrice.BackColor = Color.LightCoral;
            lblNetPrice.Font = new Font("Tw Cen MT Condensed Extra Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNetPrice.ForeColor = Color.White;
            lblNetPrice.Location = new Point(614, 35);
            lblNetPrice.Name = "lblNetPrice";
            lblNetPrice.Size = new Size(238, 49);
            lblNetPrice.TabIndex = 5;
            lblNetPrice.Text = "lblNetPrice";
            lblNetPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(IsvProducts);
            groupBox1.Controls.Add(txtUnitPrice);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(txtTotal);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtProductID);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 105);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(666, 488);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "รายการสั่งซื้อ";
            // 
            // IsvProducts
            // 
            IsvProducts.Location = new Point(6, 110);
            IsvProducts.Name = "IsvProducts";
            IsvProducts.Size = new Size(654, 372);
            IsvProducts.TabIndex = 16;
            IsvProducts.UseCompatibleStateImageBehavior = false;
            IsvProducts.DoubleClick += IsvProducts_DoubleClick;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(315, 56);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.ReadOnly = true;
            txtUnitPrice.Size = new Size(92, 27);
            txtUnitPrice.TabIndex = 15;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(443, 56);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(69, 27);
            txtQuantity.TabIndex = 14;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(536, 56);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(92, 27);
            txtTotal.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(536, 33);
            label9.Name = "label9";
            label9.Size = new Size(71, 20);
            label9.TabIndex = 12;
            label9.Text = "รวมเป็นเงิน";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(443, 33);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 11;
            label8.Text = "จำนวน";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(315, 33);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 10;
            label7.Text = "ราคาขาย";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(157, 56);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(125, 27);
            txtProductName.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(157, 33);
            label6.Name = "label6";
            label6.Size = new Size(59, 20);
            label6.TabIndex = 8;
            label6.Text = "ชื่อสินค้า";
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(6, 56);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(125, 27);
            txtProductID.TabIndex = 7;
            txtProductID.KeyDown += txtProductID_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 33);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 7;
            label5.Text = "รหัสสินค้า";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Bisque;
            btnAdd.Location = new Point(717, 161);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(117, 47);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "เพิ่ม";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Bisque;
            btnClear.Location = new Point(717, 222);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(117, 52);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Bisque;
            btnSave.Enabled = false;
            btnSave.Location = new Point(717, 293);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(117, 52);
            btnSave.TabIndex = 9;
            btnSave.Text = "บันทึก";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Bisque;
            btnCancel.Location = new Point(699, 364);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 45);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "ยกเลิกรายการสั่งซื้อ";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(870, 605);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Controls.Add(lblNetPrice);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmployeeName);
            Controls.Add(txtEmployeeID);
            Name = "FrmPOS";
            Text = "FrmPOS";
            Load += FrmPOS_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmployeeID;
        private TextBox txtEmployeeName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblNetPrice;
        private GroupBox groupBox1;
        private ListView IsvProducts;
        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private TextBox txtTotal;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txtProductName;
        private Label label6;
        private TextBox txtProductID;
        private Label label5;
        private Button btnAdd;
        private Button btnClear;
        private Button btnSave;
        private Button btnCancel;
    }
}