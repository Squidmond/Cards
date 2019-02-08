using System;
using Cards;
using System.Collections.Generic;
using System.Timers;

namespace Cards
{
    class Program
    {
        // Rules from
        // https://www.bicyclecards.com/how-to-play/blackjack/

        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.shuffle();

            // Deal cards
            Hand playerHand = new Hand();
            Hand dealerHand = new Hand();
            playerHand.Add(Card: deck.Draw());
            dealerHand.Add(Card: deck.Draw());
            playerHand.Add(Card: deck.Draw());
            dealerHand.Add(Card: deck.Draw());

            // Show initial card info (first dealer card face up)
            Console.WriteLine($"Dealer shows: {dealerHand.Cards[index: 0].ToString()}");
            Console.WriteLine($"Initial Draw:\n{playerHand.ToString()} - Value: {playerHand.BlackJackValue}");

            // Check for tie (Natural 21 for both player and dealer)
            if (playerHand.BlackJackValue == 21 && dealerHand.BlackJackValue == 21)
            {
                Console.WriteLine($"\nDealers Hand: {dealerHand.ToString()} - Value: {dealerHand.BlackJackValue}");
                Console.WriteLine($"Player and dealer both have natural Blackjacks (Stand-off).  Tie.");
            }
            else
            {
                if (playerHand.BlackJackValue == 21)
                {
                    Console.WriteLine($"\nDealers Hand: {dealerHand.ToString()} - Value: {dealerHand.BlackJackValue}");
                    Console.WriteLine("Natural Blackjack for player.  Player wins!");
                }
                else
                {
                    if (dealerHand.BlackJackValue == 21)
                    {
                        Console.WriteLine($"\nDealers Hand: {dealerHand.ToString()} - Value: {dealerHand.BlackJackValue}");
                        Console.WriteLine("Natural Blackjack for dealer.  Dealer wins!");
                    }
                    else
                    {
                        // Loop if player want more cards and isnt bust
                        Console.Write("\n\nPress H for another card (any other key to stay): ");
                        ConsoleKeyInfo key;
                        key = Console.ReadKey();
                        Console.WriteLine();
                        while (key.KeyChar.ToString().ToUpper() == "H" &&
                                playerHand.BlackJackValue < 22)
                        {
                            Card card = deck.Draw();
                            if (card != null)
                            {
                                // We have a valid card
                                playerHand.Add(Card: card);
                                Console.WriteLine($"{playerHand.ToString()} - Value: {playerHand.BlackJackValue}");
                            }
                            else
                            {
                                // This should never happen
                                Console.WriteLine("Out of cards!  Game over.");
                                throw new Exception("Out of cards");
                            }
                            if (playerHand.BlackJackValue < 22)
                            {
                                Console.Write("Press H for another card (any other key to stay): ");
                                key = Console.ReadKey();
                                Console.WriteLine();
                            }
                        }

                        if (playerHand.BlackJackValue > 21)
                        {
                            Console.WriteLine("Over 21 bust.  You loose.");
                        }
                        else
                        {
                            // Dealer Play Logic here
                            DealerPlay(DealerHand: dealerHand, PlayerHand: playerHand, CardDeck: deck);
                        }

                    }
                }
            }
            Console.WriteLine("\n\nGame over");
            Console.ReadKey();
        }
        private static void DealerPlay(Hand DealerHand, Hand PlayerHand, Deck CardDeck)
        {
            Console.WriteLine($"\nDealers Hand: {DealerHand.ToString()} - Value: {DealerHand.BlackJackValue}");
            if (DealerHand.BlackJackValue >= PlayerHand.BlackJackValue)
            {
                Console.WriteLine("Dealer wins (no additional cards needed).");
            }
            else
            {
                while (DealerHand.BlackJackValue < 17 && DealerHand.BlackJackValue < 22)
                {
                    Card card = CardDeck.Draw();
                    if (card != null)
                    {
                        // We have a valid card
                        DealerHand.Add(card);
                        Console.WriteLine($"\nDealers Hand: {DealerHand.ToString()} - Value: {DealerHand.BlackJackValue}");
                    }
                    else
                    {
                        // Out of cards
                        Console.WriteLine("Out of cards???");
                        throw new Exception("Out of cards.");
                    }
                }
                if (DealerHand.BlackJackValue > 21)
                {
                    Console.WriteLine("Dealer busts.  You win!");
                }
                else
                {
                    if (DealerHand.BlackJackValue == PlayerHand.BlackJackValue)
                    {
                        Console.WriteLine("Tie goes to dealers.  Dealer wins..");
                    }
                    else
                    {
                        if (DealerHand.BlackJackValue > PlayerHand.BlackJackValue)
                        {
                            Console.WriteLine("Dealer wins.");
                        }
                        else
                        {
                            Console.WriteLine("Player wins.");
                        }
                    }
                }
            }
        }
    }
}
