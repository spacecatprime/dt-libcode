using System;
using dtlibcode;

namespace dtt_testing
{
	public class TestScenario : GameScenario
	{
		private World m_world;
		public bool GameAlive { get; set; }

		public TestScenario(PlayerRoundList pmr) : base("test-scenario", pmr, RoundFactory)
		{
			GameAlive = true;
		}

		public override World StartWorld(GameSetup aSetup)
		{
			m_world = new TestWorld();
			return m_world;
		}

		public override GameSetup CreateSetup()
		{
			return new TestGameSetup();
		}

		public override bool AreObjectivesComplete()
		{
			return GameAlive;
		}

		public void SetupPlayerConfig(int playerIdx, GameSetup setup, Player player)
		{			
			var options = setup.CreateOptions();
			options["team"] = ((playerIdx % 2) == 0) ? "red" : "blue";
			setup.SetOptionsFor(player, options);
		}

		private static GameRound RoundFactory(GameRound gr)
		{
			return new dtt_testing.TestGameRound();
		}
	}
}

