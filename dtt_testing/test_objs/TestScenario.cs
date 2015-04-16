using System;
using dtlibcode;

namespace dtt_testing
{
	public class TestScenario : GameScenario
	{
		private static int s_numPlayers = 0;
		private int m_numRounds = 0;
		private World m_world;
		public bool AllDone { get; set; }

		public TestScenario(PlayerRoundList pmr) : base("test-scenario", pmr, RoundFactory)
		{
			AllDone = false;
			s_numPlayers = 0;

			GameMessages.SetCallback<GameRound>(GameMessages.Kind.RoundEnd, delegate (GameRound gr) {
				m_numRounds++;
				if( m_numRounds > 10 )
				{
					AllDone = true;
				}
			});
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
			return AllDone;
		}

		public void SetupPlayerConfig(int playerIdx, GameSetup setup, Player player)
		{			
			s_numPlayers++;
			var options = setup.CreateOptions();
			options["team"] = ((playerIdx % 2) == 0) ? "red" : "blue";
			setup.SetOptionsFor(player, options);
		}

		private static GameRound RoundFactory(GameRound gr)
		{
			return new dtt_testing.TestGameRound(s_numPlayers);
		}
	}
}

