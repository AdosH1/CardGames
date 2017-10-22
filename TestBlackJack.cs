using System;
using System.Collections.Generic;
using PlayingCards;
using BlackJackGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestBlackJack
    {
        [TestMethod]
        public void TestDealCards()
        {
			//Initialise variables
			Deck d = new Deck();
			Player p1 = new Player();
			Player p2 = new Player();

			List<Player> pList = new List<Player>();
			pList.Add(p1);
			pList.Add(p2);

			//Deal 2 cards to each player
	        foreach (Player p in pList)
	        {
		        d.DealCard(p, 2);
	        }

			//Assert 2 cards are in each player's hand
			Assert.AreEqual(2, p1._hand.Count);
	        Assert.AreEqual(2, p2._hand.Count);
			//Assert 4 cards have been removed from deck
			Assert.AreEqual(48, d._deck.Count);
		}

	    [TestMethod]
	    public void TestEmptyDeckDealCards()
	    {
		    //Initialise variables
		    Deck d = new Deck();
		    Player p1 = new Player();

		    bool success = d.DealCard(p1, 53);

		    Assert.AreEqual(52, p1._hand.Count);
		    Assert.AreEqual(0, d._deck.Count);
			Assert.IsFalse(success);
	    }

	    [TestMethod]
	    public void TestIsBusted()
	    {
		    //Double Aces
		    Player p = new Player();

		    p.Add(new AceOfClubs());
			p.Add(new AceOfDiamonds());

			var busted = BlackJack.IsBusted(p);

			Assert.IsFalse(busted);
			Assert.AreEqual(12, p.HandValue);
			p.DiscardHand();

			//King + Ace
			p.Add(new AceOfHearts());
			p.Add(new KingOfClubs());

		    busted = BlackJack.IsBusted(p);

			Assert.IsFalse(busted);
			Assert.AreEqual(21, p.HandValue);
			p.DiscardHand();

			//Jack + Queen + Ace
		    p.Add(new JackOfClubs());
		    p.Add(new QueenOfClubs());
			p.Add(new AceOfClubs());

		    busted = BlackJack.IsBusted(p);

		    Assert.IsFalse(busted);
		    Assert.AreEqual(21, p.HandValue);
			p.DiscardHand();

		    //Jack + Queen + Ace + Ace
		    p.Add(new JackOfClubs());
		    p.Add(new QueenOfClubs());
		    p.Add(new AceOfClubs());
			p.Add(new AceOfDiamonds());

		    busted = BlackJack.IsBusted(p);

		    Assert.IsTrue(busted);
		    Assert.AreEqual(22, p.HandValue);
		}
	}
}
