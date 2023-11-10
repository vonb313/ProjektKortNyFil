using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52; //en konstant variabel med maximalt antal kort i leken.
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards); //Lista som innehåller playingcard objekt.

        public PlayingCard this[int idx] => null; //indexer
        public int Count => cards.Count;//antal kort i leken.
        #endregion

        public DeckOfCards()
        {
        } //standard konstruktor

        #region ToString() related
        public override string ToString() //presenterar kortleken med 4 kort på varje rad.
        {
            var sRet = "";
            for (int i = 0; i < cards.Count; i++)
            {
                sRet += cards[i].ToString();
                if ((i + 1) % 4 == 0)
                {
                    sRet += "\n";
                }
            }
            return sRet;
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle() //Blandar kortleken.
        {
            Random rnd = new Random(); //Slumpgenerator.
            cards = cards.OrderBy(card => rnd.Next()).ToList(); //Blandar kortleken genom att använda OrderBy med slumpmässiga nummer
        }
        public void Sort() //Sorterar kortleken.
        {
            cards.Clear(); //Rensar nuvarande kortlek.

            foreach (PlayingCardValue value in Enum.GetValues(typeof(PlayingCardValue))) //Går igenom varje värde i leken.
            {
                foreach (PlayingCardColor color in Enum.GetValues(typeof(PlayingCardColor))) //Går igenom varje färg i leken.
                {
                    cards.Add(new PlayingCard(color, value)); //Skapar kortet och lägger till i leken.
                }
            }
        }
        #endregion

        #region Creating a fresh Deck
        public void Clear()
        {
            cards.Clear();
        } //rensar leken
        public void CreateFreshDeck() //Skapar en ny kortlek.
        {
            cards.Clear(); // rensar kortleken.

            for (PlayingCardColor color = PlayingCardColor.Clubs; color <= PlayingCardColor.Spades; color++) //går igenom varje färg.
            {
                for (PlayingCardValue value = PlayingCardValue.Two; value <= PlayingCardValue.Ace; value++) //går igenom varje värde.
                {
                    cards.Add(new PlayingCard(color, value)); //lägger till i kortleken
                }
            }

            Shuffle(); //Blandar leken.

        }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard() //Tar bort och delar ut det översta kortet i leken.
        {

            if (cards.Count > 0)
            {
                PlayingCard topCard = cards[0]; //Hämtar det översta kortet.
                cards.RemoveAt(0); //Tar bort det översta kortet.
                return topCard; //delar ut det översta kortet.
            }
            else
            {
                throw new InvalidOperationException("The Deck is empty, cannot remove a card."); //meddelandet som skrivs ut i tryCatch i Deal metoden. (Kommer inte hända, finns alltid kort i leken.)
            }

        }
        #endregion
    }
}
