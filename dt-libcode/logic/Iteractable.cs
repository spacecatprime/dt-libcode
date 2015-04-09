using System;

namespace dtlibcode
{
	/// <summary>
	/// Handles logic to interact with a game thing
	/// </summary>
	public interface Iteractable
	{
		bool DoUse(GameThing user, GameThing target);
	}
}

