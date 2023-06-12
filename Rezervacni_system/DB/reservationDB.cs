using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rezervacni_system.DB
{
    public class reservationDB
    {
         [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Uuid { get; set; }
            public int row { get; set; }
            public int column { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string tel { get; set; }
            public string status { get; set; }

        public reservationDB() { }
        
    }
}
