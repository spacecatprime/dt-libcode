using System;

namespace dtlibcode
{
	public class TestScenario : GameScenario
	{
		private World m_world;

		public bool GameAlive { get; set; }

		public TestScenario() : base("test-scenario")
		{
			GameAlive = true;
		}

		public override World StartWorld(GameSetup aSetup)
		{
			m_world = new TestWorld();
			return m_world;
		}

		public override bool ObjectivesComplete
		{
			get 
			{ 
				return GameAlive; 
			}
		}

		public override GameSetup CreateSetup()
		{
			return new TestGameSetup();
		}

		public void SetupPlayerConfig(int playerIdx, GameSetup setup, Player player)
		{			
			var options = setup.CreateOptions();
			options["team"] = ((playerIdx % 2) == 0) ? "red" : "blue";
			setup.SetOptionsFor(player, options);
		}
	}
}

