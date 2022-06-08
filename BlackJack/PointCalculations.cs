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
        public int AceCheck(List<CardModel>Hand)
        {
            PointCalculations pointCalculations = new PointCalculations();
            int points = pointCalculations.PointTotal(Hand);

            if (points > 21)
            {
                int newValue;
                foreach (CardModel card in Hand)
                {
                    if (card.PointValue == 11)
                    {
                        card.PointValue = 1;
                        break;
                    }
                }
                
                newValue = pointCalculations.PointTotal(Hand);
                return newValue;
            }
            else
            { 
                return points;
            }
            
        }

        public string IfBusted(int points)
        {
            string cont;
            if (points > 21)
            {
                Console.WriteLine("   You Busted, You have {0} points.", points);
                cont = "n";
            }
            else
            {
                Console.WriteLine("   Points = {0}", points);
                Console.WriteLine();
                Console.WriteLine("   Press y and enter to receive next card, any other key to pass.");
                cont = Console.ReadLine();
            }
            return cont;
        }

        public static void WinorLoose(int dealerPoints, int playerPoints)
        {
            if (playerPoints > 21)
            {
                Console.WriteLine("   You Lost because You Busted");
            }
            else if (dealerPoints > 21)
            {
                Console.WriteLine("   Dealer Busted, You Win!!!");
            }
            else if (dealerPoints < playerPoints)
            {
                Console.WriteLine("   You Win!!!!!");
            }
            else if (dealerPoints == playerPoints)
            {
                Console.WriteLine("   You Pushed");
            }
            else
            {
                Console.WriteLine("   You Lost");
            }
        }

        public int PointTotal(List<CardModel> Hand)
        {
            int Points = 0;
            foreach (CardModel card in Hand)
            {
                Points += card.PointValue;
            }
            return Points;
        }

        public static void Display(List<CardModel> Hand)
        {
            foreach (CardModel card in Hand)
            {
                Console.WriteLine("{0} of {1}, {2} points", card.Number, card.Suit, card.PointValue);
            }
        }

        public int DealerSoft17(List<CardModel>Hand ,int points)
        {
            int ace = 0;
            if (points ==17)
            {
                foreach (CardModel card in Hand)
                {
                    if (card.PointValue == 11)
                    {
                        ace = 1;
                    }
                }
            }
            return ace;
        }

       
            
       
    }
}
