using System;
using dtlibcode;
using NUnit.Framework;

namespace dtt_testing
{
	/// <summary>
	/// pretends to be a set of input devices for test
	/// </summary>
	public class TestInput
	{
		public int GameCount { get; set; }
		public int GameTotal { get; set; }

		public int RoundCount { get; set; }
		public int RoundTotal { get; set; }

		public int TurnCount { get; set; }
		public int TurnTotal { get; set; }

		GameSession lastGameSession;
		GameRound lastRound;
		GameTurn lastTurn;

		public TestInput()
		{
			GameMessages.SetCallback<GameSession>(GameMessages.Kind.GameBegin, delegate (GameSession s) 
			{
				GameTotal++;
				GameCount++;
				lastGameSession = s;
			});
			GameMessages.SetCallback<GameSession>(GameMessages.Kind.GameEnd, delegate (GameSession s) 
			{
				GameCount--;
				Assert.AreEqual(lastGameSession, s);
			});

			GameMessages.SetCallback<GameRound>(GameMessages.Kind.RoundBegin, delegate (GameRound gr) 
			{
				lastRound = gr;
				RoundCount++;
				RoundTotal++;
			});
			GameMessages.SetCallback<GameRound>(GameMessages.Kind.RoundEnd, delegate (GameRound gr) 
			{
				Assert.AreEqual(gr, lastRound);
				RoundCount--;
			});

			GameMessages.SetCallback<GameTurn>(GameMessages.Kind.TurnBegin, delegate (GameTurn turn) 
			{
				lastTurn = turn;
				TurnCount++;
				TurnTotal++;
			});
			GameMessages.SetCallback<GameTurn>(GameMessages.Kind.TurnEnd, delegate (GameTurn turn) 
			{
				Assert.AreEqual(turn, lastTurn);
				TurnCount--;
			});
		}
	}
}

