using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WinForm.Minimart
{
    internal class connectDB
    {
       public static SqlConnection ConnectMinimart()
        {
            string server = ".\\SQLEXPRESS";    //Name Server 
            string db = "Minimart";     //Name Database

            //คำสั่งเชื่อมต่อ Connection String
            string strCon = string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=True; Encrypt=False",server,db);
            //ประกาศตัวแปรคลาสเชื่อมต่อ
            SqlConnection conn = new SqlConnection(strCon);
            //เปิดการเชื่อมต่อกับฐานข้อมูล
            conn.Open();
            return conn;
        }
    }
}
