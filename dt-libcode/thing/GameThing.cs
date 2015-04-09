using System;

namespace dtlibcode
{
	/// <summary>
	/// Some kind of game object that can be represented in the world or an inventory
	/// Some examples: units, buildings, boxes, crates, power-ups, portals, equipment, cards, dice
	/// </summary>
	public abstract class GameThing
	{
		public GameThing(Player owner)
		{
			Owner = owner;
		}

		public virtual Player Owner { get; set; }

		/// <summary>
		/// the game world the the thing is in
		/// </summary>
		/// <value>The game world.</value>
		public World GameWorld { get; set; }
	}
}
