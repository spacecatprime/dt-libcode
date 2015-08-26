using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrape_espn
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //int teamId = 251; string teamName = "texas-longhorns";
                int teamId = 2628; string teamName = "tcu-horned-frogs";
                // 2306 kansas-state-wildcats
                // http://espn.go.com/college-football/team/_/id/66/iowa-state-cyclones
                // http://espn.go.com/college-football/team/_/id/197/oklahoma-state-cowboys
                // http://espn.go.com/college-football/team/_/id/201/oklahoma-sooners
                // http://espn.go.com/college-football/team/_/id/239/baylor-bears
                // http://espn.go.com/college-football/team/_/id/277/west-virginia-mountaineers
                // http://espn.go.com/college-football/team/_/id/2305/kansas-jayhawks
                // http://espn.go.com/college-football/team/_/id/2641/texas-tech-red-raiders

                for (int year = 2002; year <= 2015; year++)
                {
                    ParseTeamPage(teamId, year, teamName);
                }
            }
            catch (Exception eee)
            {
                System.Diagnostics.Debug.WriteLine(eee);
            }
        }

        static void ParseTeamPage(int id, int year, string teamName)
        {
            string url = string.Format(@"http://espn.go.com/college-football/team/schedule/_/id/{0}/year/{1}/{2}", id, year, teamName);
            TeamPage page = new TeamPage();
            page.LoadURL(url);
            page.DebugPrint();
            var gamePages = page.LoadGamePages();
            foreach (GamePage gp in gamePages)
            {
                string title = gp.WebPage.ExtractSingle(@"(?:<title>)(.*?)(?:<\/title>)");
                title = title.Replace("<title>", "");
                title = title.Replace("</title>", "");
                gp.WebPage.SaveToDocument(string.Format("./{0}.html", title));
            }
            string gameTitle = page.WebPage.ExtractSingle(@"(?:<title>)(.*?)(?:<\/title>)");
            gameTitle = gameTitle.Replace("<title>", "");
            gameTitle = gameTitle.Replace("</title>", "");
            page.WebPage.SaveToDocument(string.Format("./{0}.html", gameTitle));
        }
    }
}
