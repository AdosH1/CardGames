using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace PlayingCards
{
	public class Player
	{
		public List<ICard> _hand;
		public bool isRobot;
		public bool inGame;
		public string Action { get; set; }
		public string Name { get; set; }
		public ConsoleColor TextColor;
		public List<string> Descriptives = new List<string> {"Iron", "Fiery", "Dark", "Calm", "Mysterious", "Delirious", "Flustered", "Grim", "Gregarious", "Kooky", "Quirky", "Timid", "Playful", "Broken", "Bruised", "Salty", "Silver", "Nefarious"};
		public List<string> Nouns = new List<string> {"Devil", "Demon", "Imp", "Angel", "Reaper", "Fisherman", "Whale", "Rabbit", "Scientist", "Robot", "Polygon", "Knight", "Squire", "Prince", "Cheat"};
		public List<ConsoleColor> TextColors = new List<ConsoleColor> {ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkGray, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed};
		private static readonly Random rnd = new Random(DateTime.Now.Millisecond);

		public int HandValue
		{
			get
			{
				int i = 0;
				foreach (PlayingCard card in _hand.OfType<PlayingCard>())
				{
					i += card.Value;
				}
				return i;
			}
		}
		public double Score { get; set; }

		public Player(bool isAi = false, string name = "")
		{
			_hand = new List<ICard>();
			Score = 0;
			isRobot = isAi;
			inGame = true;

			if (isRobot)
			{
				GenerateName(out name);
				Name = name;
			}
			else
			{ Name = name; }
			int txtColor = rnd.Next(0, TextColors.Count);
			TextColor = TextColors[txtColor];
			TextColors.Remove(TextColors[txtColor]);
		}

		public void Add(ICard card)
		{
			_hand.Add(card);
		}

		public void Remove(ICard card)
		{
			_hand.Remove(card);
		}

		public void DiscardHand()
		{
			_hand.RemoveAll(x => x is ICard);
		}

		public void GenerateName(out string Name)
		{
			int rD = rnd.Next(0, Descriptives.Count);
			int rN = rnd.Next(0, Nouns.Count);

			Name = $"{Descriptives[rD]} {Nouns[rN]}";
			Descriptives.Remove(Descriptives[rD]);
			Nouns.Remove(Nouns[rN]);
		}
	}
}