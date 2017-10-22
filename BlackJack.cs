using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards;

namespace BlackJackGame
{
    public class BlackJack
    {
	    private static bool busted;

        static void Main(string[] args)
        {
			Console.WriteLine("Welcome to BlackJack!\nThis is a small project of mine to practice software architecture and C#\nPlease enjoy! - Aden Huen.\n");

			Console.Write("Name: ");
	        var name = Console.ReadLine();
	        Console.Write("Number of Opponents: ");
			var numAi = Console.ReadLine();
	        bool parseNumAi = int.TryParse(numAi, out int ai);
	        if (!parseNumAi)
	        {
		        ai = 1;
		        Console.WriteLine("Error parsing number: Defaulting to 1 opponent.");
	        }
	        Console.Write("Points to win: ");
	        var numPoints = Console.ReadLine();
	        bool parseNumPts = int.TryParse(numPoints, out int numPts);
	        if (!parseNumPts)
	        {
		        numPts = 3;
				Console.WriteLine("Error parsing number: Defaulting to 3 points.");
			}

			InitialiseGame(out Deck d, out List<Player> pList, out bool GameOver, out bool RoundOver, name, ai);
			while (true)
	        {
		        while (!GameOver)
		        {
			        CheckGameOver(pList, out GameOver, numPts);
			        if (!GameOver) InitialiseRound(d, pList, out RoundOver);
					while (!RoundOver)
			        {
				        foreach (Player p in pList)
				        {
					        if (!p.inGame) continue;

							/* Execute current player's turn */
						    if (p.isRobot) busted = RobotTurn(d, p);
						    else busted = HumanTurn(d, p);

							/* Eliminate busted players */
						    if (busted)
						    {
							    p.inGame = false;
							    Console.WriteLine($"{p.Name} has busted({p.HandValue})!");
						    }

				        }
						/* Check if everyone has kept */
				        var hasKept = hasEveryoneKept(pList);
						/* Count the number of players remaining in round */
				        var numPlayers = pList.Count(x => x.inGame);

				        if (hasKept || numPlayers <= 1)
				        {
					        EndRound(pList, out RoundOver);
				        }
			        } // RoundOver loop

		        } // GameOver loop

				DeclareGameWinner(pList, numPts);
		        bool restart = RestartGame(pList, out GameOver);
		        if (restart)
		        {
					// Reset scores, initialise round.
			        foreach (Player p in pList)
			        { p.Score = 0; }
			        InitialiseRound(d, pList, out RoundOver);
		        }
				else if (!restart) break;

			} // Forever game loop

        }

		/// <summary>
		/// Creates the deck of cards, generates players / ai in game.
		/// </summary>
		/// <param name="d">Deck</param>
		/// <param name="pList">List of players</param>
		/// <param name="GameOver"></param>
		/// <param name="RoundOver"></param>
		/// <param name="playerName">Name of human player</param>
		/// <param name="numAI">Number of AI opponents to create</param>
	    public static void InitialiseGame(out Deck d, out List<Player> pList, out bool GameOver, out bool RoundOver, string playerName = "Ados", int numAI = 1)
	    {
			d = new Deck();
		    Player P = new Player(false, playerName);

			pList = new List<Player>();
			pList.Add(P);

		    for (int i = 0; i < numAI; ++i)
		    {
			    pList.Add(new Player(true));
		    }

		    GameOver = false;
		    RoundOver = false;
		}

