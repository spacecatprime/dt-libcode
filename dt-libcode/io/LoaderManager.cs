using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace dtlibcode
{
	public class LoaderManager
	{
		List<Loader> m_loaderList = new List<Loader>();

		public ReadOnlyCollection<Loader> LoaderList { get { return m_loaderList.AsReadOnly(); } }

		public LoaderManager()
		{
		}

		public void StartLoader(Loader loader)
		{
			loader.OnFinished += OnFinished;
			m_loaderList.Add(loader);
		}

		bool OnFinished(Loader l)
		{
			return m_loaderList.Remove(l);
		}
	}
}

