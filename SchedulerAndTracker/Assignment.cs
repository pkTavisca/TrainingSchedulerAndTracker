using System;
using System.Collections.Generic;
using System.IO;

namespace SchedulerAndTracker
{
    public class Assignment
    {
        public static Dictionary<int, string> AllAssignments;

        private static string filename = "assignment.txt";

        public Assignment()
        {
            if (!File.Exists(filename)) File.CreateText(filename);
            AllAssignments = new Dictionary<int, string>();
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] split = line.Split('|');
                AllAssignments.Add(int.Parse(split[0]), split[1]);
            }
            sr.Close();
        }

        public static bool Add(int assignmentNo, string details)
        {
            if (AllAssignments.ContainsKey(assignmentNo)) return false;
            AllAssignments[assignmentNo] = details;
            WriteToFile();
            return true;
        }

        public static bool Delete(int assignmentNo)
        {
            if (!AllAssignments.ContainsKey(assignmentNo)) return false;
            AllAssignments.Remove(assignmentNo);
            WriteToFile();
            return true;
        }

        private static void WriteToFile()
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (var entry in AllAssignments)
            {
                sw.WriteLine(entry.Key + "|" + entry.Value);
            }
            sw.Close();
        }
    }
}
