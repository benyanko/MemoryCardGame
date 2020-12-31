using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public class Game
    {
        public static void PlayTurn(Board io_Board, int i_Row, int i_Col, Player io_CurrentPlayer, int i_Turn, Card io_Card)
        {
            pickCard(io_CurrentPlayer, ref io_Card, i_Row, i_Col, io_Board, i_Turn);
            if (i_Turn == 1)
            {
                io_Board.LastCard.CopyCard(io_Card);
            }
        }

        private static void pickCard(Player io_Player, ref Card io_CurrentCard, int i_Row, int i_Col, Board io_Board, int i_Turn)
        {
            if (!io_Player.IsComputer)
            {
                io_Board.BoardGame[i_Row, i_Col].IsDiscoverd = true;
                io_CurrentCard.CopyCard(io_Board.BoardGame[i_Row, i_Col]);
            }
            else 
            {
                Random rnd = new Random();
                i_Row = rnd.Next(0, io_Board.Rows);
                i_Col = rnd.Next(0, io_Board.Columns);
                while (io_Board.BoardGame[i_Row, i_Col].IsDiscoverd)
                {
                    i_Row = rnd.Next(0, io_Board.Rows);
                    i_Col = rnd.Next(0, io_Board.Columns);
                }

                io_Board.BoardGame[i_Row, i_Col].IsDiscoverd = true;
                io_CurrentCard.CopyCard(io_Board.BoardGame[i_Row, i_Col]);
            }
        }

        public static void CheckCards(Card i_Card1, Card i_Card2, Player io_Player1, Player io_Player2, Board io_Board)
        {
            if (i_Card1.Value.Equals(i_Card2.Value))
            {
                io_Board.BoardGame[i_Card1.Row, i_Card1.Column].IsOut = true;
                io_Board.BoardGame[i_Card2.Row, i_Card2.Column].IsOut = true;
                if (io_Board.IsPlayer1turn == 1)
                {
                    io_Player1.Score++;
                }
                else
                {
                    io_Player2.Score++;
                }
            }
            else
            {
                io_Board.Undiscoverd(i_Card1, i_Card2);
                io_Board.IsPlayer1turn *= -1;
            }

            io_Board.LastCard = new Card();
        }

        public static string GetWinner(Player i_Player1, Player i_Player2)
        {
            string winner = string.Empty;
            if (i_Player1.Score > i_Player2.Score)
            {
                winner = i_Player1.Name;
            }
            else
            {
                winner = i_Player2.Name;
            }

            return winner;
        }

        public static bool CheckIfDrawResult(Player i_player1, Player i_player2)
        {
            if (i_player1.Score == i_player2.Score)
            {
                return true;
            }

            return false;
        }
    }
}
