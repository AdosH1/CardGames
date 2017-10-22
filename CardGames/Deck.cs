using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingCards
{
    public class Deck
    {
	    public List<PlayingCard> _deck;
	    private static readonly Random r = new Random(DateTime.Now.Millisecond);

		public Deck()
	    {
			_deck = new List<PlayingCard>();
		    InitialiseCards();
		    Shuffle();
	    }

		/// <summary>
		/// Adds one of each card to our deck.
		/// </summary>
	    private void InitialiseCards()
	    {
		    _deck.Add(new AceOfDiamonds());
		    _deck.Add(new AceOfClubs());
		    _deck.Add(new AceOfHearts());
		    _deck.Add(new AceOfSpades());

		    _deck.Add(new TwoOfDiamonds());
		    _deck.Add(new TwoOfClubs());
		    _deck.Add(new TwoOfHearts());
		    _deck.Add(new TwoOfSpades());

		    _deck.Add(new ThreeOfDiamonds());
		    _deck.Add(new ThreeOfClubs());
		    _deck.Add(new ThreeOfHearts());
		    _deck.Add(new ThreeOfSpades());

		    _deck.Add(new FourOfDiamonds());
		    _deck.Add(new FourOfClubs());
		    _deck.Add(new FourOfHearts());
		    _deck.Add(new FourOfSpades());

		    _deck.Add(new FiveOfDiamonds());
		    _deck.Add(new FiveOfClubs());
		    _deck.Add(new FiveOfHearts());
		    _deck.Add(new FiveOfSpades());

		    _deck.Add(new SixOfDiamonds());
		    _deck.Add(new SixOfClubs());
		    _deck.Add(new SixOfHearts());
		    _deck.Add(new SixOfSpades());

		    _deck.Add(new SevenOfDiamonds());
		    _deck.Add(new SevenOfClubs());
		    _deck.Add(new SevenOfHearts());
		    _deck.Add(new SevenOfSpades());

		    _deck.Add(new EightOfDiamonds());
		    _deck.Add(new EightOfClubs());
		    _deck.Add(new EightOfHearts());
		    _deck.Add(new EightOfSpades());

		    _deck.Add(new NineOfDiamonds());
		    _deck.Add(new NineOfClubs());
		    _deck.Add(new NineOfHearts());
		    _deck.Add(new NineOfSpades());

		    _deck.Add(new TenOfDiamonds());
		    _deck.Add(new TenOfClubs());
		    _deck.Add(new TenOfHearts());
		    _deck.Add(new TenOfSpades());

		    _deck.Add(new JackOfDiamonds());
		    _deck.Add(new JackOfClubs());
		    _deck.Add(new JackOfHearts());
		    _deck.Add(new JackOfSpades());

		    _deck.Add(new QueenOfDiamonds());
		    _deck.Add(new QueenOfClubs());
		    _deck.Add(new QueenOfHearts());
		    _deck.Add(new QueenOfSpades());

		    _deck.Add(new KingOfDiamonds());
		    _deck.Add(new KingOfClubs());
		    _deck.Add(new KingOfHearts());
		    _deck.Add(new KingOfSpades());
		}

		/// <summary>
		/// Based on the Fisher-Yates shuffle.
		/// https://stackoverflow.com/questions/1150646/card-shuffling-in-c-sharp
		/// </summary>
		private void Shuffle()
	    {
		    for (int i = _deck.Count - 1; i > 0; i--)
		    {
			    int rnd = r.Next(i + 1);
			    PlayingCard tmp = _deck[i];
			    _deck[i] = _deck[rnd];
			    _deck[rnd] = tmp;
		    }
	    }

	    public bool DealCard(Player p, int numCards = 1)
	    {
		    try
		    {
			    for (int i = 0; i < numCards; ++i)
			    {
				    ICard c = _deck[0];
				    _deck.RemoveAt(0);
				    p.Add(c);
			    }
		    }
		    catch (ArgumentOutOfRangeException e)
		    {
			    return false;
		    }
		    return true;
	    }
    }
}
