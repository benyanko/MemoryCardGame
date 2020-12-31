using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameUI
{
    public partial class SettingsForm : Form
    {
        private int m_Col = 4;
        private int m_Row = 4;
        private int m_IsComputer = 1;
        private string m_Player1Name;
        private string m_Player2Name;

        public SettingsForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void m_BoardSizeButton_Click(object sender, EventArgs e)
        {
            if (m_Col == 6 && m_Row == 6)
            {
                m_Col = 4;
                m_Row = 4;
                m_BoardSizeButton.Text = string.Format("{0} X {1}", m_Row, m_Col);
            }
            else
            {
                if (m_Col < 6)
                {
                    m_Col++;
                    if (m_Row == 5 && m_Col == 5)
                    {
                        m_Col++;
                    }

                    m_BoardSizeButton.Text = string.Format("{0} X {1}", m_Row, m_Col);
                }
                else
                {
                    m_Col = 4;
                    m_Row++;
                    m_BoardSizeButton.Text = string.Format("{0} X {1}", m_Row, m_Col);
                }
            }
        }

        private void m_AgaintsButton_Click(object sender, EventArgs e)
        {
            m_IsComputer = m_IsComputer * -1;
            if (m_IsComputer == -1)
            {
                m_AgaintsButton.Text = "Againts Computer";
                m_Player2NameTextBox.ReadOnly = false;
                m_Player2NameTextBox.Text = string.Empty;
            }
            else
            {
                m_AgaintsButton.Text = "Againts a friend";
                m_Player2NameTextBox.ReadOnly = true;
                m_Player2NameTextBox.Text = "-Computer-";
            }
        }

        private void m_StartButton_Click(object sender, EventArgs e)
        {
            m_Player1Name = m_Player1NameTextBox.Text;
            m_Player2Name = m_Player2NameTextBox.Text;
            if (m_Player1Name.Equals(string.Empty) || m_Player2Name.Equals(string.Empty))
            {
                MessageBox.Show("Please insert players name", "Invaild name", MessageBoxButtons.OK);
            }
            else
            {
                BoardForm boardForm = new BoardForm(m_Row, m_Col, m_Player1Name, m_Player2Name, m_IsComputer);
                Hide();
                boardForm.ShowDialog();
            }
        }
    }
 }
