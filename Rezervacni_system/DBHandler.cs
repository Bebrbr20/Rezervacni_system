using Rezervacni_system.DB;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rezervacni_system
{
    public class DBHandler
    {
 
            public SQLiteConnection _db;

            public DBHandler()
            {

                _db = new SQLiteConnection("../../DB/databazka.db");
               
               
            }

        internal void CreateTable<T>()
        {
            _db.CreateTable<T>();
        }
    }
}
