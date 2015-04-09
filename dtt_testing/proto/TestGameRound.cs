using System;
using dtlibcode;

namespace dtt_testing
{
	public class TestGameRound : GameRound
	{
		public event Func<GameRound, bool> OnEndOfRound;

		public TestGameRound(PlayerManager playerManager) : base(playerManager, CreateGameTurn)
		{
		}

		public override GameTurn StartFirstTurn()
		{
			return m_gameTurnFactory.Invoke(null);
		}

		public override GameTurn StartNextTurn(GameTurn lastTurn)
		{
			return m_gameTurnFactory.Invoke(null);
		}

		public override bool EndOfRound()
		{
			if(OnEndOfRound != null)
			{
				return OnEndOfRound(this);
			}			
			return true;
		}

		private static GameTurn CreateGameTurn(Player p)
		{
			return new GameTurn(p);
		}
	}
}

