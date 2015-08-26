using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace scrape_espn
{
    public class WebPageParser
    {
        // http://www.regexr.com/
        public static Regex reTableData = new Regex(@"<td(.*?)</td>");
        public static Regex reTableRows = new Regex(@"<tr(.*?)</tr>");
        public static Regex reTableHeaders = new Regex(@"<thead(.*?)</thead>");
        public static Regex reTable = new Regex(@"<table.*?>(.*?)</table>");

        // internal data
        private string m_webPage = "";
        private string m_uri;

        public string URI
        {
            get { return m_uri; }
        }

        public bool DownloadSource(string aURL)
        {
            using (WebClient client = new WebClient())
            {
                m_uri = aURL;
                return ApplyPageData(client.DownloadString(m_uri));
            }
        }

        public bool ApplyPageData(string aPageData)
        {
            m_webPage = aPageData;
            return false == string.IsNullOrEmpty(m_webPage);
        }

        public bool LoadPageFromDoc(string aPathFile)
        {
            m_uri = aPathFile;
            return ApplyPageData(File.ReadAllText(aPathFile));
        }

        public List<string> ExtractMultiple(string pattern)
        {
            var list = new List<string>();
            var re = new Regex(pattern);
            Match m = re.Match(m_webPage);
            while (m.Success)
            {
                list.Add(m.Value);
                m = m.NextMatch();
            }
            return list;
        }

        public string ExtractSingle(Regex regex)
        {
            Match m = regex.Match(m_webPage);
            if (m != null)
            {
                return m.Value;
            }
            return null;
        }

        public string ExtractSingle(string pattern)
        {
            return ExtractSingle(new Regex(pattern));
        }

        public List<string> Tables
        {
            get
            {
                var tableList = new List<string>();
                Match m = reTable.Match(m_webPage);
                while (m.Success)
                {
                    tableList.Add(m.Value);
                    m = m.NextMatch();
                }
                return tableList;
            }
        }

        public List<string> Rows(string aTable)
        {
            var tableList = new List<string>();
            Match m = reTable.Match(aTable);
            while (m.Success)
            {
                tableList.Add(m.Value);
                m = m.NextMatch();
            }
            return tableList;
        }

        public List<string> TableData(string aTableRow)
        {
            var tableList = new List<string>();
            Match m = reTable.Match(aTableRow);
            while (m.Success)
            {
                tableList.Add(m.Value);
                m = m.NextMatch();
            }
            return tableList;
        }

        public bool SaveToDocument(string aPathFile)
        {
            try
            {
                File.WriteAllText(aPathFile, this.m_webPage);
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }

        public bool SaveToDocument(string aPath, string aFile)
        {
            return SaveToDocument(Path.Combine(aPath, aFile));
        }
    }
}

/*

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace testing
{
    [TestClass]
    public class ScrapeStats
    {
        // http://www.regexr.com/
        public static Regex reTableData = new Regex(@"<td(.*?)<\/td>");
        public static Regex reTableRows = new Regex(@"<tr(.*?)<\/tr>");
        public static Regex reTableHeaders = new Regex(@"<thead(.*?)<\/thead>");
        public static Regex reGameTitle = new Regex(@"<title>(.*?)<\/title>");
        public static Regex reGameId = new Regex(@"(?:gameId=)\d*");

        [TestMethod]
        public void DoScrapeStats()
        {
            string webpage = @"http://scores.espn.go.com/ncf/playbyplay?gameId=400548403&period=0";

            using (WebClient client = new WebClient())
            {
                string data = client.DownloadString(webpage);
                // System.IO.File.WriteAllText(@"data.txt", data);
                GameItem game = new GameItem();
                game.Parse(data);
            }
        }
    }

    public class GameItem
    {
        public DateTime m_kickoff;
        public string m_homeTeam;
        public string m_awayTeam;
        public string m_venue;
        public string m_league; // NFL, 
        public string m_gameId;
        public string m_title;
        public List<DriveItem> m_drives = new List<DriveItem>();

        public void Parse(string data)
        {
            m_title = ScrapeStats.reGameTitle.Match(data).Value;
            m_gameId = ScrapeStats.reGameId.Match(data).Value.Split('=')[1];
            var tableRows = ScrapeStats.reTableRows.Matches(data);

            PlayItem toss = null;
            DriveItem drive = null;
            foreach (Match row in tableRows)
            {
                if (toss == null)
                {
                    toss = FindToss(row);
                    if( toss != null )
                    {
                        drive = new DriveItem(PlayItem.Down.StartOfGame);
                    }                    
                }
                else if (drive.IsGameDone)
                {
                    // End of 4th Quarter
                    m_drives.Add(drive);
                    return;
                }
                else if (drive.IsDriveFinished)
                {
                    m_drives.Add(drive);
                    drive = new DriveItem(PlayItem.Down.NewDrive);
                }
                else
                {
                    drive.Parse(row.Value);
                }
            }
        }

        private PlayItem FindToss(Match row)
        {
            string data = row.Value;
            if (data.Contains(" toss "))
            {
                PlayItem tossPlay = new PlayItem();
                tossPlay.m_down = PlayItem.Down.CoinToss;
                tossPlay.m_description = data;
                return tossPlay;
            }
            return null;
        }
    }

    public class DriveItem
    {
        public string m_offenseTeam;
        public string m_defenseTeam;
        public DateTime m_startTime;
        public TimeSpan m_span;
        public int yards;
        public List<PlayItem> m_plays = new List<PlayItem>();
        public List<int> m_quarters = new List<int>();

        public DriveItem(PlayItem.Down aDown)
        {
            PlayItem p = new PlayItem();
            p.m_down = aDown;
            m_plays.Add(p);
        }

        public void Parse(string data)
        {
            PlayItem p = new PlayItem();
            p.Parse(ScrapeStats.reTableData.Matches(data));
            m_plays.Add(p);
            if (p.m_down == PlayItem.Down.EndOfQuarter)
            {
                if (p.m_description.ToLower().Contains("end of 4th quarter"))
                {
                    PlayItem eog = new PlayItem();
                    eog.m_down = PlayItem.Down.EndOfGame;
                    m_plays.Add(eog);
                }
            }
        }

        public PlayItem LastPlay
        {
            get
            {
                if (m_plays.Count > 0)
                {
                    return m_plays.Last();
                }
                return new PlayItem();
            }
        }

        public bool IsDriveFinished
        {
            get
            {
                return m_plays.Any(item => item.m_down == PlayItem.Down.EndOfDrive);
            }
        }

        public bool IsGameDone
        {
            get
            {
                return m_plays.Any(item => item.m_down == PlayItem.Down.EndOfGame);
            }
        }
    }

    public class PlayItem
    {
        public enum Down
        {
            PlayedDown, // 1st, 2nd, 3rd, 4th
            CoinToss, // pre-game
            StartOfGame, // kick off
            EndOfQuarter,
            EndOfGame,
            NewDrive,
            EndOfDrive,

            ERROR,
            EMPTY
        }
        public Down m_down;
        public string m_fieldMarker; // e.g. 1st and 10 at ACU 29
        public string m_description; // e.g. Herschel Sims run for a loss of 1 yard to the AblCh 28
        public string m_awayPoints;  // e.g. '3'
        public string m_homePoints;  // e.g. '7'
        public List<string> m_tags = new List<string>(); // fake, penalty, ...

        public PlayItem()
        {
            m_description = "";
            m_down = Down.EMPTY;
        }

        public void Parse(MatchCollection data)
        {
            if (data.Count == 0)
            {
                m_description = "";
                m_down = Down.ERROR;
            }
            // toss, quarter, end of drive
            else if (data.Count == 1)
            {
                m_description = data[0].Value;

                if (m_description.ToLower().Contains(" DRIVE TOTALS: "))
                {
                    m_down = Down.EndOfDrive;
                }
            }
            // not sure
            else if (data.Count == 2)
            {
                m_fieldMarker = data[0].Value;
                m_description = data[1].Value;
            }
            // drive start
            else if (data.Count == 3)
            {
                m_description = data[0].Value;
                m_awayPoints = data[1].Value;
                m_homePoints = data[2].Value;
            }
            // play
            else if (data.Count == 4)
            {
                m_fieldMarker = data[0].Value;
                m_description = data[1].Value;
                m_awayPoints = data[2].Value;
                m_homePoints = data[3].Value;

                if (m_description.Contains("End of "))
                {
                    m_down = Down.EndOfQuarter;
                }
            }
        }
    }
}
*/