		/// <summary>
		/// Allows (human)player to HIT or KEEP their cards.
		/// </summary>
		/// <param name="d">Deck d</param>
		/// <param name="p">Player p</param>
		/// <returns>
		/// True: Player busted.
		/// False: Player has HIT or KEPT, and has not busted.
		/// </returns>
	    public static bool HumanTurn(Deck d, Player p)
	    {
		    string input;

		    Console.WriteLine("\nHand: ");
		    foreach (PlayingCard c in p._hand)
		    {
			    Console.WriteLine($"{c.Name}");
		    }
		    Console.WriteLine($"Total: {p.HandValue}\n");

			Console.Write("Hit or keep? ");

		    while (true)
		    {
			    input = Console.ReadLine();
				if (input.ToLower() == "hit" || input.ToLower() == "hit me" || input.ToLower() == "h")
			    {
				    d.DealCard(p);
				    var card = p._hand.Last() as PlayingCard;
				    Console.ForegroundColor = p.TextColor;
					Console.WriteLine($"{p.Name} drew {card.Name}.");
					Console.ResetColor();
				    p.Action = "hit";
				    return IsBusted(p);
			    }
			    if (input.ToLower() == "keep" || input.ToLower() == "pass" || input.ToLower() == "k")
			    {
				    Console.ForegroundColor = p.TextColor;
				    Console.WriteLine($"{p.Name} has KEPT.");
				    Console.ResetColor();
					p.Action = "keep";
				    return false;
			    }
		    }

	    }

		/// <summary>
		/// Allows (robot)player to effective HIT or KEEP their cards.
		/// </summary>
		/// <param name="d">Deck d</param>
		/// <param name="p">Player p</param>
		/// <returns>
		/// True: Player is busted.
		/// False: Player has HIT or KEPT, and has not busted.
		/// </returns>
	    public static bool RobotTurn(Deck d, Player p)
	    {
		    if (p.HandValue < 17)
		    {
			    d.DealCard(p);
			    Console.ForegroundColor = p.TextColor;
				Console.WriteLine($"{p.Name} has HIT({p._hand.Count} cards).");
				Console.ResetColor();
			    p.Action = "hit";
			    return IsBusted(p);
		    }
		    Console.ForegroundColor = p.TextColor;
			Console.WriteLine($"{p.Name} has KEPT({p._hand.Count} cards).");
			Console.ResetColor();
		    p.Action = "keep";
			return false;
	    }

		/// <summary>
		/// Checks if a player's hand is busted.
		/// Attempts to change Ace value to 1 if busted.
		/// </summary>
		/// <param name="p">Subject player p</param>
		/// <returns>
		/// True: If busted and all aces set to value 1.
		/// False: Not busted.
		/// </returns>
	    public static bool IsBusted(Player p)
	    {
		    if (p.HandValue > 21)
		    {
			    var Ace = p._hand.Where(x => x is IAce);
			    if (Ace.Any())
			    {
				    foreach (var a in Ace)
				    {
					    var A = (PlayingCard) a;
					    if (A.Value == 11)
					    {
						    A.Value = 1;
						    if (p.HandValue <= 21) return false;
					    }
				    }

				    return true;
			    }
				return true;
		    }
		    return false;
	    }

		/// <summary>
		/// Evaluates all players in a list and determines if they are still in-game, and have kept.
		/// </summary>
		/// <param name="pList">A list of all players currently in-game.</param>
		/// <returns></returns>
	    public static List<Player> EvaluateRound(List<Player> pList)
	    {
		    var pl = pList.Where(x => x.inGame);
			List<Player> winnerList = new List<Player>();
		    int maxValue = int.MinValue;

			foreach (Player p in pl)
			{
				if (p.HandValue > maxValue && p.HandValue <= 21)
				{
					maxValue = p.HandValue;
					winnerList.RemoveAll(x => x is Player);
					winnerList.Add(p);
				}
				else if (p.HandValue == maxValue && p.HandValue <= 21)
				{
					winnerList.Add(p);
				}
			}

		    return winnerList;
	    }

		/// <summary>
		/// Checks if everyone has decided to KEEP.
		/// </summary>
		/// <param name="pList">List of all players in game.</param>
		/// <returns>
		/// True: Everyone decided to KEEP.
		/// False: Someone has HIT.
		/// </returns>
	    public static bool hasEveryoneKept(List<Player> pList)
	    {
		    var pl = pList.Where(x => x.inGame);
		    var listCount = pl.Count();
		    if (pl.Count(x => x.Action == "keep") == listCount)
		    {
			    return true;
		    }
		    return false;
	    }

