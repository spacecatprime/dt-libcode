using System;
using System.Linq;

namespace dtlibcode
{
	/// <summary>
	/// Create a game session once the player group, game setup, and scenario are chosen
	/// </summary>
	public class GameSession
	{
		public Scenario GameScenario { get; private set; }
		public World GameWorld { get; private set; }
		public PlayerManager PlayerMgr { get; private set; }
		public GameState State { get; private set; }

		public GameSession(Scenario scenario, GameSetup setup, PlayerManager playerManager)
		{
			// data
			GameScenario = scenario;
			GameWorld = scenario.StartWorld(setup);
			PlayerMgr = playerManager;
			GameState = new GameState();

			// hooks
			Messenger.AddListener<Player>("LoginPlayer", LoginPlayer);
			Messenger.AddListener<Player>("LogoutPlayer", LogoutPlayer);

			// add current players to world
			foreach(var p in playerManager.GetPlayers())
			{
				LoginPlayer(p);
			}
		}

		public virtual void StartGame()
		{
			Messenger.Emit("StartGame", this);
		}

		public bool Progress()
		{
			return GameScenario.ObjectivesComplete;
		}

		private void LoginPlayer(Player p)
		{
			GameWorld.HandlePlayerLogin(p);
		}

		private void LogoutPlayer(Player p)
		{
			GameWorld.HandlePlayerLogout(p);
		}
	}
}
