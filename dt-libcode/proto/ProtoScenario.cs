using System;

namespace dtlibcode
{
	public class ProtoScenario : Scenario
	{
		private World m_world;

		public ProtoScenario() : base("proto-scenario")
		{
		}

		public override World StartWorld(GameSetup aSetup)
		{
			m_world = new ProtoWorld();
			return m_world;
		}

		public override bool ObjectivesComplete
		{
			get 
			{ 
				return m_world.NumPlayers == 0; 
			}
		}

		public override GameSetup CreateSetup()
		{
			return new ProtoGameSetup();
		}
	}
}

