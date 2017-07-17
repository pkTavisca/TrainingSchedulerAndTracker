using System;
using System.Collections.Generic;
using System.IO;

namespace SchedulerAndTracker
{
    public class Session
    {
        public static Dictionary<string, int> AllSessions;

        private static string filename = "session.txt";

        public Session()
        {
            if (!File.Exists(filename)) File.CreateText(filename);
            AllSessions = new Dictionary<string, int>();
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] split = line.Split('|');
                AllSessions.Add(split[0], int.Parse(split[1]));
            }
            sr.Close();
        }

        public static bool Add(string sessionName, int sessionTotalTime)
        {
            if (AllSessions.ContainsKey(sessionName)) return false;
            AllSessions.Add(sessionName,sessionTotalTime);
            WriteToFile();
            return true;
        }

        public static bool Remove(string sessionName)
        {
            if (!AllSessions.ContainsKey(sessionName)) return false;
            AllSessions.Remove(sessionName);
            WriteToFile();
            return true;
        }

        public static string GenerateSchedule()
        {
            //TODO : Finish this function
            var weekToDayToSessionsMap = new Dictionary<int, Dictionary<int, string>>();
            int weekCounter = 1;
            int dayCounter = 1;
            int hourCounter = 0;
            foreach(var entry in AllSessions)
            {
                if (hourCounter+entry.Value>=5)
                {

                    weekToDayToSessionsMap[weekCounter][dayCounter] += entry.Key + "\t"; 
                }
            }
            return String.Empty;
        }

        private static void WriteToFile()
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach(var entry in AllSessions)
            {
                sw.WriteLine(entry.Key+"|"+entry.Value);
            }
            sw.Close();
        }
    }
}
