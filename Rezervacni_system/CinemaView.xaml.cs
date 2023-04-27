using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interakční logika pro CinemaView.xaml
    /// </summary>
    public partial class CinemaView : Window
    {
        public CinemaView( string Cols, string Rows)
        {
            InitializeComponent();

            
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



                    button.Margin = new Thickness(1, 10, 1, 0);
                    button.Background = new SolidColorBrush(Colors.Green);
                    button.Click += new RoutedEventHandler(buttonClick);

                    this.grid.Children.Add(button);

                    button.Name = "button_" + y + "_" + x;

                }
            }

            void buttonClick(object sender, RoutedEventArgs e)
            {
                Button button = sender as Button;

                Button btn = (Button)sender;

                string BtnName;
                BtnName = (sender as System.Windows.Controls.Button).Content.ToString();

                //button.Background = new SolidColorBrush(Colors.Orange);

                SubWindow subWindow = new SubWindow(btn.Name);

                subWindow.Show();

            }
        }


    }
}
