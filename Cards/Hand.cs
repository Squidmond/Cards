using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cards
{
    class Hand
    {
        #region Properties
        public List<Card> Cards { get; }
        public int BlackJackValue { get; private set; }
        #endregion
        #region Constructors
        public Hand()
        {
            this.Cards = new List<Card>();
        }
        #endregion
        #region Methods
        public void Add(Card Card)
        {
            this.Cards.Add(Card);
            UpdateBlackJackValue();
        }
        public void List(string Heading = "List of cards in hand: ")
        {
            Console.WriteLine(Heading);
            foreach (Card card in this.Cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
        public override string ToString()
        {
            string returnString = "";
            foreach(Card card in this.Cards)
            {
                returnString = returnString + card.ToString() + ", ";
            }
            return returnString.Remove(returnString.Length - 2);
        }
        private void UpdateBlackJackValue()
        {
            this.BlackJackValue = 0;
            foreach (Card card in this.Cards)
            {
                switch (card.Value)
                {
                    case "Two":
                        this.BlackJackValue += 2;
                        break;
                    case "Three":
                        this.BlackJackValue += 3;
                        break;
                    case "Four":
                        this.BlackJackValue += 4;
                        break;
                    case "Five":
                        this.BlackJackValue += 5;
                        break;
                    case "Six":
                        this.BlackJackValue += 6;
                        break;
                    case "Seven":
                        this.BlackJackValue += 7;
                        break;
                    case "Eight":
                        this.BlackJackValue += 8;
                        break;
                    case "Nine":
                        this.BlackJackValue += 9;
                        break;
                    case "Ten":
                    case "Jack":
                    case "Queen":
                    case "King":
                        this.BlackJackValue += 10;
                        break;
                }
            }
            // Deal with Aces
            int aceCount = this.Cards.Where(c => c.Value == "Ace").Count();
            if (aceCount > 0)
            {
                // In case of multiple Aces
                this.BlackJackValue += aceCount - 1;
                if (this.BlackJackValue + 11 > 21)
                {
                    this.BlackJackValue += 1;
                }
                else
                {
                    this.BlackJackValue += 11;
                }
            }
        }
        #endregion
    }
}
