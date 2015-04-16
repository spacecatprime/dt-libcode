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
		private List<GameTurn> m_turns = new List<GameTurn>();
		protected Func<Player, GameRound, GameTurn, GameTurn> m_gameTurnFactory;
		public ReadOnlyCollection<GameTurn> Turns { get { return m_turns.AsReadOnly(); } }

		public abstract bool IsRoundComplete { get; }
		public event Func<Player> FirstPlayer;
		public event Func<Player, Player> NextPlayer;

		public GameRound(Func<Player,GameRound,GameTurn,GameTurn> gameTurnFactory)
		{
			m_gameTurnFactory = gameTurnFactory;
		}

		protected GameTurn MakeTurn(Player player, GameTurn lastTurn)
		{
			var p = (player != null) ? player: FirstPlayer.Invoke();
			var turn = m_gameTurnFactory.Invoke(p, this, lastTurn);
			if(turn != null)
			{
				GameMessages.Emit(GameMessages.Kind.TurnBegin, turn);
				turn.DoTurnBegin();
				m_turns.Add(turn);
			}
			return turn;
		}

		public virtual GameTurn BeginGameTurn(Player player)
		{
			return MakeTurn(player, null);
		}

		public virtual GameTurn FinishGameTurn(GameTurn lastTurn)
		{
			if(IsRoundComplete)
			{
				return null;
			}
			GameMessages.Emit(GameMessages.Kind.TurnEnd, lastTurn);
			return BeginGameTurn(NextPlayer(lastTurn.ActivePlayer));
		}
	}
}

