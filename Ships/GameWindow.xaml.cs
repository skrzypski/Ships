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

namespace Ships
{
    /// <summary>
    /// Logika interakcji dla klasy GameWindows.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        TextBlock[,] tb_playerBoard, tb_computerBoard;
        public GameWindow()
        {
            InitializeComponent();
            tb_playerBoard = new TextBlock[10, 10];
            tb_computerBoard = new TextBlock[10, 10];
            CreateStructure();
        }

        private void CreateStructure()
        {
            for(int i = 0; i < 10; i++)
            {
                playerBoard.ColumnDefinitions.Add(new ColumnDefinition());
                playerBoard.RowDefinitions.Add(new RowDefinition());
            }
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    TextBlock tb = new TextBlock();
                    tb.SetValue(Grid.RowProperty, i);
                    tb.SetValue(Grid.ColumnProperty, j);
                    tb.Text = i.ToString() + " " + j.ToString();
                    tb_playerBoard[i, j] = tb;
                }
            }
        }
    }
}
