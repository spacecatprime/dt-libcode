using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace dtlibcode
{
	/// <summary>
	/// handles the logged in player into a game session
	/// </summary>
	public class PlayerManager
	{
		private List<Player> m_playerList = new List<Player>();

		public PlayerManager ()
		{
		}

		public bool LoginPlayer(Player player)
		{
			if(m_playerList.Contains(player) == false)
			{
				m_playerList.Add (player);
				dtlibcode.Messenger.Emit("LoginPlayer", player);

				if(m_playerList.Count == 1)
				{
					dtlibcode.Messenger.Emit("AssignHost", player);
				}
				return true;
			}
			return false;
		}

		public bool LogoutPlayer(Player player)
		{
			if(m_playerList.Remove(player))
			{
				dtlibcode.Messenger.Emit("LogoutPlayer", player);
				return true;
			}
			return false;
		}

		public void Clear()
		{
			m_playerList.Clear();
		}

		public ReadOnlyCollection<Player> GetPlayers()
		{
			return m_playerList.AsReadOnly();
		}
	}
}
