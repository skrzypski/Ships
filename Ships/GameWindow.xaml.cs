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
        TextBlock[,] tb_playerBoard;
        Button[,] tb_computerBoard;
        GameBoard player, computer;
        public GameWindow()
        {
            InitializeComponent();
            tb_playerBoard = new TextBlock[10, 10];
            tb_computerBoard = new Button[10, 10];
            CreateStructure();
            player = new GameBoard();
            player.randomPlacement();
            computer = new GameBoard();
            computer.randomPlacement();
            UpdateScreen();
        }

        private void CreateStructure()
        {
            for (int i = 0; i < 10; i++)
            {
                playerBoard.ColumnDefinitions.Add(new ColumnDefinition());
                playerBoard.RowDefinitions.Add(new RowDefinition());
                computerBoard.ColumnDefinitions.Add(new ColumnDefinition());
                computerBoard.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    TextBlock tb = new TextBlock();
                    tb.SetValue(Grid.RowProperty, i);
                    tb.SetValue(Grid.ColumnProperty, j);
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.Margin = new Thickness(5);
                    tb_playerBoard[i, j] = tb;
                    playerBoard.Children.Add(tb_playerBoard[i, j]);
                    //-----------------------------------------------
                    Button btn = new Button();
                    btn.SetValue(Grid.RowProperty, i);
                    btn.SetValue(Grid.ColumnProperty, j);
                    btn.HorizontalAlignment = HorizontalAlignment.Stretch;
                    btn.VerticalAlignment = VerticalAlignment.Stretch;
                    btn.Margin = new Thickness(5);
                    btn.Name = "a" + i.ToString() + "a" + j.ToString();
                    btn.Click += new RoutedEventHandler(this.playerMove);
                    tb_computerBoard[i, j] = btn;
                    computerBoard.Children.Add(tb_computerBoard[i, j]);

                }
            }
        }

        private void UpdateScreen()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tb_playerBoard[i, j].Text = player.board[i, j].ToString();
                    tb_computerBoard[i, j].Content = computer.board[i, j].ToString();
                }
            }
        }

        private void playerMove(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string[] coords = btn.Name.Split('a');
            int posX = int.Parse(coords[1]);
            int posY = int.Parse(coords[2]);
            //obsluga strzalu
            //strzal komputera
        }
    }
}
