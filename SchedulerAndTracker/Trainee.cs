using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerAndTracker
{
    public class Trainee
    {
        public static Dictionary<string, List<int>> AllTrainees;

        public Trainee()
        {

        }

        public static bool Add(string name, List<int> assignmentList)
        {
            return false;
        }

        public static bool Delete(string name)
        {
            return false;
        }

        public static bool Assign(string name, List<int> assignmentList)
        {
            return false;
        }

        public static bool AssignEverythingTo(string name)
        {
            return false;
        }

        public static bool Unassign(string name, int assignmentNo)
        {
            return false;
        }
    }
}
