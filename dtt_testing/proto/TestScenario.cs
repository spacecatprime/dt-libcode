using System;

namespace dtlibcode
{
	public class TestScenario : Scenario
	{
		private World m_world;

		public TestScenario() : base("test-scenario")
		{
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
				return m_world.NumPlayers != 0; 
			}
		}

		public override GameSetup CreateSetup()
		{
			return new TestGameSetup();
		}
	}
}

