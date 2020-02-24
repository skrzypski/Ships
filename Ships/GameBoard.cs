using System;

namespace Ships
{
    public class GameBoard
    {
        public char[,] board { get; private set; }
        private int[] shipLength;
        private Random rnd;
        public GameBoard()
        {
            board = new char[10, 10];
            shipLength = new int[]{ 4,3,3,2,2,2,1,1,1,1};
            rnd = new Random();
        }

        public void randomPlacement()
        {
            for (int i = 0; i < 10; ++i)
            {
                while (!addShip(shipLength[i])) ;
            }
            for(int i = 0; i < 10; ++i)
            {
                for(int j = 0; j < 10; ++j)
                {
                    if (board[i, j] == '1') board[i, j] = ' ';
                }
            }
        }

        private int boolToInt(bool val)
        {
            return (val ? 1 : 0);
        }

        private void completeBoard()
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if (board[i, j] != 'S') board[i, j] = '-';
                }
            }
        }

        private bool addShip(int length)
        {
            bool orientation = (rnd.Next(0, 1) == 0) ? false : true; // true - pion; false - poziom;
            int x = rnd.Next(0,(orientation ? 10 : (1 + 10 - length)));
            int y = rnd.Next(0,(orientation ? (1 + 10 - length) : 10));

            for (int i = 0; i < length; ++i)
                if (board[x + (orientation ? 0 : i),y + (orientation ? i : 0)] > 0)
                    return false;

            if ((orientation ? y : x) != 0)
                board[x - boolToInt(!orientation),y - boolToInt(orientation)] = '1';
            if ((orientation ? y : x) + length < 10)
                board[x + (orientation ? 0 : length),y + (orientation ? length : 0)] = '1';
            for (int i = 0; i < length; ++i)
            {
                board[x + (orientation ? 0 : i),y + (orientation ? i : 0)] = 'S';
                if ((orientation ? x : y) > 0)
                    board[x - boolToInt(orientation) + (orientation ? 0 : i),y - boolToInt(!orientation) + (orientation ? i : 0)] = '1';
                if ((orientation ? x : y) + 1 < 10)
                    board[x + boolToInt(orientation) + (orientation ? 0 : i),y + boolToInt(!orientation) + (orientation ? i : 0)] = '1';
            }
            return true;
        }
        public bool addShip(int x, int y, bool orientation, int length)
        {
            for (int i = 0; i < length; ++i)
                if (board[x + (orientation ? 0 : i), y + (orientation ? i : 0)] > 0)
                    return false;

            if ((orientation ? y : x) != 0)
                board[x - boolToInt(!orientation), y - boolToInt(orientation)] = '1';
            if ((orientation ? y : x) + length < 10)
                board[x + (orientation ? 0 : length), y + (orientation ? length : 0)] = '1';
            for (int i = 0; i < length; ++i)
            {
                board[x + (orientation ? 0 : i), y + (orientation ? i : 0)] = 'S';
                if ((orientation ? x : y) > 0)
                    board[x - boolToInt(orientation) + (orientation ? 0 : i), y - boolToInt(!orientation) + (orientation ? i : 0)] = '1';
                if ((orientation ? x : y) + 1 < 10)
                    board[x + boolToInt(orientation) + (orientation ? 0 : i), y + boolToInt(!orientation) + (orientation ? i : 0)] = '1';
            }
            return true;
        }
    }
}
