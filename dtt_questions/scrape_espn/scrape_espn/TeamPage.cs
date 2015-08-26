using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrape_espn
{
    public class TeamPage
    {
        WebPageParser m_page = new WebPageParser();
        List<string> m_gameIds = new List<string>();

        public WebPageParser WebPage
        {
            get{ return m_page; }
        }

        public bool LoadURL(string aPage)
        {
            if (m_page.DownloadSource(aPage) == false)
            {
                return false;
            }
            LoadRecaps();
            return m_gameIds.Count > 0;
        }

        public bool LoadFile(string aPathFile)
        {
            if (m_page.LoadPageFromDoc(aPathFile) == false)
            {
                return false;
            }
            LoadRecaps();
            return m_gameIds.Count > 0;
        }

        public List<GamePage> LoadGamePages()
        {
            var pages = new List<GamePage>();
            foreach(var gameId in m_gameIds)
            {
                string url = string.Format("http://espn.go.com/ncf/playbyplay?gameId={0}&period=0", gameId);
                GamePage gamePage = new GamePage();
                if( gamePage.LoadURI(url) )
                {
                    pages.Add(gamePage);
                }                
            }
            return pages;
        }

        public void DebugPrint()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("-- team page:{0}",m_page.URI));
            System.Diagnostics.Debug.WriteLine("-- game ids:");
            foreach (var g in m_gameIds)
            {
                System.Diagnostics.Debug.WriteLine(g);
            }
        }

        private void LoadRecaps()
        {
            m_gameIds.Clear();
            var recaps = m_page.ExtractMultiple(@"(?:recap\?)id=\d*");
            foreach (var r in recaps)
            {
                string[] fields = r.Split('=');
                m_gameIds.Add(fields[1]);
            }
        }
    }
}

/*
http://espn.go.com/college-football/team/schedule/_/id/251/year/2014/texas-longhorns
http://espn.go.com/ncf/playbyplay?gameId=222430251&period=0

    (?:recap\?)id=\d* for each game

*/
