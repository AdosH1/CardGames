using PlayingCards;
using System;
using System.Collections.Generic;

/// <summary>
/// Our abstract, derived class for each playing card.
/// </summary>
public abstract class PlayingCard : ICard
{
	public enum suit
	{
		Diamonds = 0,
		Clubs = 1,
		Hearts = 2,
		Spades = 3
	};

	public string Name;
	public string shortName;
	public int Value;
	public suit Suit;

	protected PlayingCard()
	{
	}
}
#region Card Implementations
/// <summary>
/// Implementation of all cards in a standard 52-card deck.
/// </summary>
#region Aces
public interface IAce {}

public class AceOfDiamonds : PlayingCard, IAce
{
	public AceOfDiamonds()
	{
		Name = "Ace of Diamonds";
		shortName = "Ad";
		Value = 11;
		Suit = suit.Diamonds;
	}
}

public class AceOfClubs : PlayingCard, IAce
{
	public AceOfClubs()
	{
		Name = "Ace of Clubs";
		shortName = "Ac";
		Value = 11;
		Suit = suit.Clubs;
	}
}

public class AceOfHearts: PlayingCard, IAce
{
	public AceOfHearts()
	{
		Name = "Ace of Hearts";
		shortName = "Ah";
		Value = 11;
		Suit = suit.Hearts;
	}
}

public class AceOfSpades: PlayingCard, IAce
{
	public AceOfSpades()
	{
		Name = "Ace of Spades";
		shortName = "As";
		Value = 11;
		Suit = suit.Spades;
	}
}
#endregion
#region Twos
public interface ITwo { }

public class TwoOfDiamonds : PlayingCard, ITwo
{
	public TwoOfDiamonds()
	{
		Name = "Two of Diamonds";
		shortName = "2d";
		Value = 2;
		Suit = suit.Diamonds;
	}
}

public class TwoOfClubs: PlayingCard, ITwo
{
	public TwoOfClubs()
	{
		Name = "Two of Clubs";
		shortName = "2c";
		Value = 2;
		Suit = suit.Clubs;
	}
}

public class TwoOfHearts: PlayingCard, ITwo
{
	public TwoOfHearts()
	{
		Name = "Two of Hearts";
		shortName = "2h";
		Value = 2;
		Suit = suit.Hearts;
	}
}

public class TwoOfSpades : PlayingCard, ITwo
{
	public TwoOfSpades()
	{
		Name = "Two of Spades";
		shortName = "2s";
		Value = 2;
		Suit = suit.Spades;
	}
}
#endregion
#region Threes
public interface IThree { }
public class ThreeOfDiamonds : PlayingCard, IThree
{
	public ThreeOfDiamonds()
	{
		Name = "Three of Diamonds";
		shortName = "3d";
		Value = 3;
		Suit = suit.Diamonds;
	}
}

public class ThreeOfClubs : PlayingCard, IThree
{
	public ThreeOfClubs()
	{
		Name = "Three of Clubs";
		shortName = "3c";
		Value = 3;
		Suit = suit.Clubs;
	}
}

public class ThreeOfHearts: PlayingCard, IThree
{
	public ThreeOfHearts()
	{
		Name = "Three of Hearts";
		shortName = "3h";
		Value = 3;
		Suit = suit.Hearts;
	}
}

public class ThreeOfSpades : PlayingCard, IThree
{
	public ThreeOfSpades()
	{
		Name = "Three of Spades";
		shortName = "3s";
		Value = 3;
		Suit = suit.Spades;
	}
}
#endregion
#region Fours
public interface IFour { }
public class FourOfDiamonds : PlayingCard, IFour
{
	public FourOfDiamonds()
	{
		Name = "Four of Diamonds";
		shortName = "4d";
		Value = 4;
		Suit = suit.Diamonds;
	}
}

public class FourOfClubs: PlayingCard, IFour
{
	public FourOfClubs()
	{
		Name = "Four of Clubs";
		shortName = "4c";
		Value = 4;
		Suit = suit.Clubs;
	}
}

public class FourOfHearts: PlayingCard, IFour
{
	public FourOfHearts()
	{
		Name = "Four of Hearts";
		shortName = "4h";
		Value = 4;
		Suit = suit.Hearts;
	}
}

