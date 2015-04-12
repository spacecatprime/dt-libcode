using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using dtlibcode;

namespace dtt_testing
{
	public class TestGameSetup : GameSetup
	{
		public TestGameSetup()
		{
		}

		public override Hashtable CreateOptions()
		{
			var opt = new Hashtable();
			opt["map"] = "test.map";
			opt["team"] = new ArrayList { "red", "blue", "observer" };
			opt["unit_list"] = new ArrayList();
			return opt;
		}
	}
}

