using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace dtlibcode
{
	/// <summary>
	/// Game modules are played on 3D maps that is more like a convex map so really no tunnels (other than portals)
	/// (TODO: this may change but not in the near future)
	/// </summary>
	public class GameMap
	{
		private List<GameThing> m_thingList = new List<GameThing>();
		public ReadOnlyCollection<GameThing> Things { get { return m_thingList.AsReadOnly(); } }
		public String Name;

		public GameMap(string name)
		{
			this.Name = name;
		}

		public void AddThing(GameThing gt)
		{
			m_thingList.Add(gt);
		}

		public void RemoveThing(GameThing gt)
		{
			m_thingList.Add(gt);
		}

		/// <summary>
		/// over ride this if the game allows blockage of sight (line of sight)
		/// </summary>
		/// <returns><c>true</c> if this instance can see the specified source target; otherwise, <c>false</c>.</returns>
		/// <param name="source">Source.</param>
		/// <param name="target">Target.</param>
		public virtual bool CanSee(GameThing source, GameThing target)
		{
			return false;
		}
	}
}

