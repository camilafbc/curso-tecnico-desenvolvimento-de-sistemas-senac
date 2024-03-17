using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPDV
{
    internal class Config_example
    {
        public string server = "";
        public string database = "";
        public string porta = "";
        public string username = "";
        public string password = "";

        public string StringConnection()
        {
           return $"Server={server};Database={database};UID={username};PWD={password};PORT={porta}";
        }
    }
}
