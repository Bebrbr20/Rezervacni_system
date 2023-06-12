using Rezervacni_system.DB;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rezervacni_system
{
    /// <summary>
    /// Interakční logika pro SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        DBHandler _db;

        public string Atributes { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public string uuid { get; set; }
        public Button button { get; set; }

        public SubWindow(String Atributes, string uuid, Button button)
        {

            /// Init window
            /// 
            _db = new DBHandler();
            _db.CreateTable<reservationDB>();

            


            InitializeComponent();

            

            this.Atributes = Atributes;

            this.uuid = uuid;

            this.button = button;

            string[] location = Atributes.Split('_');

            this.Row = int.Parse(location[1]);

            this.Column = int.Parse(location[2]);

            Label.Content = "Sedadlo -" + " řada: " + location[1] + " číslo: " + location[2];

            string select_query = "SELECT * FROM reservationDB WHERE Uuid = ";
            select_query = select_query + "'" + uuid + "'" + "AND row ='" + location[1] + "'AND column ='" + location[2] + "'";
            List<reservationDB> result = _db._db.Query<reservationDB>(select_query);

            if (result != null)
            {
                foreach (var item in result)
                {
                    Jmeno.Text = item.name;
                    Email.Text = item.email;
                    Tel.Text = item.tel;
                }
                
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// Function for inserting to DB
        public static void Insert(SQLiteConnection db, string status, string uuid, int row, int column, string name, string email, string tel)
        {
            var dbcon = new reservationDB()
            {
                Uuid = uuid,
                row = row,
                column = column,
                name = name,
                email = email,
                tel = tel,
                status = status

            };
            db.Insert(dbcon);
            Console.WriteLine("{0} == {1}", dbcon.status, dbcon.Uuid, dbcon.row, dbcon.column, dbcon.name, dbcon.email, dbcon.tel, dbcon.Id);
        }


        private void unavaliable(object sender, RoutedEventArgs e)
        {
            Insert(_db._db, "unavaliable", this.uuid, this.Row, this.Column, "", "", "");

            button.Background = new SolidColorBrush(Colors.Red);
            Close();
        }

        private void free(object sender, RoutedEventArgs e)
        {
            Insert(_db._db, "avaliable", this.uuid, this.Row, this.Column, "", "", "");

            button.Background = new SolidColorBrush(Colors.Green);
            Close();

        }

        private void sold_on_place(object sender, RoutedEventArgs e)
        {
            Insert(_db._db, "soldOnPlace", this.uuid, this.Row, this.Column, "", "", "");

            button.Background = new SolidColorBrush(Colors.Red);
            Close();

        }

        private void Reservation(object sender, RoutedEventArgs e)
        {
            if (Jmeno.Text.Length < 50 && Email.Text.Contains("@") && int.TryParse(Tel.Text, out _))
            {
                Insert(_db._db, "reserved", this.uuid, this.Row, this.Column, Jmeno.Text, Email.Text, Tel.Text);
                button.Background = new SolidColorBrush(Colors.Red);
                Send.Background = new SolidColorBrush(Colors.Green);
                Close();
            }
            else
            {
                Send.Background = new SolidColorBrush(Colors.Red);
            }
           
        }
    }
}
