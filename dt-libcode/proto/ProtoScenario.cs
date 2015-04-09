using System;

namespace dtlibcode
{
	public class ProtoScenario : GameScenario
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
				// TODO: need to close out a game some how
				return false; 
			}
		}

		public override GameSetup CreateSetup()
		{
			return new ProtoGameSetup();
		}
	}
}

