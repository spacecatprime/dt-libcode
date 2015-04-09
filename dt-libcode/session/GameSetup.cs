using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace dtlibcode
{
	/// <summary>
	/// A blob that describes's the choice all teams/players have made before starting a scenario
	/// </summary>
	public abstract class GameSetup
	{
		/// <summary>
		/// The options table the player needs to fill out to handle the scenario. Could be:
		/// 	the list of army units the player wants to take along
		/// 	special actions/cards to take
		///  	the placement of land marks
		/// 	intial placement of the units in a secret location
		/// </summary>
		/// <returns>The options.</returns>
		public abstract Hashtable CreateOptions();

		private Dictionary<Player, Hashtable> m_optionTable = new Dictionary<Player, Hashtable>();

		public ReadOnlyDictionary<Player, Hashtable> OptionsTable { get { return new ReadOnlyDictionary<Player, Hashtable>(m_optionTable); } }

		public virtual bool SetOptionsFor(Player player, Hashtable options)
		{
			if(m_optionTable.ContainsKey(player))
			{
				m_optionTable[player] = options;
			}
			else
			{
				m_optionTable.Add(player, options);
			}
			Messenger.Emit<Player, Hashtable>("SetOptionsFor", player, options);
			return true;
		}
	}
}

