using System;
using System.Collections.Generic;

namespace dtlibcode
{
	/// <summary>
	/// represents a world setting of maps, figures, and other things for a game session
	/// </summary>
	public class World
	{
		public GameMap GameMap { get; protected set; }

		public World()
		{
		}

		public virtual void HandlePlayerLogin(Player player)
		{
		}

		public virtual void HandlePlayerLogout(Player player)
		{
		}

		public virtual void OnMapLoaded()
		{
			Messenger.Emit(GameMessages.Kind.WorldLoaded.ToString(), this);
		}
	}
}

