using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace dtlibcode
{
	/// <summary>
	/// represents a series of game turns until the game session ends:
	/// 	each participant gets a game turn
	///     at the start of each round, the avaiable players are determined
	/// </summary>
	public abstract class GameRound
	{
		/// <summary>
		/// Starts the first turn.
		/// </summary>
		/// <returns>The first turn.</returns>
		public abstract GameTurn StartFirstTurn();

		/// <summary>
		/// Starts the next turn.
		/// </summary>
		/// <returns>The next turn.</returns>
		/// <param name="lastTurn">Last turn.</param>
		public abstract GameTurn StartNextTurn(GameTurn lastTurn);

		/// <summary>
		/// Ends the of round.
		/// </summary>
		/// <returns><c>true</c>, if of round was ended, <c>false</c> otherwise.</returns>
		public abstract bool EndOfRound();

		private List<GameTurn> m_turns = new List<GameTurn>();

		protected Func<Player,GameTurn> m_gameTurnFactory;
		protected PlayerManager m_playerManager;

		public ReadOnlyCollection<GameTurn> Turns { get { return m_turns.AsReadOnly(); } }

		public GameRound(PlayerManager playerManager, Func<Player,GameTurn> gameTurnFactory)
		{
			m_playerManager = playerManager;
			m_gameTurnFactory = gameTurnFactory;
		}
	}
}