		/// <summary>
		/// Function to annouce winners of previous round.
		/// </summary>
		/// <param name="winners">List of winners</param>
		/// <param name="pList">List of players</param>
	    public static void DeclareWinner(List<Player> winners, List<Player> pList)
	    {
			Console.WriteLine("------------------------------------------------------------");
		    if (winners.Count > 1)
		    {
			    Console.Write("Draw!! Between ");
			    foreach (Player p in winners)
			    {
				    Console.ForegroundColor = p.TextColor;
				    Console.Write($"{p.Name}({p.HandValue}) ");
					Console.ResetColor();
			    }
			    Console.WriteLine("\nHalf point awards to all winners!");
			}
			else if (winners.Count == 1)
		    {
			    Console.WriteLine($"The winner is... {winners[0].Name}({winners[0].HandValue})!");
			    foreach (Player p in pList)
			    {
				    if (p.Name != winners[0].Name)
				    {
					    Console.ForegroundColor = p.TextColor;
						Console.WriteLine($"{p.Name}({p.HandValue})");
						Console.ResetColor();
				    }
			    }
		    }
		    else
		    {
				Console.WriteLine("No winners!!");
			    foreach (Player p in pList)
			    {
					Console.WriteLine($"{p.Name}({p.HandValue})");
			    }
			}

			Console.Write($"Current score: | ");
		    foreach (Player p in pList)
		    {
			    Console.Write($" {p.Name} {p.Score} |");
		    }
			Console.WriteLine();
		    Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine();
		}

		/// <summary>
		/// Rewards players points based on end of round score.
		/// Win: 1 point, Draw(multiple winners): 0.5 points each.
		/// </summary>
		/// <param name="winners"></param>
	    public static void RewardPoints(List<Player> winners)
	    {
		    if (winners.Count == 1)
		    {
			    winners[0].Score += 1;
		    }
			else if (winners.Count > 1)
		    {
			    foreach (Player p in winners)
			    {
				    p.Score += 0.5;
			    }
		    }
	    }

		/// <summary>
		/// End the round, evaluate winners and reward points.
		/// </summary>
		/// <param name="pList"></param>
	    public static void EndRound(List<Player> pList, out bool RoundOver)
	    {
		    var winners = EvaluateRound(pList);
		    RewardPoints(winners);
		    DeclareWinner(winners, pList);
		    RoundOver = true;
	    }

	    public static void InitialiseRound(Deck d, List<Player> pList, out bool RoundOver)
	    {
		    RoundOver = false;
			d = new Deck();
		    foreach (Player p in pList)
		    {
			    p.DiscardHand();
			    p.inGame = true;
			    d.DealCard(p, 2);
		    }
	    }

	    public static void CheckGameOver(List<Player> pList, out bool GameOver, int numPts)
	    {
		    var count = pList.Count(x => x.Score >= numPts);
		    GameOver = (count >= 1);
	    }

	    public static void DeclareGameWinner(List<Player> pList, int numPts)
	    {
		    var winners = pList.Where(x => x.Score >= numPts);
		    if (winners.Count() > 1)
		    {
			    Console.Write("The winners are...");
			    foreach (Player p in winners)
			    {
				    Console.Write($"{p.Name}({p.Score}) ");
			    }
		    }
			else if (winners.Count() == 1)
		    {
			    var winner = winners.First();
			    Console.WriteLine($"The winner is... {winner.Name}({winner.Score})");
		    }
		    else
		    {
				Console.WriteLine("Something has gone terribly wrong... there are no winners!!");
		    }
	    }

	    public static bool RestartGame(List<Player> pList, out bool GameOver)
	    {
		    Console.Write("\nAnother game? ");
		    while (true)
		    {
			    var input = Console.ReadLine();
			    if (input.ToLower() == "yes" || input.ToLower() == "y" || input.ToLower() == "please")
			    {
				    GameOver = false;
				    return true;
			    }
				if (input.ToLower() == "no" || input.ToLower() == "n" || input.ToLower() == "fuck off")
				{
					GameOver = true;
					return false;
				}
			}

	    }
	}
}