using System;
using System.Collections;

namespace dtlibcode
{
	/// <summary>
	/// A blob of data that is stored and handed to game objects as the logical states are changed
	/// </summary>
	public class GameState
	{
		public Hashtable blob { get; private set; }

		public GameState()
		{
			blob = new Hashtable();
		}
	}
}

