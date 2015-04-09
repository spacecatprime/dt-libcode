using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace dtlibcode
{
	public class ProtoGameSetup : GameSetup
	{
		public ProtoGameSetup()
		{
		}

		public override Hashtable CreateOptions()
		{
			var opt = new Hashtable();
			opt["map"] = "prototype.map";
			opt["team"] = new ArrayList { "red", "blue", "observer" };
			opt["unit_list"] = new ArrayList();
			return opt;
		}
	}
}

