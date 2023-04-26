using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interakční logika pro MovieSelection.xaml
    /// </summary>
    public partial class MovieSelection : Window
    {
        private void ListView()
        {
            string jsonFilePath = "filmy.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonData);


            ListView movieListView = new ListView
            {
                ItemsSource = movies,
                DataContext = movies,
                FontSize = 20
            };


            movieListView.Items.Refresh();

            movieListView.MouseDoubleClick += SelectMovie;

            GridView movieGridView = new GridView();

            movieListView.View = movieGridView;

            movieGridView.Columns.Add(new GridViewColumn{
                Header = "movie name",
            DisplayMemberBinding = new Binding("name"),
    
            });


            movieGridView.Columns.Add(new GridViewColumn
            {
                Header = "cinema",
                DisplayMemberBinding = new Binding("cinema.name"),

            });

            movieGridView.Columns.Add(new GridViewColumn
            {
                Header = "date",
                DisplayMemberBinding = new Binding("date"),

            });

            movieGridView.Columns.Add(new GridViewColumn
            {
                Header = "rows",
                DisplayMemberBinding = new Binding("cinema.rows"),

            });

            movieGridView.Columns.Add(new GridViewColumn
            {
                Header = "cols",
                DisplayMemberBinding = new Binding("cinema.columns"),

            });

            Grid.SetRow(movieListView, 0);
            Grid.SetColumn(movieListView, 0);
        }



        public MovieSelection()
        {

        }

        
    }
}
