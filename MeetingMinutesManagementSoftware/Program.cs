using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MeetingMinutesManagementSoftware
{
    class Program
    {
        static void Menu()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Meeting Minutes Management Software");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Which would you like to do?\n\t(a) Create Meeting\n\t(b) View Team\n\t(c) Exit");
            Console.WriteLine("------------------------------------");
            string choice = Console.ReadLine().ToUpper();
            switch(choice)
            {
                case "A":
                    CreateMeeting();
                    break;
                case "B":
                    ViewTeam();
                    break;
                case "C":
                    Exit();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        static void CreateMeeting()
        {
            Console.WriteLine("Name of team member recording the minutes:");
            string nameOfMinutesRecorder = Console.ReadLine();
            Console.WriteLine("Name of team member leading the meeting:");
            string meetingLeader = Console.ReadLine();
            Console.WriteLine("Date of meeting (MMDDYY):");
            string date = Console.ReadLine();
            date = "Minutes" + date + ".txt";
            StreamWriter writer = new StreamWriter(date);
            List<string> meetingTypes = new List<string>();
            meetingTypes.Add("Business Team"); meetingTypes.Add("Marketing Team"); meetingTypes.Add("Psychology Team");
            Console.WriteLine("Select the meeting type:");
            for (int i = 0; i < (meetingTypes.Count); i++)
            {
                Console.WriteLine("\t(" + (i + 1) + ") " + meetingTypes[i]);
            }
            int typeOfMeeting = int.Parse(Console.ReadLine());
            string meetingTeamType = "";
            switch(typeOfMeeting)
            {
                case 1:
                    meetingTeamType = "Business Team Meeting";
                    break;
                case 2:
                    meetingTeamType = "Marketing Team Meeting";
                    break;
                case 3:
                    meetingTeamType = "Psychology Team Meeting";
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
            Console.WriteLine("Topic of meeting:");
            string topic = Console.ReadLine();
            Console.WriteLine("Notes:");
            string notes = Console.ReadLine();
            Console.WriteLine("Would you like to enter notes on a different topic? (Y/N)");
            string answer = Console.ReadLine().ToUpper();
            List<string> topicTitles = new List<string>();
            List<string> additionalNotes = new List<string>();
            string topicTitle = "";
            string additionalNote = "";
            while (answer == "Y")
            { 
                Console.WriteLine("Topic:");
                topicTitle = Console.ReadLine();
                topicTitles.Add(topicTitle);
                Console.WriteLine("Notes:");
                additionalNote = Console.ReadLine();
                additionalNotes.Add(additionalNote);
                Console.WriteLine("Would you like to enter notes on a different topic? (Y/N)");
                answer = Console.ReadLine().ToUpper();
            }
            using (writer)
            {
                writer.WriteLine("----------------------");
                writer.WriteLine("University of Miami");
                writer.WriteLine("1320 S Dixie Hwy");
                writer.WriteLine("Coral Gables, FL 33146");
                writer.WriteLine("----------------------");
                writer.WriteLine("MEETING MINUTES");
                writer.WriteLine("----------------------");
                writer.WriteLine("Minutes recorded by: " + nameOfMinutesRecorder.ToUpper());
                writer.WriteLine("Meeting led by: " + meetingLeader.ToUpper());
                writer.WriteLine("Meeting type: " + meetingTeamType.ToUpper());
                writer.WriteLine("Topic: " + topic.ToUpper());
                writer.WriteLine("NOTES:\n" + notes);
                if (topicTitles.Count != 0)
                {
                    for (int i = 0; i < topicTitles.Count; i++)
                    {
                        writer.WriteLine("Topic: " + topicTitles[i]);
                        writer.WriteLine("NOTES:");
                        writer.WriteLine(additionalNotes[i]);
                    }
                }
            }
            StreamReader reader = new StreamReader(date);
            using (reader)
            {
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
            }
            Menu();
        }
        static void ViewTeam()
        {
            Console.WriteLine("Which team would you like to view?");
            Console.WriteLine("\t(a) Business\n\t(b) Marketing\n\t(c) Psychology\n\t(d) View All");
            string teamToView = Console.ReadLine().ToUpper();
            Dictionary<string, string> teamList = new Dictionary<string, string>();
            teamList.Add("Luca Donno", "Business");
            teamList.Add("Jose Romero-Simpson", "Business");
            teamList.Add("Sara Rushinek", "Business");
            teamList.Add("Trini Callava", "Marketing");
            teamList.Add("Jeffrey Weinstock", "Marketing");
            teamList.Add("Ian Scharf", "Marketing");
            teamList.Add("Mike Alessandri", "Psychology");
            teamList.Add("Jill Kaplan", "Psychology");
            teamList.Add("Roderick Gillis", "Psychology");
            switch (teamToView)
            {
                case "A":
                    foreach(KeyValuePair<string, string> professor in teamList)
                    {
                        if (professor.Value == "Business")
                        {
                            Console.WriteLine(professor.Key);
                        }
                    }
                    break;
                case "B":
                    foreach (KeyValuePair<string, string> professor in teamList)
                    {
                        if (professor.Value == "Marketing")
                        {
                            Console.WriteLine(professor.Key);
                        }
                    }
                    break;
                case "C":
                    foreach (KeyValuePair<string, string> professor in teamList)
                    {
                        if (professor.Value == "Psychology")
                        {
                            Console.WriteLine(professor.Key);
                        }
                    }
                    break;
                case "D":
                    foreach (KeyValuePair<string, string> professor in teamList)
                    {
                        Console.WriteLine(professor.Key + " (" + professor.Value + ")");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
            Console.WriteLine("\n");
            Menu();
        }
        static void Exit()
        {
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
