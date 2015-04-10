using System;

namespace dtlibcode
{
	public class TestWorld : World
	{
		public int NumPlayers { get; set; }
		
		public TestWorld()
		{
			NumPlayers = 0;
		}

		public override void HandlePlayerLogin(Player player)
		{
			NumPlayers++;
			base.HandlePlayerLogin(player);
		}

		public override void HandlePlayerLogout(Player player)
		{
			NumPlayers--;
			base.HandlePlayerLogout(player);
		}
	}
}

