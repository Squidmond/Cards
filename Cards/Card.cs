using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    class Card
    {
        #region Properties
        public string Suit { get; }
        public string Value { get; }
        #endregion
        #region Constructors
        public Card(string Suit, string Value)
        {
            this.Suit = Suit;
            this.Value = Value;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return this.Value + " of " + this.Suit ;
        }
        #endregion
    }
}
