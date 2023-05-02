using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Rezervacni_system
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private void ListView()
        {
            string jsonFilePath = "../../Data/filmy.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonData);


            ListView movieListView = new ListView
            {
                ItemsSource = movies,
                DataContext = movies,
                FontSize = 20
            };


           

            movieListView.MouseDoubleClick += SelectMovie;

            GridView movieGridView = new GridView();

            movieListView.View = movieGridView;

            movieGridView.Columns.Add(new GridViewColumn
            {
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

            Grid.SetRow(movieListView, 1);
            Grid.SetColumn(movieListView, 0);

            mainGrid.Children.Add(movieListView);
        }

        public MainWindow()
        {
            InitializeComponent();

            ListView();


        }

        private void SelectMovie(object sender, MouseButtonEventArgs e)
        {
            if(sender is ListView movieListView && movieListView.SelectedItem is Movie selectedMovie)
            {
                CinemaView cinemaView = new CinemaView(selectedMovie.cinema.rows, selectedMovie.cinema.columns);

                cinemaView.Show();
            }
            
        }
    }
        }
