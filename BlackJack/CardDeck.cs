using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class CardDeck : Program
    {
        public void CreateDeck(List<CardModel> DeckCreation)
        {
            //This loop first loop that cycles through the different suits.
            for (int i = 0; i < 4; i++)
            {
                int suit = i;
                // Loops through each card that is in each suit.
                for (int j = 2; j < 15; j++)
                {
                    int value = j;

                    //Creats a single card that properties can be applied to.
                    CardModel card = new CardModel();

                    switch (suit)
                    {
                        case 0:
                            card.Suit = "Diamonds";
                            break;
                        case 1:
                            card.Suit = "Hearts";
                            break;
                        case 3:
                            card.Suit = "Spades";
                            break;
                        default:
                            card.Suit = "Clubs";
                            break;
                    }
                    
                    //If statements that assign what the face value if each card is nby using the position in the loop.
                    //Ace can hold both a value of 1 and 11 ao it will be assigned later in the point addition phase.
                    switch (value)
                    {
                        case 14:
                            card.Number = "Ace";
                            break;
                        case 13:
                            card.Number = "King";
                            break;
                        case 12:
                            card.Number = "Queen";
                            break;
                        case 11:
                            card.Number = "Jack";
                            break;
                        default:
                            card.Number = value.ToString();
                            break;
                    }
                    if (value == 14)
                    {
                        card.PointValue = 11;
                    }
                    if (value >= 10 && value < 14)
                    {
                        card.PointValue = 10;
                    }
                    else if (value < 10)
                    {
                        card.PointValue = value;
                    }

                    //Verifies that each card and its properties are created correctly. Used for Debugging.
                    //Console.WriteLine("The {0} of {1} was created with a point value of {2}.", card.Number, card.Suit, card.PointValue);

                    //Adds the new card into the deck.
                    DeckCreation.Add(card);
                }
            }
            //Verifies that the entire deck of 52 was created.  Used for Debugging.
            //Console.WriteLine("The card deck has {0} cards,\n", DeckCreation.Count);



        }   
    }
}