public class FourOfSpades: PlayingCard, IFour
{
	public FourOfSpades()
	{
		Name = "Four of Spades";
		shortName = "4s";
		Value = 4;
		Suit = suit.Spades;
	}
}
#endregion
#region Fives
public interface IFive{ }
public class FiveOfDiamonds : PlayingCard, IFive
{
	public FiveOfDiamonds()
	{
		Name = "Five of Diamonds";
		shortName = "5d";
		Value = 5;
		Suit = suit.Diamonds;
	}
}

public class FiveOfClubs: PlayingCard, IFive
{
	public FiveOfClubs()
	{
		Name = "Five of Clubs";
		shortName = "5c";
		Value = 5;
		Suit = suit.Clubs;
	}
}

public class FiveOfHearts: PlayingCard, IFive
{
	public FiveOfHearts()
	{
		Name = "Five of Hearts";
		shortName = "5h";
		Value = 5;
		Suit = suit.Hearts;
	}
}

public class FiveOfSpades: PlayingCard, IFive
{
	public FiveOfSpades()
	{
		Name = "Five of Spades";
		shortName = "5s";
		Value = 5;
		Suit = suit.Spades;
	}
}
#endregion
#region Sixes
public interface ISix{ }
public class SixOfDiamonds : PlayingCard, ISix
{
	public SixOfDiamonds()
	{
		Name = "Six of Diamonds";
		shortName = "6d";
		Value = 6;
		Suit = suit.Diamonds;
	}
}

public class SixOfClubs : PlayingCard, ISix
{
	public SixOfClubs()
	{
		Name = "Six of Clubs";
		shortName = "6c";
		Value = 6;
		Suit = suit.Clubs;
	}
}

public class SixOfHearts : PlayingCard, ISix
{
	public SixOfHearts()
	{
		Name = "Six of Hearts";
		shortName = "6h";
		Value = 6;
		Suit = suit.Hearts;
	}
}

public class SixOfSpades : PlayingCard, ISix
{
	public SixOfSpades()
	{
		Name = "Six of Spades";
		shortName = "6s";
		Value = 6;
		Suit = suit.Spades;
	}
}
#endregion
#region Sevens
public interface ISeven { }
public class SevenOfDiamonds : PlayingCard, ISeven
{
	public SevenOfDiamonds()
	{
		Name = "Seven of Diamonds";
		shortName = "7d";
		Value = 7;
		Suit = suit.Diamonds;
	}
}

public class SevenOfClubs : PlayingCard, ISeven
{
	public SevenOfClubs()
	{
		Name = "Seven of Clubs";
		shortName = "7c";
		Value = 7;
		Suit = suit.Clubs;
	}
}

public class SevenOfHearts : PlayingCard, ISeven
{
	public SevenOfHearts()
	{
		Name = "Seven of Hearts";
		shortName = "7h";
		Value = 7;
		Suit = suit.Hearts;
	}
}

public class SevenOfSpades : PlayingCard, ISeven
{
	public SevenOfSpades()
	{
		Name = "Seven of Spades";
		shortName = "7s";
		Value = 7;
		Suit = suit.Spades;
	}
}
#endregion
#region Eights
public interface IEight{ }
public class EightOfDiamonds : PlayingCard, IEight
{
	public EightOfDiamonds()
	{
		Name = "Eight of Diamonds";
		shortName = "8d";
		Value = 8;
		Suit = suit.Diamonds;
	}
}

public class EightOfClubs : PlayingCard, IEight
{
	public EightOfClubs()
	{
		Name = "Eight of Clubs";
		shortName = "8c";
		Value = 8;
		Suit = suit.Clubs;
	}
}

public class EightOfHearts : PlayingCard, IEight
{
	public EightOfHearts()
	{
		Name = "Eight of Hearts";
		shortName = "8h";
		Value = 8;
		Suit = suit.Hearts;
	}
}

public class EightOfSpades : PlayingCard, IEight
{
	public EightOfSpades()
	{
		Name = "Eight of Spades";
		shortName = "8s";
		Value = 8;
		Suit = suit.Spades;
	}
}
#endregion
#region Nines
public interface INine{ }
public class NineOfDiamonds : PlayingCard, INine
{
	public NineOfDiamonds()
	{
		Name = "Nine of Diamonds";
		shortName = "9d";
		Value = 9;
		Suit = suit.Diamonds;
	}
}

public class NineOfClubs : PlayingCard, INine
{
	public NineOfClubs()
	{
		Name = "Nine of Clubs";
		shortName = "9c";
		Value = 9;
		Suit = suit.Clubs;
	}
}

