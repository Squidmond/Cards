using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    class Deck
    {
        #region Properties
        public List<Card> Cards { get; }
        #endregion
        #region Constructors
        public Deck()
        {
            string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
            string[] values = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            List<Card> cards = new List<Card>();
            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    Card card = new Card(Suit: suit, Value: value);
                    cards.Add(card);
                }
            }
            this.Cards = cards;
        }
        #endregion
        #region Methods
        public void shuffle()
        {
            Random rnd = new Random();
            int suffleCount = rnd.Next(1000, 10000);

            for (int i = 0; i < suffleCount; i++)
            {
                int lowIndex = rnd.Next(0, this.Cards.Count);
                int highIndex = rnd.Next(0, this.Cards.Count);
                //SwapCards(LowIndex: lowIndex, HighIndex: highIndex);
                Card holdCard = this.Cards[index: lowIndex];
                this.Cards[index: lowIndex] = this.Cards[index: highIndex];
                this.Cards[index: highIndex] = holdCard;
            }

        }
        public void PrintCards(string Heading = "List of cards:")
        {
            Console.WriteLine(Heading);
            foreach(Card card in this.Cards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("\n\n");
        }
        //private void SwapCards(int LowIndex, int HighIndex)
        //{
        //    string holdSuit = this.Cards[index: LowIndex].suit;
        //    string holdValue = this.Cards[index: LowIndex].value;
        //    this.Cards[index: LowIndex].suit =
        //        this.Cards[index: HighIndex].suit;
        //    this.Cards[index: LowIndex].value =
        //        this.Cards[index: HighIndex].value;
        //    this.Cards[index: HighIndex].suit = holdSuit;
        //    this.Cards[index: HighIndex].value = holdValue;
        //}
        #endregion
    }
}
