using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPDV
{
    internal class Config
    {
        public string server = "localhost";
        public string database = "pdv";
        public string porta = "3306";
        public string username = "root";
        public string password = "";

        public string StringConnection()
        {
            return $"Server={server};Database={database};UID={username};PWD={password};PORT={porta}";
        }
    }
}
