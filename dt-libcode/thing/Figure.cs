using System;

namespace dtlibcode
{
	/// <summary>
	/// a game thing represented with visuals and audio in the world's map
	/// 
	/// </summary>
	public class Figure : GameThing
	{
		public Figure() : base(new PlayerUnassigned())
		{
		}
	}
}

