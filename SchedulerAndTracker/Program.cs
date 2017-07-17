using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerAndTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Session session = new Session();
            Trainee trainee = new Trainee();
            Assignment assignment = new Assignment();

            int choice = 0;
            do
            {
                Console.WriteLine("Enter your choice:\n1.Session Operations\n2.Trainee Management\n3.Assignments");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int sessionChoice = 0;
                        do
                        {
                            Console.WriteLine("Session Management:\n1.Add a new session\n2.Remove an existing session");
                            sessionChoice = int.Parse(Console.ReadLine());
                            if (sessionChoice == 1)
                            {
                                Console.Write("Enter the session name: ");
                                string sessionName = Console.ReadLine();
                                Console.Write("Enter the session duration: ");
                                int sessionDuration = int.Parse(Console.ReadLine());
                                Session.Add(sessionName, sessionDuration);
                            }
                            else if (sessionChoice == 2)
                            {
                                Console.Write("Existing Sessions: ");
                                foreach (var entry in Session.AllSessions)
                                {
                                    Console.Write(entry.Key + " ");
                                }
                                Console.WriteLine();
                                Console.Write("Enter the session to remove: ");
                                string sessionName = Console.ReadLine();
                                Session.Remove(sessionName);
                            }
                        } while (sessionChoice != 0);
                        break;
                    case 2:
                        int traineeChoice = 0;
                        do
                        {
                            Console.WriteLine("Trainee Management\n1.Add a trainee\n2.Remove a trainee\n3.Add assignment to a trainee\n4.Add all assignments to a trainee" +
                                "\n5.Remove an assignment from a trainee\n6.Display all trainees");
                            traineeChoice = int.Parse(Console.ReadLine());
                            if (traineeChoice == 1)
                            {
                                Console.Write("Enter the name of the trainee: ");
                                string traineeName = Console.ReadLine();
                                Trainee.Add(traineeName, new List<int>());
                            }
                            else if (traineeChoice == 2)
                            {
                                Console.Write("Existing Trainees: ");
                                foreach (var entry in Trainee.AllTrainees)
                                {
                                    Console.Write(entry.Key + " ");
                                }
                                Console.Write("Enter the trainee to remove: ");
                                string traineeName = Console.ReadLine();
                                Trainee.Delete(traineeName);
                            }
                            else if (traineeChoice == 3)
                            {
                                Console.Write("Enter the name of the trainee: ");
                                string traineeName = Console.ReadLine();
                                Console.Write("Enter the assignment number: ");
                                int aNo = int.Parse(Console.ReadLine());
                                Trainee.Assign(traineeName, aNo);
                            }
                            else if (traineeChoice == 4)
                            {
                                Console.Write("Enter the name of the trainee: ");
                                string traineeName = Console.ReadLine();
                                Trainee.AssignEverythingTo(traineeName);
                            }
                            else if (traineeChoice == 5)
                            {
                                Console.Write("Enter the name of the trainee: ");
                                string traineeName = Console.ReadLine();
                                Console.Write("Enter the assignment number: ");
                                int aNo = int.Parse(Console.ReadLine());
                                Trainee.Unassign(traineeName, aNo);
                            }
                            else if (traineeChoice == 6)
                            {
                                Console.WriteLine("Trainee Details:\nName\tAssignments");
                                foreach (var entry in Trainee.AllTrainees)
                                {
                                    Console.Write(entry.Key + "\t");
                                    foreach(var aNo in entry.Value)
                                    {
                                        Console.Write(aNo+" ");
                                    }
                                    Console.WriteLine();
                                }
                            }
                        } while (traineeChoice != 0);
                        break;
                    case 3:
                        int aChoice = 0;
                        do
                        {
                            Console.WriteLine("Assignments\n1.Add an assignment\n2.Remove an assignment\n3.Display all Assignmnts");
                            aChoice = int.Parse(Console.ReadLine());

                            if (aChoice == 1)
                            {
                                Console.Write("Enter the assignment number: ");
                                int aNo = int.Parse(Console.ReadLine());
                                Console.Write("Enter the details of the assignment: ");
                                string aDetails = Console.ReadLine();
                                Assignment.Add(aNo, aDetails);
                            }
                            else if (aChoice == 2)
                            {
                                Console.Write("Enter the assignment number: ");
                                int aNo = int.Parse(Console.ReadLine());
                                Assignment.Delete(aNo);
                            }
                            else if (aChoice == 3)
                            {
                                Console.WriteLine("Assignment Details:\nNo.\tDetails");
                                foreach (var entry in Assignment.AllAssignments)
                                {
                                    Console.WriteLine(entry.Key + "\t" + entry.Value);
                                }
                            }
                        } while (aChoice != 0);
                        break;

                }
            } while (choice != 0);
        }
    }
}
