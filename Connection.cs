using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
    class Connection:IConnect
    {
        public SqlConnection sql1 = new SqlConnection(); // создание канала подключения
        public void connect()
        {
            sql1.ConnectionString = (@"Data Source=10.10.10.34;Initial Catalog=15T-2-MakarevichD;
                                     Persist Security Info=True;User ID=MakarevichD;Password=impossible356"); // Адрес соединения                                                                                                                                                              // sql1.ConnectionString = (@"Data Source=10.10.10.34;Initial Catalog=15T-2-MakarevichD;Persist Security Info=True;User ID=MakarevichD;Password=impossible356");
        }//default connection
        public void connect(string k)
        {
            sql1.ConnectionString = k;
        }// change connection
        public void connect(string k,string m)
        {
            sql1.ConnectionString = "Data Source=10.10.10.34;Initial Catalog=15T-2-MakarevichD;" +
                "Persist Security Info=True;User ID=" + k + ";Password=" + m + "";

        }// change connection user
        public void Open()
        {
         sql1.Open();
        }// open connect
        public void Close()
        {
         sql1.Close();
        }//close connect
    }
}
