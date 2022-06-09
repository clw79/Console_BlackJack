using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace BlackJack
{
    internal class PointCalculations
    {
        //Calculates the total points of the hand by looping and adding each card to the total.
        public int PointTotal(List<CardModel> Hand)
        {
            int Points = 0;
            foreach (CardModel card in Hand)
            {
                Points += card.PointValue;
            }
            return Points;
        }

        //Loops the list to write each cards Number, Suit, and PointValue to console.
        public static void Display(List<CardModel> Hand)
        {
            foreach (CardModel card in Hand)
            {
                Console.WriteLine("{0} of {1}, {2} points", card.Number, card.Suit, card.PointValue);
            }
        }
    }
}
