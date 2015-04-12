using System;
using dtlibcode;

namespace dtt_testing
{
	public class TestGameRound : GameRound
	{
		private int numTurns = 0;
		public event Func<GameRound, bool> OnEndOfRound;

		public TestGameRound() : base(CreateGameTurn)
		{
		}

		public override GameTurn BeginGameTurn(Player player)
		{
			return base.BeginGameTurn(player);
		}

		public override GameTurn FinishGameTurn(GameTurn lastTurn)
		{
			numTurns++;
			return base.FinishGameTurn(lastTurn);
		}

		public override bool IsRoundComplete 
		{
			get 
			{
				if(OnEndOfRound == null)
				{
					return numTurns > 1;
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

