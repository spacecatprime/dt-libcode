using System;

namespace dtlibcode
{
	public class PlayerRoundList
	{
		private PlayerManager m_pm;
		private Player m_lastPlayer;
				
		public PlayerRoundList(PlayerManager pm)
		{
			m_pm = pm;
		}

		public virtual Player GetFirst()
		{
			m_lastPlayer = m_pm.FirstPlayer;
			return m_lastPlayer;
		}

		public virtual Player GetNext(Player lp)
		{
			m_lastPlayer = m_pm.NextPlayer(m_lastPlayer);
			return m_lastPlayer;
		}
	}
}

