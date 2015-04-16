using System;
using dtlibcode;

namespace dtt_testing
{
	public class TestGameRound : GameRound
	{
		private int m_numTurns = 0;
		private int m_uptoTurns = 2;
		public event Func<GameRound, bool> OnEndOfRound;

		public TestGameRound(int uptoTurns) : base(CreateGameTurn)
		{
			m_uptoTurns = uptoTurns;
		}

		public override GameTurn BeginGameTurn(Player player)
		{
			return base.BeginGameTurn(player);
		}

		public override GameTurn FinishGameTurn(GameTurn lastTurn)
		{
			m_numTurns++;
			return base.FinishGameTurn(lastTurn);
		}

		public override bool IsRoundComplete 
		{
			get 
			{
				if(OnEndOfRound == null)
				{
					return m_numTurns >= m_uptoTurns;
				}				
				return OnEndOfRound(this);
			}
		}

		private static GameTurn CreateGameTurn(Player player, GameRound gameRound, GameTurn lastTurn)
		{
			return new TestGameTurn(player);
		}
	}
}

