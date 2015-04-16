using System;
using System.Linq;

namespace dtlibcode
{
	/// <summary>
	/// Create a game session once the player group, game setup, and scenario are chosen
	/// </summary>
	public class GameSession
	{
		public GameScenario GameScenario { get; private set; }
		public World GameWorld { get; private set; }
		public PlayerManager PlayerMgr { get; private set; }

		public GameSession(GameScenario scenario, GameSetup setup, PlayerManager playerManager)
		{
			// data
			GameScenario = scenario;
			GameWorld = scenario.StartWorld(setup);
			PlayerMgr = playerManager;
			GameScenario.Session = this; // TODO: could this be done better?
			//GameSession.

			// hooks
			GameMessages.SetCallback<Player>(GameMessages.Kind.PlayerLogin, LoginPlayer);
			GameMessages.SetCallback<Player>(GameMessages.Kind.PlayerLogout, LogoutPlayer);

			// add current players to world
			foreach(var p in playerManager.GetPlayers())
			{
				LoginPlayer(p);
			}
		}

		public virtual void StartGame()
		{
			GameMessages.Emit(GameMessages.Kind.GameBegin, this);
		}

		public virtual void FinishGame()
		{
			GameMessages.Emit(GameMessages.Kind.GameEnd, this);
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
