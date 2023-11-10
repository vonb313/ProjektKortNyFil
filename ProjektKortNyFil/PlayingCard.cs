using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
    {
        //Properties för att lagra färg och värde.
        public PlayingCardColor Color { get; init; }
        public PlayingCardValue Value { get; init; }

        public PlayingCard(PlayingCardColor color, PlayingCardValue value) //Konstruktor för att initialisera färg och värde.
        {
            Color = color;
            Value = value;
        }

        #region IComparable Implementation
        public int CompareTo(PlayingCard other) // Icomparable interface för att kunna jämnföra värdet på korten.
        {
            if (Value != other.Value)
            {
                return Value.CompareTo(other.Value);
            }
            return 0;
        }
        #endregion

        #region ToString() related
        string ShortDescription //Kort beskrving av kortet.
        {
            //Use switch statment or switch expression
            //https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
            get
            {

                string CardValueSwitch(PlayingCardValue value) //Switchsats som hanterar värdet.
                {
                    switch (value)
                    {
                        case PlayingCardValue.Two: //Ifall kortet har värdet "två"
                            return "2";//Presenteras det som "2". OSV.
                        case PlayingCardValue.Three:
                            return "3";
                        case PlayingCardValue.Four:
                            return "4";
                        case PlayingCardValue.Five:
                            return "5";
                        case PlayingCardValue.Six:
                            return "6";
                        case PlayingCardValue.Seven:
                            return "7";
                        case PlayingCardValue.Eight:
                            return "8";
                        case PlayingCardValue.Nine:
                            return "9";
                        case PlayingCardValue.Ten:
                            return "10";
                        case PlayingCardValue.Knight:
                            return "J";
                        case PlayingCardValue.Queen:
                            return "Q";
                        case PlayingCardValue.King:
                            return "K";
                        case PlayingCardValue.Ace:
                            return "A";
                        default:
                            return "Unknown";
                    }
                }
                string CardColorSwitch(PlayingCardColor color)
                {
                    switch (color) //Switch sats som presneterar färgen.
                    {
                        case PlayingCardColor.Spades: //Om kortet är "Spades"
                            return "♠️"; //Skrivs symboler ut istället.
                        case PlayingCardColor.Hearts:
                            return "♥️";
                        case PlayingCardColor.Clubs:
                            return "♣️";
                        case PlayingCardColor.Diamonds:
                            return "♦️";
                        default:
                            return "Unknown";
                    }
                }

                string ValueCard = CardValueSwitch(Value);
                string ColorCard = CardColorSwitch(Color);

                return $" |{ColorCard,2}{ValueCard,2}{ColorCard,2}| "; //Presentationen av Kortet.
            }
        }

        public override string ToString() => ShortDescription;

        int IComparable<IPlayingCard>.CompareTo(IPlayingCard other) //Icomparable interface för jämförelse av värde och färg.
        {
            if (other == null)
            {
                return 1;
            }

            if (Value != other.Value)
            {
                return Value.CompareTo(other.Value);
            }
            else
            {
                return Color.CompareTo(other.Color); //Om värdet är samma så jämnförs färgen. (Används ej i mitt spel.)
            }

        }
        #endregion
    }
}
