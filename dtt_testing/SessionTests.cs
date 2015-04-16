using NUnit.Framework;
using System;
using dtlibcode;

namespace dtt_testing
{
	[TestFixture()]
	public class SessionTests
	{
		[Test()]
		public void CleanTest()
		{
			// find players
			PlayerManager playerManager = new PlayerManager();
			playerManager.LoginPlayer(new PlayerContestant());
			playerManager.LoginPlayer(new PlayerContestant());

			// choose a scenario
			TestScenario scenario = new TestScenario(new PlayerRoundList(playerManager));

			// set up scenario
			GameSetup setup = scenario.CreateSetup();
			var options = setup.CreateOptions();
			options["team"] = "red";
			setup.SetOptionsFor(playerManager.GetPlayers()[0], options);
			options = setup.CreateOptions();
			options["team"] = "blue";
			setup.SetOptionsFor(playerManager.GetPlayers()[1], options);

			// start game session with this setup
			GameSession gs = new GameSession(scenario, setup, playerManager);
			gs.StartGame();
		}

		[Test()]
		public void LoggingInOutPlayers()
		{
			// find players
			PlayerManager playerManager = new PlayerManager();
			playerManager.LoginPlayer(new PlayerContestant());
			playerManager.LoginPlayer(new PlayerContestant());

			// choose a scenario
			TestScenario scenario = new TestScenario(new PlayerRoundList(playerManager));

			// set up scenario
			GameSetup setup = scenario.CreateSetup();
			var options = setup.CreateOptions();
			options["team"] = "red";
			setup.SetOptionsFor(playerManager.GetPlayers()[0], options);
			options = setup.CreateOptions();
			options["team"] = "blue";
			setup.SetOptionsFor(playerManager.GetPlayers()[1], options);

			// start game session with this setup
			GameSession gs = new GameSession(scenario, setup, playerManager);
//			Assert.AreEqual(gs.Progress(), true);

			playerManager.LogoutPlayer(playerManager.GetPlayers()[0]);
			playerManager.LogoutPlayer(playerManager.GetPlayers()[0]);
			Assert.AreEqual(playerManager.GetPlayers().Count, 0);
		}

		[Test()]
		public void RunAFewTurns()
		{
			PlayerManager pm;
			GameSession gs;
			Create(out pm, out gs);

			for(int i = 0; i < 5; i++)
			{
//				Assert.AreEqual(gs.Progress(), true);
			}
		}

		private void Create(out PlayerManager pm, out GameSession gs)
		{
			// find players
			PlayerManager playerManager = new PlayerManager();
			playerManager.LoginPlayer(new PlayerContestant());
			playerManager.LoginPlayer(new PlayerContestant());

			// choose a scenario
			TestScenario scenario = new TestScenario(new PlayerRoundList(playerManager));

			// set up scenario
			GameSetup setup = scenario.CreateSetup();
			var options = setup.CreateOptions();
			options["team"] = "red";
			setup.SetOptionsFor(playerManager.GetPlayers()[0], options);

			options = setup.CreateOptions();
			options["team"] = "blue";
			setup.SetOptionsFor(playerManager.GetPlayers()[1], options);

			pm = playerManager;
			gs = new GameSession(scenario, setup, playerManager);
		}
	}
}