public class NineOfHearts : PlayingCard, INine
{
	public NineOfHearts()
	{
		Name = "Nine of Hearts";
		shortName = "9h";
		Value = 9;
		Suit = suit.Hearts;
	}
}

public class NineOfSpades : PlayingCard, INine
{
	public NineOfSpades()
	{
		Name = "Nine of Spades";
		shortName = "9s";
		Value = 9;
		Suit = suit.Spades;
	}
}
#endregion
#region Tens
public interface ITen { }
public class TenOfDiamonds : PlayingCard, ITen
{
	public TenOfDiamonds()
	{
		Name = "Ten of Diamonds";
		shortName = "10d";
		Value = 10;
		Suit = suit.Diamonds;
	}
}

public class TenOfClubs : PlayingCard, ITen
{
	public TenOfClubs()
	{
		Name = "Ten of Clubs";
		shortName = "10c";
		Value = 10;
		Suit = suit.Clubs;
	}
}

public class TenOfHearts : PlayingCard, ITen
{
	public TenOfHearts()
	{
		Name = "Ten of Hearts";
		shortName = "10h";
		Value = 10;
		Suit = suit.Hearts;
	}
}

public class TenOfSpades : PlayingCard, ITen
{
	public TenOfSpades()
	{
		Name = "Ten of Spades";
		shortName = "10s";
		Value = 10;
		Suit = suit.Spades;
	}
}
#endregion
#region Jacks
public interface IJack { }
public class JackOfDiamonds : PlayingCard, IJack
{
	public JackOfDiamonds()
	{
		Name = "Jack of Diamonds";
		shortName = "Jd";
		Value = 10;
		Suit = suit.Diamonds;
	}
}

public class JackOfClubs : PlayingCard, IJack
{
	public JackOfClubs()
	{
		Name = "Jack of Clubs";
		shortName = "Jc";
		Value = 10;
		Suit = suit.Clubs;
	}
}

public class JackOfHearts : PlayingCard, IJack
{
	public JackOfHearts()
	{
		Name = "Jack of Hearts";
		shortName = "Jh";
		Value = 10;
		Suit = suit.Hearts;
	}
}

public class JackOfSpades : PlayingCard, IJack
{
	public JackOfSpades()
	{
		Name = "Jack of Spades";
		shortName = "Js";
		Value = 10;
		Suit = suit.Spades;
	}
}
#endregion
#region Queens
public interface IQueen{ }
public class QueenOfDiamonds : PlayingCard, IQueen
{
	public QueenOfDiamonds()
	{
		Name = "Queen of Diamonds";
		shortName = "Qd";
		Value = 10;
		Suit = suit.Diamonds;
	}
}

public class QueenOfClubs : PlayingCard, IQueen
{
	public QueenOfClubs()
	{
		Name = "Queen of Clubs";
		shortName = "Qc";
		Value = 10;
		Suit = suit.Clubs;
	}
}

public class QueenOfHearts : PlayingCard, IQueen
{
	public QueenOfHearts()
	{
		Name = "Queen of Hearts";
		shortName = "Qh";
		Value = 10;
		Suit = suit.Hearts;
	}
}

public class QueenOfSpades : PlayingCard, IQueen
{
	public QueenOfSpades()
	{
		Name = "Queen of Spades";
		shortName = "Qs";
		Value = 10;
		Suit = suit.Spades;
	}
}
#endregion
#region Kings
public interface IKing{ }
public class KingOfDiamonds : PlayingCard, IKing
{
	public KingOfDiamonds()
	{
		Name = "King of Diamonds";
		shortName = "Kd";
		Value = 10;
		Suit = suit.Diamonds;
	}
}

public class KingOfClubs : PlayingCard, IKing
{
	public KingOfClubs()
	{
		Name = "King of Clubs";
		shortName = "Kc";
		Value = 10;
		Suit = suit.Clubs;
	}
}

public class KingOfHearts : PlayingCard, IKing
{
	public KingOfHearts()
	{
		Name = "King of Hearts";
		shortName = "Kh";
		Value = 10;
		Suit = suit.Hearts;
	}
}

public class KingOfSpades : PlayingCard, IKing
{
	public KingOfSpades()
	{
		Name = "King of Spades";
		shortName = "Ks";
		Value = 10;
		Suit = suit.Spades;
	}
}
#endregion
#endregion