using System;

namespace dtlibcode
{
	/// <summary>
	/// Players perform actions:
	///   likely drain things like action points
	///   could be a move, attack, set 'over watch', or some choice the player could make
	///   some involintary actions (flee, run away) could also be automatically performed
	/// </summary>
	public abstract class Action
	{
		public String Name { get; protected set; }

		public abstract void Perform(GameThing source, GameThing target);
	}
}

