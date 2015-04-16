using System;

namespace dtlibcode
{
	/// <summary>
	/// The player's actions during a turn.
	/// </summary>
	public abstract class PlayerReport
	{
	}

	/// <summary>
	/// Player report null.
	/// </summary>
	public class PlayerReportNull : PlayerReport
	{
	}

	/// <summary>
	/// A user logged into a game session
	/// </summary>
	public abstract class Player
	{
		/// <summary>
		/// Gets a value indicating whether this instance is a participant.
		/// </summary>
		/// <value><c>true</c> if this instance is participant; otherwise, <c>false</c>.</value>
		public abstract bool IsParticipant { get; }

		/// <summary>
		/// Starts the turn.
		/// </summary>
		/// <param name="onTurnEnd">On turn end.</param>
		public abstract void StartTurn (Func<PlayerReport, bool> onTurnEnd);

		/// <summary>
		/// Determines whether this instance has access the specified thing.
		/// </summary>
		/// <returns><c>true</c> if this instance has access the specified thing; otherwise, <c>false</c>.</returns>
		/// <param name="thing">Thing.</param>
		public abstract bool HasAccess (GameThing thing);
	}

	/// <summary>
	/// When a game thing is created, it may not be assigned to anybody at first
	/// </summary>
	public class PlayerUnassigned : Player
	{
		public override bool IsParticipant { get { return false; } }

		public override void StartTurn (Func<PlayerReport, bool> onTurnEnd)
		{
			onTurnEnd.Invoke (new PlayerReportNull());
		}
		public override bool HasAccess (GameThing thing)
		{
			return false; // own nothing in the game session
		}
	}

	/// <summary>
	/// A player that can watch the action, but can not do anything
	/// </summary>
	public class PlayerObserver : Player
	{
		public override bool IsParticipant { get { return false; } }

		public override void StartTurn (Func<PlayerReport, bool> onTurnEnd)
		{
			// skip the observer's turn
			onTurnEnd.Invoke (new PlayerReportNull());
		}
		public override bool HasAccess (GameThing thing)
		{
			return false; // observers own nothing in the game session
		}
	}

	/// <summary>
	/// A logged in user that is participating in the contest
	/// </summary>
	public class PlayerContestant : Player
	{
		public override bool IsParticipant { get { return true; } }

		public override void StartTurn (Func<PlayerReport, bool> onTurnEnd)
		{
			onTurnEnd.Invoke (new PlayerReportNull());
		}
		public override bool HasAccess (GameThing thing)
		{
			return (thing.Owner == this);
		}
	}

	/// <summary>
	/// A super user that can modify game things that normal players can not
	/// </summary>
	public class PlayerAdmin : Player
	{
		public override bool IsParticipant { get { return false; } }

		public override void StartTurn (Func<PlayerReport, bool> onTurnEnd)
		{
			// skip the admin's turn
			onTurnEnd.Invoke (new PlayerReportNull());
		}
		public override bool HasAccess (GameThing thing)
		{
			// an admin has acces to all things
			return true;
		}
	}
}

