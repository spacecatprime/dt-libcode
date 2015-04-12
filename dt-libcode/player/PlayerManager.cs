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

		public virtual Player FirstPlayer
		{
			get { return m_playerList[0]; }
		}

		public virtual Player NextPlayer(Player lastPlayer)
		{
			int idx = m_playerList.IndexOf(lastPlayer);
			if(m_playerList.Count == (idx - 1))
			{
				return null;
			}
			return m_playerList[idx + 1];
		}

		public bool LoginPlayer(Player player)
		{
			if(m_playerList.Contains(player) == false)
			{
				m_playerList.Add (player);
				GameMessages.Emit(GameMessages.Kind.PlayerLogin, player);

				if(m_playerList.Count == 1)
				{
					GameMessages.Emit(GameMessages.Kind.AssignHost, player);
				}
				return true;
			}
			return false;
		}

		public bool LogoutPlayer(Player player)
		{
			if(m_playerList.Remove(player))
			{
				GameMessages.Emit(GameMessages.Kind.PlayerLogout, player);
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
