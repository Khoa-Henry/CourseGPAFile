using System;
using System.IO;

namespace CourseGPAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "courseData.txt";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    var grades = ReadFile(file);
                    calculateGrade(grades);
                }
                else if (choice == "2")
                {
                    // write file from data
                    StreamWriter sw = new StreamWriter(file, true);
                    var response = Console.ReadLine().ToUpper();

                    if (response != "Y") { break; }

                    Console.WriteLine("Enter the ocurse name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the course grade: ");
                    string grade = Console.ReadLine().ToUpper();

                    sw.WriteLine("{0}|{1}", name, grade);
                    sw.Close();
                }

            } while (choice == "1" || choice == "2");
        }

        private static void calculateGrade(string[] grades)
        {
            var gradePoints = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                gradePoints += grades[i] == "A" ? 4 : grades[i] == "B" ? 3 : grades[i] == "C" ? 2 : grades[i] == "D" ? 1 : 0;
                Console.WriteLine(grades[i]);
            }
            double GPA = (double)gradePoints / grades.Length;
            Console.WriteLine("GPA: {0:n2}", GPA);
        }

        private static string[] ReadFile(string file)
        {
            string[] grades = new string[5];
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                sr.ReadLine();
                int count = 0;

                while (!sr.EndOfStream)
                {
                    var row = sr.ReadLine();
                    var columns = row.Split('|');

                    var courseName = columns[0];
                    var grade = columns[1];

                    var watching = columns[6];
                    
                    grades[count] = grade;
                    count++;
                }
            } else
            {
                Console.WriteLine("no file found");
            }
            return grades;
        }
    }
}
