using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrape_espn
{
    public class GamePage
    {
        WebPageParser m_webPage;

        public WebPageParser WebPage
        {
            get { return m_webPage; }
        }

        public bool LoadURI(string url)
        {
            try
            {
                m_webPage = new WebPageParser();
                return m_webPage.DownloadSource(url);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }
    }
}

/*
http://espn.go.com/ncf/playbyplay?gameId=222430251&period=0
*/
