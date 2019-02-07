using System;
using Cards;
using System.Collections.Generic;
using System.Timers;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.PrintCards(Heading: "Before suffle:");
            deck.shuffle();
            deck.PrintCards(Heading: "After Suffle:");

            Console.ReadKey();
        }
    }
}
