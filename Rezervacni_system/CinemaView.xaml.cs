using Rezervacni_system.DB;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rezervacni_system
{
    /// <summary>
    /// Interakční logika pro CinemaView.xaml
    /// </summary>
    public partial class CinemaView : Window
    {

        DBHandler _db;
        // Vypsání kina 
        public CinemaView( string Cols, string Rows, string uuid)
        {
          
                _db = new DBHandler();
                //_db.CreateTable<reservationDB>();

                InitializeComponent();

                SQLiteConnection db = _db._db;

                string select_query = "SELECT * FROM reservationDB WHERE Uuid = ";
                select_query = select_query + "'" + uuid + "'";
                List<reservationDB> result = _db._db.Query<reservationDB>(select_query);



                grid.Rows = int.Parse(Rows); ;
                grid.Columns = int.Parse(Cols);
                for (int y = 1; y <= int.Parse(Rows); ++y)
                {


                    for (int x = 1; x <= int.Parse(Cols); ++x)
                    {



                        Button button = new Button()
                        {
                            Content = string.Format("{0}", x),

                            Tag = x
                        };



                      //  button.Margin = new Thickness(1, 15, 1, 0);

                        int exists = 0;
                        foreach (var item in result)
                        {
                            if (item.row == y && item.column == x && item.status != "avaliable")
                            {
                                exists++;
                            }
                        }
                        {

                        }

                        if (exists >= 1)
                        {
                            button.Background = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            button.Background = new SolidColorBrush(Colors.Green);

                        }


                        button.Click += new RoutedEventHandler(buttonClick);

                        this.grid.Children.Add(button);

                        button.Name = "button_" + y + "_" + x;

                    }
                    
           
            }
            // Otevnření pro interakce se sedadlem

            void buttonClick(object sender, RoutedEventArgs e)
            {
                Button button = sender as Button;

                Button btn = (Button)sender;

                string BtnName;
                BtnName = (sender as System.Windows.Controls.Button).Content.ToString();

                //button.Background = new SolidColorBrush(Colors.Orange);

                SubWindow subWindow = new SubWindow(btn.Name, uuid, button);

                subWindow.Show();

            }
        }


    }
}
