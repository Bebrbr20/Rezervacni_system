﻿using Rezervacni_system.DB;
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

        public int uuid { get; set; }

        public SubWindow(String Atributes, int uuid)
        {

            /// Init window
            /// 
            _db = new DBHandler();
            _db.CreateTable<reservationDB>();

            


            InitializeComponent();


            this.Atributes = Atributes;

            this.uuid = uuid;

            string[] location = Atributes.Split('_');

            this.Row = int.Parse(location[1]);

            this.Column = int.Parse(location[2]);

            Label.Content = "Sedadlo -" + " řada: " + location[1] + " číslo: " + location[2];
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// Function for inserting to DB
        public static void Insert(SQLiteConnection db, string status, int uuid, int row, int column, string name, string email, string tel)
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
           // SubWindow.close();
        }

        private void free(object sender, RoutedEventArgs e)
        {
            Insert(_db._db, "avaliable", this.uuid, this.Row, this.Column, "", "", "");
           // SubWindow.close();

        }

        private void sold_on_place(object sender, RoutedEventArgs e)
        {
            Insert(_db._db, "soldOnPlace", this.uuid, this.Row, this.Column, "", "", "");
          //  SubWindow.close();

        }
    }
}
