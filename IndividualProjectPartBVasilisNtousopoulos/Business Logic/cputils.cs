using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace IndividualProjectPartBVasilisNtousopoulos.Business_Logic
{
    public class cputils
    {
        
        public string Stringselector()
        {

            string selectStudents =                    "SELECT * FROM Students;";
            string selectTrainers =                    "SELECT * FROM Trainers;";
            string selectCourses =                     "SELECT title +'_'+ Subjects.Stream as Course,type, startDate, endDate FROM Courses" +
                                                       " INNER JOIN CoursesSubjects on Courses.ID = CoursesSubjects.CourseID" +
                                                       " INNER JOIN Subjects on Subjects.ID = CoursesSubjects.SubjectID" +
                                                       " ORDER BY Courses.ID;";
            string selectAssignments =                 "SELECT * FROM Assignments;";
            string allStudentsPerCourse =              "SELECT Courses.ID AS [Course ID], Courses.title, Courses.type, Students.ID AS [Student ID], firstName, lastName  FROM Students" +
                                                       " INNER JOIN StudentsCourses on Students.ID = StudentsCourses.StudentID" +
                                                       " INNER JOIN Courses on Courses.ID = StudentsCourses.CourseID" +
                                                       " ORDER BY Courses.ID;";
            string allTrainersPerCourse =              "SELECT Courses.ID AS [Course ID], Courses.title, Courses.type, Trainers.ID AS [Trainer ID], firstName, lastName  FROM Trainers" +
                                                       " INNER JOIN TrainersCourses ON Trainers.ID = TrainersCourses.TrainerID" +
                                                       " INNER JOIN Courses ON Courses.ID = TrainersCourses.CourseID;";
            string allAssignmentsPerCourse =           "SELECT Courses.ID AS [Course ID] , Courses.Title, Courses.type, Assignments.ID as [Assignment ID], Assignments.title FROM Assignments" +
                                                       " INNER JOIN AssignmentsCourses on Assignments.ID = AssignmentsCourses.AssignmentID" +
                                                       " INNER JOIN Courses on Courses.ID = AssignmentsCourses.CourseID" +
                                                       " order by Courses.ID;";
            string allAssignmentsPerCoursePerStudent = "SELECT Assignments.ID AS [Assignment ID], Assignments.title AS [Assignment Title], Students.ID AS [Student ID]," +
                                                       " firstName AS [Student First Name], lastName AS [Student Last Name], Courses.ID AS [Course ID], Courses.title AS [Course Title], Courses.type" +
                                                       " AS [Course Title] from students" +
                                                       " INNER JOIN StudentsCourses on Students.ID = StudentsCourses.StudentID" +
                                                       " INNER JOIN Courses ON Courses.ID = StudentsCourses.CourseID" +
                                                       " INNER JOIN AssignmentsCourses ON Courses.ID = AssignmentsCourses.CourseID" +
                                                       " INNER JOIN Assignments ON Assignments.ID = AssignmentsCourses.AssignmentID" +
                                                       " ORDER BY Assignments.ID,Students.ID, Courses.ID;";
            string studentsWithMoreThanOneCourse =     "SELECT StudentID, firstName, lastNAme FROM StudentsCourses" +
                                                       " INNER JOIN Students ON Students.ID = StudentsCourses.StudentID" +
                                                       " GROUP BY studentID, firstName, lastNAme HAVING COUNT(COURSEID) > 1;";
            Console.WriteLine("Type a number from the list and press enter: ");
            int choice = SelectFromListOfS(new List<string> {"Give me all students","Give me all trainers","Give me all Courses","Give me all Assignments","Give me all Students per Course",
            "Give me all Trainers per Course","Give me all Assignments per Course","Give me all Assignments Per Course Per Student","Give me all Students with more than one Course"});
            string selection = "y";
            string answer="";

            
            
                switch (choice)
                {
                    case 1:
                        answer = selectStudents;
                        break;
                    case 2:
                        answer = selectTrainers;
                        break;
                    case 3:
                        answer = selectCourses;
                        break;
                    case 4:
                        answer = selectAssignments;
                        break;
                    case 5:
                        answer = allStudentsPerCourse;
                        break;
                    case 6:
                        answer = allTrainersPerCourse;
                        break;
                    case 7:
                        answer = allAssignmentsPerCourse;
                        break;
                    case 8:
                        answer = allAssignmentsPerCoursePerStudent;
                        break;
                    case 9:
                        answer = studentsWithMoreThanOneCourse;
                        break;
                }
                
            return answer;
        }
        private protected int SelectFromListOfS(List<string> elements)
        {
            int counter = 1;
            Console.WriteLine();
            foreach (var item in elements) 
            {
                Console.WriteLine($"{counter++}. {item}");
            }
            int choice = ConvertToInt(Console.ReadLine());
            while (choice > elements.Count || choice <= 0)
            {
                Console.WriteLine("Incorrect entry, choose a valid list number ONLY: ");
                choice = ConvertToInt(Console.ReadLine());
            }
            return (choice);
        }
        public DateTime ConvertToDateTime(string dateValue)
        {

            bool isItDate;
            DateTime date;
            isItDate = DateTime.TryParse(dateValue, out date);


            while (dateValue == null || isItDate == false)
            {
                Console.Write("Please enter a valid date (DD/MM/YYYY): ");
                dateValue = Console.ReadLine();
                isItDate = DateTime.TryParse(dateValue, out date);
            }
            date = DateTime.Parse(dateValue);
            return (date);
        }

        public double ConvertToDouble(string dValue)
        {

            bool isItDouble;
            double d1;
            isItDouble = double.TryParse(dValue, out d1);


            while (dValue == null || isItDouble == false)
            {
                Console.Write("Please enter a valid double value: ");
                dValue = Console.ReadLine();
                isItDouble = double.TryParse(dValue, out d1);
            }
            d1 = double.Parse(dValue);
            return (d1);
        }
        public int ConvertToInt(string intValue)
        {

            bool isItInt;
            int i1;
            isItInt = int.TryParse(intValue, out i1);


            while (intValue == null || isItInt == false)
            {
                Console.Write("Please enter a valid number choice: ");
                intValue = Console.ReadLine();
                isItInt = int.TryParse(intValue, out i1);
            }
            i1 = int.Parse(intValue);
            return (i1);
        }

        public float ConvertToFloat(string fValue)
        {

            bool isItFloat;
            float f1;
            isItFloat = float.TryParse(fValue, out f1);


            while (fValue == null || isItFloat == false)
            {
                Console.Write("Please enter a valid float value: ");
                fValue = Console.ReadLine();
                isItFloat = float.TryParse(fValue, out f1);
            }
            f1 = float.Parse(fValue);
            return (f1);
        }
        public string AskDetail(string message, List<string> subjects = null)
        {
            string result = "";
            Console.Write(message);
            if (subjects != null)
            {
                
                result = SelectFromListOfStrings(subjects);
            }
            else
            {
                result = Console.ReadLine();
            }

            return (result);
        }
        private protected string SelectFromListOfStrings(List<string> elements)
        {
            string result = "";
            int counter = 1;
            Console.WriteLine();
            foreach (var item in elements) //an grapsw foreach kai diplo tab mou kanei autoformat to foreach
            {
                Console.WriteLine($"{counter++}. {item}");
            }
            int choice = ConvertToInt(Console.ReadLine());
            while (choice > elements.Count || choice <= 0)
            {
                Console.WriteLine("Incorrect entry, choose a valid list number ONLY: ");
                choice = ConvertToInt(Console.ReadLine());
            }
            result = elements.ElementAt(choice - 1); //elements[choice - 1];
            return (result);
        }
    }
}
