using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {

        private List<PlayingCard> hand = new List<PlayingCard>(); //Lista för att lagra spelarens kort.

        public int PlayerNumber { get; set; } //hade problem med att presentera spelarens hand så jag fick skapa en property med Playernumber som tilldelas vid skapandet.

        #region Pick and Add related
        public void Add(PlayingCard card) //Metod för att lägga till kort i spelarens hand.
        {
            hand.Add(card);
        }
        #endregion

        #region Highest Card related
        public PlayingCard Highest //För att hämta högsta kortet.
        {
            get
            {
                if (hand.Count > 0)
                {
                    return hand.Max();
                }
                return null;
            }
        }
        public PlayingCard Lowest
        {
            get
            {
                if (hand.Count > 0)
                {
                    return hand.Min();
                }
                return null;
            }
        } //För att hämta lägsta kortet.
        #endregion

        public override string ToString() //Tostring metod för att presentera spelarens hand.
        {
            if (hand.Count > 0) //Om spelaren har några kort i handen.
            {
                string cardsOnHand = string.Join(" ", hand); // Join metod för att skriva ut korten i listan med ett mellanrum mellan varje kort. 
                return $"Player {PlayerNumber} hand with {hand.Count} cards: {cardsOnHand}\n";
            }
            return $"Player {PlayerNumber} hand is empty.";
        }
    }
}
