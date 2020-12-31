using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public class Board
    {
        private int m_Rows;
        private int m_Columns;
        private Card[] m_Cards;
        private int m_TotalScore;
        private Card[,] m_BoardGame;
        private int m_IsPlayer1turn;
        private Card m_LastCard;

        public int Rows
        {
            get
            {
                return this.m_Rows;
            }

            set
            {
                this.m_Rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return this.m_Columns;
            }

            set
            {
                this.m_Columns = value;
            }
        }

        public Card[] Cards
        {
            get
            {
                return this.m_Cards;
            }

            set
            {
                this.m_Cards = value;
            }
        }

        public int TotalScore
        {
            get
            {
                return this.m_TotalScore;
            }

            set
            {
                this.m_TotalScore = value;
            }
        }

        public Card[,] BoardGame
        {
            get
            {
                return this.m_BoardGame;
            }

            set
            {
                this.m_BoardGame = value;
            }
        }

        public int IsPlayer1turn
        {
            get
            {
                return this.m_IsPlayer1turn;
            }

            set
            {
                this.m_IsPlayer1turn = value;
            }
        }

        public Card LastCard
        {
            get
            {
                return this.m_LastCard;
            }

            set
            {
                this.m_LastCard = value;
            }
        }

        public Board(int i_Rows, int i_Columns)
        {
            this.m_Rows = i_Rows;
            this.m_Columns = i_Columns;
            this.m_Cards = new Card[26];
            for (int i = 0; i < this.m_Cards.Length; i++)
            {
                this.m_Cards[i] = new Card();
                char letter = (char)(i + 65);
                this.m_Cards[i].Value = letter.ToString();
            }

            this.m_TotalScore = (i_Rows * i_Columns) / 2;
            this.m_BoardGame = new Card[i_Rows, i_Columns];
            for (int row = 0; row < this.m_Rows; row++)
            {
                for (int col = 0; col < this.m_Columns; col++)
                {
                    this.m_BoardGame[row, col] = new Card();
                }
            }

            this.m_IsPlayer1turn = 1;
            m_LastCard = new Card();
            buildBoard();
        }

        private void buildBoard()
        {
            Random rnd = new Random();
            int currentCardRow = 0;
            int currentCardColimns = 0;
            for (int i = 0; i < this.m_TotalScore; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    currentCardRow = rnd.Next(0, this.m_Rows);
                    currentCardColimns = rnd.Next(0, this.m_Columns);
                    while (!this.m_BoardGame[currentCardRow, currentCardColimns].Value.Equals(string.Empty))
                    {
                        currentCardRow = rnd.Next(0, this.m_Rows);
                        currentCardColimns = rnd.Next(0, this.m_Columns);
                    }

                    this.m_BoardGame[currentCardRow, currentCardColimns] = new Card();

                    this.m_BoardGame[currentCardRow, currentCardColimns].CopyCard(this.m_Cards[i]);
                    this.m_BoardGame[currentCardRow, currentCardColimns].Row = currentCardRow;
                    this.m_BoardGame[currentCardRow, currentCardColimns].Column = currentCardColimns;
                }
            }
        }

        public void Undiscoverd(Card io_Card1, Card io_Card2)
        {
            int row1 = io_Card1.Row;
            int col1 = io_Card1.Column;
            int row2 = io_Card2.Row;
            int col2 = io_Card2.Column;

            this.m_BoardGame[row1, col1].IsDiscoverd = false;
            this.m_BoardGame[row2, col2].IsDiscoverd = false;
        }
    }
}
