using NUnit.Framework;
using System;
using dtlibcode;

namespace dtt_testing
{
	[TestFixture()]
	public class FullGameTests
	{
		[Test()]
		public void GameSetup()
		{
			TestInput input;
			PlayerManager pm;
			GameSession gs;
			Create(out input, out pm, out gs, 4);
		}

		[Test()]
		public void SetupScenarioAndPlayOneRound()
		{
			TestInput input;
			PlayerManager pm; 
			GameSession gs;
			Create(out input, out pm, out gs, 2);

			gs.StartGame();
			Assert.AreEqual(input.GameCount, 1);
			var rnd = gs.GameScenario.StartRound();
			Assert.AreEqual(input.RoundCount, 1);
			Assert.NotNull(rnd);
			var turn = rnd.BeginGameTurn(null);
			Assert.AreEqual(input.TurnCount, 1);
			Assert.NotNull(turn);
			rnd.FinishGameTurn(turn);
			gs.GameScenario.FinishRound(rnd);
			gs.FinishGame();
		}

		[Test()]
		public void SetupScenarioAndPlayFullGame()
		{
			TestInput input;
			PlayerManager pm; 
			GameSession gs;
			Create(out input, out pm, out gs, 2);

			GameRound rnd;
			GameTurn turn;

			gs.StartGame();
			do
			{
				rnd = gs.GameScenario.StartRound();
				turn = rnd.BeginGameTurn(null);
				while( turn != null)
				{
					turn = rnd.FinishGameTurn(turn);
				}
				rnd = gs.GameScenario.FinishRound(rnd);
			}
			while (gs.GameScenario.AreObjectivesComplete() == false);
			gs.FinishGame();
		}

		private void Create(out TestInput input, out PlayerManager pm, out GameSession gs, int numPlayers)
		{
			// first comes a player manager
			PlayerManager playerManager = new PlayerManager();

			// choose a scenario
			TestScenario scenario = new TestScenario(new PlayerRoundList(playerManager));

			// set up scenario
			GameSetup setup = scenario.CreateSetup();

			// find players
			for(int i = 0; i < numPlayers; ++i)
			{
				var player = new PlayerContestant();
				playerManager.LoginPlayer(player);
				scenario.SetupPlayerConfig(i, setup, player);
			}

			pm = playerManager;
			gs = new GameSession(scenario, setup, playerManager);
			input = new TestInput();
		}
	}
}

