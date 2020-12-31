using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{
    public class CardButton : Button
    {
        private Card m_Card;

        public CardButton()
        {
            this.m_Card = new Card();
        }

        public Card Card
        {
            get
            {
                return this.m_Card;
            }

            set
            {
                this.m_Card.CopyCard(value);
            }
        }
    }
}
