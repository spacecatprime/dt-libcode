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
			gs.GameScenario.
		}

		[Test()]
		public void SetupScenarioAndPlayFullGame()
		{
		}

		private void Create(out TestInput input, out PlayerManager pm, out GameSession gs, int numPlayers)
		{
			// choose a scenario
			TestScenario scenario = new TestScenario();

			// set up scenario
			GameSetup setup = scenario.CreateSetup();

			// find players
			PlayerManager playerManager = new PlayerManager();
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

