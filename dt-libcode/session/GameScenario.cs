using System;

namespace dtlibcode
{
	public abstract class GameScenario
	{
		String m_name;
		
		public GameScenario(string name)
		{
			m_name = name;
		}

		abstract public World StartWorld(GameSetup aSetup);

		abstract public bool ObjectivesComplete { get; }

		abstract public GameSetup CreateSetup();

		abstract public GameRound CreateFirstRound(PlayerManager pm);
	}
}

