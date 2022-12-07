using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectDB
{
    public class Class1
    {
    }
    public class Server
    {
        string stringConnect;
        MySqlConnection Conn;
        public MySqlConnection Connection()
        {
            Conn = new MySqlConnection(stringConnect);
            return Conn;
        }
        public string RecConnection()
        {
            return stringConnect;
        }
        public Server(string connect)
        {
            stringConnect = connect;
        }

    }
 

}
