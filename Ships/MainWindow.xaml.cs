
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ships
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateGrid(playerGrid);
        }
        private void UpdateGrid(Grid foo)
        {
<<<<<<< HEAD
            for (int i = 0; i < 10; i++)
=======
            for(int i = 0; i < 10; i++)
>>>>>>> 31c37e3d20f166ec865f3e66dcc954e61dcde633
            {
                foo.RowDefinitions.Add(new RowDefinition());
                foo.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}