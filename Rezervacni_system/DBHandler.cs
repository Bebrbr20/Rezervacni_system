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
 
            private SQLiteConnection _db;

            public DBHandler()
            {

                _db = new SQLiteConnection("../../DB");
                _db.CreateTable<reservationDB>();
               
            }
      
     

    }
}
