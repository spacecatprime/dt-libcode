using System;
using dtlibcode;

namespace dtt_testing
{
	public class TestGameTurn : GameTurn
	{
		public TestGameTurn(Player player) : base(player)
		{
		}

		protected override void OnTurnEnd()
		{
			// ping!
		}
	}
}

