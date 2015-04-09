using NUnit.Framework;
using System;
using dtlibcode;

namespace dtt_testing
{
	[TestFixture()]
	public class LoaderTests
	{
		class FakeLoader : dtlibcode.Loader
		{
			public override void Start()
			{
				System.Console.WriteLine("started");
			}

			public override double Progress()
			{
				this.DoDone();
				return 1.0;
			}

			public override object Data { 
				get { return new Object(); } 
			}

		}

		[Test()]
		public void LoaderManager()
		{
			LoaderManager lm = new dtlibcode.LoaderManager();
			lm.StartLoader(new FakeLoader());
			lm.LoaderList[0].Progress();
			Assert.AreEqual(lm.LoaderList.Count, 0);
		}
	}
}

