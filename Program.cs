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
                    // read data from file and calculate GPA
                    readFile(file);
                }
                else if (choice == "2")
                {
                   createFile(file);
                }

            } while (choice == "1" || choice == "2");
        }

        private static void calculateGrade(int gradePoints, int count)
        {
             // calculate GPA
             double GPA = (double)gradePoints / count;
             Console.WriteLine("GPA: {0:N2}", GPA);
        }

        private static void readFile(string file)
        {
            if (File.Exists(file))
            {
                 // accumulators needed for GPA
                int gradePoints = 0;
                int count = 0;
                // read data from file
                StreamReader sr = new StreamReader(file);

                while (!sr.EndOfStream)
                {
                    var row = sr.ReadLine();
                    // split into name and letter grade
                    var column = row.Split('|');

                    // display array data
                    Console.WriteLine("Course: {0}, Grade: {1}", column[0], column[1]);

                    // add to accumulators
                    gradePoints += column[1] == "A" ? 4 : column[1] == "B" ? 3 : column[1] == "C" ? 2 : column[1] == "D" ? 1 : 0;
                    count++;
                }
                // call calculate GPA function
                calculateGrade(gradePoints,count);
            } else
            {
                Console.WriteLine("no file found");
            }
        }
        private static void createFile(string file) {
            // write file from data
            StreamWriter sw = new StreamWriter(file, true);
            // ask a question
            Console.WriteLine("Enter a course (Y/N)?");
            var response = Console.ReadLine().ToUpper();

            if (response == "Y") {
                Console.WriteLine("Enter the ocurse name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the course grade: ");
                string grade = Console.ReadLine().ToUpper();

                sw.WriteLine("{0}|{1}", name, grade);
                sw.Close();
            }
        }
    }
}
