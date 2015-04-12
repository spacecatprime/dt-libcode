using System;
using System.Collections.Generic;

namespace dtlibcode
{
	public abstract class GameScenario
	{
		private String m_name;
		private Func<GameRound,GameRound> m_gameRoundFactory;
		private PlayerRoundList m_playerRoundList;

		public GameState State { get; private set; }
		public List<GameRound> Rounds { get; private set; }
		public GameSession Session { get; set; }

		public GameScenario(string name, PlayerRoundList pmr, Func<GameRound, GameRound> gameRoundFactory)
		{
			m_playerRoundList = pmr;
			m_gameRoundFactory = gameRoundFactory;
			m_name = name;
			State = new GameState();
			Rounds = new List<GameRound>();
		}

		abstract public World StartWorld(GameSetup aSetup);

		abstract public GameSetup CreateSetup();

		abstract public bool AreObjectivesComplete();

		protected GameRound MakeRound(GameRound lastRound)
		{
			var round = m_gameRoundFactory.Invoke(lastRound);
			if(round != null)
			{
				round.FirstPlayer += m_playerRoundList.GetFirst;
				round.NextPlayer += m_playerRoundList.GetNext;
				Rounds.Add(round);
			}
			return round;
		}

		public virtual GameRound StartRound()
		{
			var rnd = MakeRound(null);
			GameMessages.Emit(GameMessages.Kind.RoundBegin, rnd);
			return rnd;
		}

		public virtual GameRound FinishRound(GameRound lastRound)
		{
			if(AreObjectivesComplete())
			{
				GameMessages.Emit(GameMessages.Kind.GameObjectivesComplete, this);
				return null;
			}
			var rnd = MakeRound(lastRound);
			GameMessages.Emit(GameMessages.Kind.RoundEnd, rnd);
			return rnd;
		}
	}
}

