using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public class Player
    {
        private string m_Name;
        private int m_Score;
        private bool m_IsComputer;

        public string Name
        {
            get
            {
                return this.m_Name;
            }

            set
            {
                this.m_Name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.m_Score;
            }

            set
            {
                this.m_Score = value;
            }
        }

        public bool IsComputer
        {
            get
            {
                return this.m_IsComputer;
            }

            set
            {
                this.m_IsComputer = value;
            }
        }

        public Player()
        {
            this.m_Name = string.Empty;
            this.m_Score = 0;
            this.m_IsComputer = false;
        }

        public void CopyPlayer(Player i_Player)
        {
            this.m_Name = i_Player.m_Name;
            this.m_Score = i_Player.m_Score;
            this.m_IsComputer = i_Player.m_IsComputer;
        }
    }
}