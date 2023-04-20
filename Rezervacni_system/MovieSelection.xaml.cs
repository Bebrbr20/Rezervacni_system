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
    /// Interakční logika pro MovieSelection.xaml
    /// </summary>
    public partial class MovieSelection : Window
    {



        public MovieSelection()
        {
            InitializeComponent();

            var listView = new ListView();
            listView.ItemsSource = new string[]
            {
  "mono",
  "monodroid",
  "monotouch",
  "monorail",
  "monodevelop",
  "monotone",
  "monopoly",
  "monomodal",
  "mononucleosis"
            };
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
