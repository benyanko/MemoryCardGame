using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
   public class Card
    {
        private string m_Value;
        private bool m_IsDiscoverd;
        private bool m_IsOut;
        private int m_Row;
        private int m_Column;

        public string Value
        {
            get
            {
                return this.m_Value;
            }

            set
            {
                this.m_Value = value;
            }
        }

        public bool IsDiscoverd
        {
            get
            {
                return this.m_IsDiscoverd;
            }

            set
            {
                this.m_IsDiscoverd = value;
            }
        }

        public bool IsOut
        {
            get
            {
                return this.m_IsOut;
            }

            set
            {
                this.m_IsOut = value;
            }
        }

        public int Row
        {
            get
            {
                return this.m_Row;
            }

            set
            {
                this.m_Row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.m_Column;
            }

            set
            {
                this.m_Column = value;
            }
        }

        public Card()
        {
            this.m_IsDiscoverd = false;
            this.m_Value = string.Empty;
            this.m_Column = 0;
            this.m_Row = 0;
        }

        public void CopyCard(Card i_card)
        {
            this.m_Value = i_card.m_Value;
            this.m_IsDiscoverd = i_card.m_IsDiscoverd;
            this.m_IsOut = i_card.m_IsOut;
            this.m_Row = i_card.m_Row;
            this.m_Column = i_card.m_Column;
        }
    }
}