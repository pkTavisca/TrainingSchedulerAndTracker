using System;
using System.Collections.Generic;
using System.IO;

namespace SchedulerAndTracker
{
    public class Trainee
    {
        public static Dictionary<string, List<int>> AllTrainees;

        private static string filename = "trainee.txt";

        public Trainee()
        {
            if (!File.Exists(filename)) File.CreateText(filename);
            AllTrainees = new Dictionary<string, List<int>>();
            StreamReader sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] split = line.Split('|');
                string[] assignNos = split[1].Split(',');
                var listAssignNos = new List<int>();
                for (int i = 0; i < assignNos.Length; i++)
                {
                    listAssignNos.Add(int.Parse(assignNos[i]));
                }
                AllTrainees.Add(split[0], listAssignNos);
            }
            sr.Close();
        }

        public static bool Add(string name, List<int> assignmentList)
        {
            if (AllTrainees.ContainsKey(name)) return false;
            AllTrainees[name] = assignmentList;
            WriteToFile();
            return true;
        }

        public static bool Delete(string name)
        {
            if (!AllTrainees.ContainsKey(name)) return false;
            AllTrainees.Remove(name);
            WriteToFile();
            return true;
        }

        public static bool Assign(string name, int assignment)
        {
            if (!AllTrainees.ContainsKey(name)) return false;
            if (AllTrainees[name].Contains(assignment)) return false;
            AllTrainees[name].Add(assignment);
            WriteToFile();
            return true; ;
        }

        public static bool AssignEverythingTo(string name)
        {
            Assignment assignment = new Assignment();
            var assignmentList = new List<int>();
            foreach (var entry in Assignment.AllAssignments)
            {
                assignmentList.Add(entry.Key);
            }
            if (!AllTrainees.ContainsKey(name)) return false;
            AllTrainees[name] = assignmentList;
            WriteToFile();
            return true;
        }

        public static bool Unassign(string name, int assignmentNo)
        {
            if (!AllTrainees.ContainsKey(name)) return false;
            if (!AllTrainees[name].Contains(assignmentNo)) return false;
            AllTrainees[name].Remove(assignmentNo);
            WriteToFile();
            return true;
        }

        private static void WriteToFile()
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (var entry in AllTrainees)
            {
                sw.Write(entry.Key + "|");
                string temp = "";
                foreach (var assignment in entry.Value)
                {
                    temp += assignment + ",";
                }
                temp = temp.Remove(temp.Length - 1, 1);
                sw.WriteLine(temp);
            }
            sw.Close();
        }
    }
}
