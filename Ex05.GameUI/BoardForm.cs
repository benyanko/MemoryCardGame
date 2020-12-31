using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{
    public class BoardForm : Form
    {
        private readonly int r_CardSize = 60;
        private readonly int r_FormWidth = 330;
        private readonly int r_FormHeight = 450;
        private int m_Rows;
        private int m_Columns;
        private int m_TotalScore;
        private int m_Turn;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private Card m_CurrentCard;
        private CardButton[,] m_CardButtons;
        private Board m_Board;
        private Label m_CurrentPlayerLabel;
        private Label m_Player1ScoreLabel;
        private Label m_Player2ScoreLabel;
        private Color m_Player1Color;
        private Color m_Player2Color;
        
        public BoardForm(int i_Rows, int i_Columns, string i_Player1Name, string i_Player2Name, int i_IsComputer)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            m_CurrentPlayerLabel = new Label();
            m_Player1ScoreLabel = new Label();
            m_Player2ScoreLabel = new Label();
            m_Player1Color = new Color();
            m_Player2Color = new Color();

            m_Player1Color = Color.Green;
            m_Player2Color = Color.Purple;
            m_Rows = i_Rows;
            m_Columns = i_Columns;
            m_Turn = 0;
            m_Player1 = new Player();
            m_Player1.Name = i_Player1Name;
            m_Player2 = new Player();
            m_Player2.Name = i_Player2Name;
            m_CurrentPlayer = new Player();
            m_CurrentCard = new Card();
            if (i_IsComputer == 1)
            {
                m_Player2.IsComputer = true;
            }

            m_Board = new Board(i_Rows, i_Columns);
            if (m_Board.IsPlayer1turn == 1)
            {
                m_CurrentPlayerLabel.Text = string.Format("Current Player: {0} ", m_Player1.Name);
                m_CurrentPlayerLabel.AutoSize = true;
                m_CurrentPlayerLabel.BackColor = m_Player1Color;
                m_CurrentPlayer.CopyPlayer(m_Player1);
            }
            else
            {
                m_CurrentPlayerLabel.Text = string.Format("Current Player: {0} ", m_Player2.Name);
                m_CurrentPlayerLabel.AutoSize = true;
                m_CurrentPlayerLabel.BackColor = m_Player2Color;
                m_CurrentPlayer.CopyPlayer(m_Player2);
            }

            m_Player1ScoreLabel.Text = string.Format("{0}: {1} Pairs", m_Player1.Name, m_Player1.Score);
            m_Player1ScoreLabel.AutoSize = true;
            m_Player1ScoreLabel.BackColor = m_Player1Color;
            m_Player2ScoreLabel.Text = string.Format("{0}: {1} Pairs", m_Player2.Name, m_Player2.Score);
            m_Player2ScoreLabel.AutoSize = true;
            m_Player2ScoreLabel.BackColor = m_Player2Color;

            m_TotalScore = m_Board.TotalScore;
            m_CardButtons = new CardButton[i_Rows, i_Columns];
            for (int row = 0; row < i_Rows; row++)
            {
                for (int col = 0; col < i_Columns; col++)
                {
                    m_CardButtons[row, col] = new CardButton();
                    m_CardButtons[row, col].Card = m_Board.BoardGame[row, col];
                    m_CardButtons[row, col].Click += CardButtons_Click;
                }
            }

            initializeComponent();
        }

        private void initializeComponent()
        {
            Size = new Size(r_FormWidth + ((m_Columns - 4) * 75), r_FormHeight + ((m_Rows - 4) * 75));
            for (int col = 0; col < m_Columns; col++)
            {
                for (int row = 0; row < m_Rows; row++)
                {
                    m_CardButtons[row, col].Width = r_CardSize;
                    m_CardButtons[row, col].Height = r_CardSize;
                    m_CardButtons[row, col].Location = new Point((col * 75) + 15, (row * 75) + 15);
                    Controls.Add(m_CardButtons[row, col]);
                }
            }

            m_CurrentPlayerLabel.Location = new Point(15, m_CardButtons[m_Rows - 1, 0].Bottom + 20);
            m_Player1ScoreLabel.Location = new Point(15, m_CurrentPlayerLabel.Bottom + 5);
            m_Player2ScoreLabel.Location = new Point(15, m_Player1ScoreLabel.Bottom + 5);
            Controls.Add(m_CurrentPlayerLabel);
            Controls.Add(m_Player1ScoreLabel);
            Controls.Add(m_Player2ScoreLabel);
        }
        
        private void CardButtons_Click(object sender, EventArgs e)
        {
            if ((sender as CardButton).Text.Equals(string.Empty))
            {
                int row = (sender as CardButton).Card.Row;
                int col = (sender as CardButton).Card.Column;
                PlayerTurn(row, col);
                CheckCards();
            }
        }

        private void PlayerTurn(int i_Row, int i_Col)
        {
            m_Turn++;
            
            Game.PlayTurn(m_Board, i_Row, i_Col, m_CurrentPlayer, m_Turn, m_CurrentCard);
            UpdateButtons();
        }

        private void CheckCards()
        {
            if (m_Turn == 2)
            {
                Game.CheckCards(m_CurrentCard, m_Board.LastCard, m_Player1, m_Player2, m_Board);
                System.Threading.Thread.Sleep(1500);
                m_Turn = 0;

                UpdateScore();
                UpdateButtons();
                UpdateCurrentPlayerLabel();
                CheckIfEndGame();
                ComputerTurn();
            }
        }

        private void ComputerTurn()
        {
            if (m_CurrentPlayer.IsComputer)
            {
                m_Turn++;
                Game.PlayTurn(m_Board, 0, 0, m_CurrentPlayer, m_Turn, m_CurrentCard);
                UpdateButtons();
                m_Turn++;
                System.Threading.Thread.Sleep(1500);
                Game.PlayTurn(m_Board, 0, 0, m_CurrentPlayer, m_Turn, m_CurrentCard);
                UpdateButtons();
                CheckCards();
            }
        }
       
        private void CheckIfEndGame()
        {
            if (m_Player1.Score + m_Player2.Score == m_TotalScore)
            {
                System.Threading.Thread.Sleep(1500);
                int isComputer = 1;
                if (!m_Player2.IsComputer)
                {
                    isComputer = isComputer * -1;
                }
                
                if (Game.CheckIfDrawResult(m_Player1, m_Player2))
                {
                if (MessageBox.Show(
@"The result is a draw!
Would you like a replay ?",
"Game Over",
MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        BoardForm boardForm = new BoardForm(m_Rows, m_Columns, m_Player1.Name, m_Player2.Name, isComputer);
                        Hide();
                        boardForm.ShowDialog();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    if(MessageBox.Show(
string.Format(
@"The winner is a {0}!
Would you like a replay ?",
Game.GetWinner(m_Player1, m_Player2)),
"Game Over",
MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        BoardForm boardForm = new BoardForm(m_Rows, m_Columns, m_Player1.Name, m_Player2.Name, isComputer);
                        Hide();
                        boardForm.ShowDialog();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }

        private void UpdateButtons()
        {
            for (int col = 0; col < m_Columns; col++)
            {
                for (int row = 0; row < m_Rows; row++)
                {
                    m_CardButtons[row, col].Card = m_Board.BoardGame[row, col];

                    if (m_CardButtons[row, col].Card.IsDiscoverd && !m_CardButtons[row, col].Card.IsOut)
                    {
                        m_CardButtons[row, col].Text = m_CardButtons[row, col].Card.Value;
                        if (m_Board.IsPlayer1turn == 1)
                        {
                            m_CardButtons[row, col].BackColor = m_Player1Color;
                        }
                        else
                        {
                            m_CardButtons[row, col].BackColor = m_Player2Color;
                        }
                    }

                    if (!m_CardButtons[row, col].Card.IsDiscoverd)
                    {
                        m_CardButtons[row, col].Text = string.Empty;
                        m_CardButtons[row, col].BackColor = Color.Empty;
                    }

                    m_CardButtons[row, col].Refresh();
                }
            }
        }

        private void UpdateScore()
        {
            m_Player1ScoreLabel.Text = string.Format("{0}: {1} Pairs", m_Player1.Name, m_Player1.Score);
            m_Player2ScoreLabel.Text = string.Format("{0}: {1} Pairs", m_Player2.Name, m_Player2.Score);
            m_Player1ScoreLabel.Refresh();
            m_Player2ScoreLabel.Refresh();
        }

        private void UpdateCurrentPlayerLabel()
        {
            if (m_Board.IsPlayer1turn == 1)
            {
                m_CurrentPlayerLabel.Text = string.Format("Current Player: {0} ", m_Player1.Name);
                m_CurrentPlayerLabel.AutoSize = true;
                m_CurrentPlayerLabel.BackColor = m_Player1Color;
                m_CurrentPlayer.CopyPlayer(m_Player1);
            }
            else
            {
                m_CurrentPlayerLabel.Text = string.Format("Current Player: {0} ", m_Player2.Name);
                m_CurrentPlayerLabel.AutoSize = true;
                m_CurrentPlayerLabel.BackColor = m_Player2Color;
                m_CurrentPlayer.CopyPlayer(m_Player2);
            }

            m_CurrentPlayerLabel.Refresh();
        }
    }
}
