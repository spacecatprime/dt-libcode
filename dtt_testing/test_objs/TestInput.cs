using System;
using dtlibcode;

namespace dtt_testing
{
	/// <summary>
	/// pretends to be a set of input devices for test
	/// </summary>
	public class TestInput
	{
		public int GameCount { get; set; }
		public int RoundCount { get; set; }
		public int TurnCount { get; set; }
		
		public TestInput()
		{
			GameMessages.SetCallback<GameSession>(GameMessages.Kind.GameBegin, delegate (GameSession s) 
			{
				GameCount++;
			});
			GameMessages.SetCallback<GameSession>(GameMessages.Kind.GameEnd, delegate (GameSession s) 
			{
				GameCount--;
			});

			GameMessages.SetCallback<GameRound>(GameMessages.Kind.RoundBegin, delegate (GameRound gr) 
			{
				RoundCount++;
			});
			GameMessages.SetCallback<GameRound>(GameMessages.Kind.RoundEnd, delegate (GameRound gr) 
			{
				RoundCount--;
			});

			GameMessages.SetCallback<GameTurn>(GameMessages.Kind.TurnBegin, delegate (GameTurn gr) 
			{
				TurnCount++;
			});
			GameMessages.SetCallback<GameTurn>(GameMessages.Kind.TurnEnd, delegate (GameTurn gr) 
			{
				TurnCount--;
			});
		}
	}
}

