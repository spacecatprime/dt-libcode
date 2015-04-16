using System;

namespace dtlibcode
{
	public class ProtoScenario : GameScenario
	{
		private static GameRound MakeGameRound(GameRound lr)
		{
			throw new NotImplementedException();
		}

		public ProtoScenario() : base("proto-scenario", null, MakeGameRound)
		{
		}

		public override World StartWorld(GameSetup aSetup)
		{
			throw new NotImplementedException();
		}

		public override GameSetup CreateSetup()
		{
			throw new NotImplementedException();
		}

		public override bool AreObjectivesComplete()
		{
			throw new NotImplementedException();
		}
	}
}

