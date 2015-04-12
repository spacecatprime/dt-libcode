using System;

namespace dtlibcode
{
	public abstract class GameTurn
	{
		public Player ActivePlayer { get; private set; }

		/// <summary>
		/// Represents a game turn for a certain playing participant
		/// </summary>
		public GameTurn(Player player)
		{
			ActivePlayer = player;
			DoTurnBegin();
		}

		public virtual void DoTurnBegin()
		{
		}

		public virtual void DoTurnStep()
		{
			GameMessages.Emit<GameTurn>(GameMessages.Kind.TurnStep, this);
		}

		public virtual void DoTurnEnd()
		{
			OnTurnEnd();
		}

		protected abstract void OnTurnEnd();
	}
}

