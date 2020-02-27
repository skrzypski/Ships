using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Threading;

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
        List<int> cpuMoves;
        Random rnd;
        char[,] playerScreen, computerScreen;
        int computerShips, playerShips;
        public GameWindow()
        {
            InitializeComponent();

            cpuMoves = new List<int>();

            int seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
            rnd = new Random(seed ^ seed * seed - seed);

            tb_playerBoard = new TextBlock[10, 10];
            tb_computerBoard = new Button[10, 10];

            CreateStructure();

            player = new GameBoard();
            player.randomPlacement();

            computer = new GameBoard();
            computer.randomPlacement();

            computerScreen = new char[10, 10];
            playerScreen = player.board;

            computerShips = 20;
            playerShips = 20;

            for (int i = 0; i < 100; i++)
            {
                cpuMoves.Add(i);
            }

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
                    tb_playerBoard[i, j].Text = playerScreen[i, j].ToString();
                    tb_computerBoard[i, j].Content = computerScreen[i, j].ToString();
                }
            }
        }

        private void playerMove(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string[] coords = btn.Name.Split('a');
            int posX = int.Parse(coords[1]);
            int posY = int.Parse(coords[2]);
            
            if(!Shoot(computer,posX,posY))
            {
                int r = rnd.Next(0, cpuMoves.Count);
                posX = (int)(Math.Floor((double)(r / 10)));
                posY = r % 10;
                while (Shoot(player, posX, posY)) ;
            }
        }

        private bool Shoot(GameBoard board, int posX, int posY)
        {
            Thread.Sleep(500);
            bool returnVal = false;
            if(board == computer)
            {
                if (board.board[posX,posY] == 'S')
                {
                    computerShips--;
                    if (computerShips == 0)
                    {
                        new VictoryWindow("ZWYCIĘSTWO!").Show();
                        this.Close();
                    }
                    computerScreen[posX, posY] = 'X';
                    tb_computerBoard[posX, posY].IsEnabled = false;
                    returnVal = true;
                }
                else
                {
                    computerScreen[posX, posY] = '•';
                    tb_computerBoard[posX, posY].IsEnabled = false;
                    returnVal = false;
                }
            }
            else if(board == player)
            {
                int r = rnd.Next(0, cpuMoves.Count);
                posX = (int)(Math.Floor((double)(r / 10)));
                posY = r % 10;
                if (board.board[posX, posY] == 'S')
                {
                    playerShips--;
                    if(playerShips == 0)
                    {
                        new VictoryWindow("PRZEGRANA!").Show();
                        this.Close();
                    }
                    playerScreen[posX, posY] = 'X';
                    returnVal = true;
                }
                else
                {
                    playerScreen[posX, posY] = '•';
                    returnVal = false;
                }
            }
            UpdateScreen();
            return returnVal;
        }
    }
}
