using NUnit.Framework;
using System;
using dtlibcode;

namespace dtt_testing
{
	[TestFixture()]
	public class PlayerTests
	{
		[Test()]
		public void PlayerTest()
		{
			dtlibcode.Player admin = new dtlibcode.PlayerAdmin();
			dtlibcode.Player contestant = new dtlibcode.PlayerContestant();
			dtlibcode.Player observer = new dtlibcode.PlayerObserver();
		}

		[Test()]
		public void PlayerManagerTest()
		{
			PlayerManager pm = new PlayerManager();
			pm.LoginPlayer(new dtlibcode.PlayerAdmin());
			pm.LoginPlayer(new dtlibcode.PlayerContestant());
			pm.LoginPlayer(new dtlibcode.PlayerContestant());
			pm.LoginPlayer(new dtlibcode.PlayerObserver());
			Assert.AreEqual(pm.GetPlayers().Count, 4);
			pm.LogoutPlayer(pm.GetPlayers()[0]);
			Assert.AreEqual(pm.GetPlayers().Count, 3);
			pm.Clear();
			Assert.AreEqual(pm.GetPlayers().Count, 0);
		}
	}
}

