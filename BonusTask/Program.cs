namespace BonusTask
{
    public class Instructor
    {
        public Instructor(int instructorId = 100, string instrucorName = "No-Name", string specialization = "Unknown")
        {
            InstructorId = instructorId;
            InstrucorName = instrucorName;
            Specialization = specialization;
        }

        public int InstructorId { get; set; }
        public string InstrucorName { get; set; }
        public string Specialization { get; set; }

        public string PrintDetails()
        {
            return $"Id: {InstructorId} | Name: {InstrucorName} | Specialization: {Specialization}";
        }
    }
    public class Course
    {
        public Course(int courseId = 10, string courseTitle = "No-Title", Instructor instructor = null)
        {
            CourseId = courseId;
            CourseTitle = courseTitle;
            Instructor = instructor;
        }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public Instructor Instructor { get; set; }

        public string PrintDetails()
        {
            string instrDetails = Instructor != null ? Instructor.PrintDetails() : "No Instructor";
            return $"Id: {CourseId} | Title: {CourseTitle} |\nInstructor: {instrDetails}";
        }
    }
    public class Student
    {
        public Student(int studentId = 0, string studentName = "No-Name", int studentAge = 0, List<Course> courses = null)
        {
            StudentId = studentId;
            StudentName = studentName;
            StudentAge = studentAge;
            Courses = courses;
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public List<Course> Courses {  get; set; }

        public bool Enroll(Course course)
        {
            foreach (Course c in Courses)
            {
                if (c.CourseId == course.CourseId)
                {
                    Console.WriteLine("Student already enrolled in this Course");
                    return false;
                }
            }
            Courses.Add(course);
            return true;
        }
        public string PrintDetails()
        {
            string courseDetails = "";
            foreach (Course c in Courses)
            {
                courseDetails += c.PrintDetails() + " ";
            }
            return $"Id: {StudentId} | Name: {StudentName} | Age: {StudentAge} |\nCourses: {courseDetails}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsRunning = true;

            StudentManager Manager1 = new StudentManager();
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Instructor> instructors = new List<Instructor>();

            do
            {

                Console.WriteLine("==Welcome to S-M-S==");
                Console.WriteLine(" ");
                Console.WriteLine("=== Sample Console Menu ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id or name");
                Console.WriteLine("9. Find the course by id or name");
                Console.WriteLine("10. Exit");
                Console.WriteLine(" ");
                Console.Write("Enter your choice: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:

                        Console.Write("Enter Student Id: ");
                        int StdId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        string StdName = Console.ReadLine();
                        Console.Write("Enter Student Age: ");
                        int StdAge = Convert.ToInt32(Console.ReadLine());

                        Student student = new Student(StdId, StdName, StdAge, new List<Course>());
                        Console.WriteLine(Manager1.AddStudent(student));
                        break;
                    
                    case 2:
                        
                        Console.Write("Enter Instructor Id: ");
                        int InsId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Instructor Name: ");
                        string InsName = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        string InsSpec = Console.ReadLine();
                        Instructor foundInstructor = Manager1.FindInstructor(InsId);

                        if (!instructors.Contains(foundInstructor))
                            instructors.Add(foundInstructor);
                        else
                            Console.WriteLine("Instructor already in the list");

                        Instructor Ins1 = new Instructor(InsId, InsName, InsSpec);
                        
                        Console.WriteLine(Manager1.AddInstructor(Ins1));
                        break;
                    
                    case 3:

                        Console.Write("Enter Course Id: ");
                        int CourseId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course Title: ");
                        string CourseTitle = Console.ReadLine();
                        Console.Write("Enter Instructor Id: ");
                        InsId = Convert.ToInt32(Console.ReadLine());

                        foundInstructor = Manager1.FindInstructor(InsId);

                        if (foundInstructor == null)
                        {
                            Console.WriteLine("Instructor not found. Add the instructor first.");
                            break;
                        }
                        Course Crs1 = new Course(CourseId, CourseTitle, foundInstructor);
                        Console.WriteLine(Manager1.AddCourse(Crs1));
                        break;

                    case 4:

                        Console.Write("Enter Student Id: ");
                        StdId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course Id: ");
                        CourseId = Convert.ToInt32(Console.ReadLine());

                        Student foundStudent = Manager1.FindStudent(StdId);
                        Course foundCourse = Manager1.FindCourse(CourseId);

                        if (foundStudent == null)
                        {
                            Console.WriteLine("Student not found.");
                            break;
                        }
                        if (foundCourse == null)
                        {
                            Console.WriteLine("Course not found.");
                            break;
                        }

                        Console.WriteLine(foundStudent.Enroll(foundCourse));
                        break;
                        
                    case 5:
                        if (Manager1.Students.Count > 0)
                        {
                            for (int i = 0; i < Manager1.Students.Count; i++)
                            {
                                Console.WriteLine("============================");
                                Console.WriteLine(Manager1.Students[i].PrintDetails());
                                Console.WriteLine("============================");
                            }
                        }
                        else
                            Console.WriteLine("Student list is empty");
                        break;

                    case 6:
                        if (Manager1.Courses.Count > 0)
                        {
                            for (int i = 0; i < Manager1.Courses.Count; i++)
                            {
                                Console.WriteLine("============================");
                                Console.WriteLine(Manager1.Courses[i].PrintDetails());
                                Console.WriteLine("============================");
                            }
                        }
                        else
                            Console.WriteLine("Courses list is empty");
                        break;

                    case 7:
                        if (Manager1.Instructors.Count > 0)
                        {
                            for (int i = 0; i < Manager1.Instructors.Count; i++)
                            {
                                Console.WriteLine("============================");
                                Console.WriteLine(Manager1.Instructors[i].PrintDetails());
                                Console.WriteLine("============================");
                            }
                        }
                        else
                            Console.WriteLine("Instructors list is empty");
                        break;

                    case 8:
                        Console.WriteLine("Search by: 1.Id | 2.Name ");
                        int SearchChoice = Convert.ToInt32(Console.ReadLine());
                        foundStudent = null;

                        if (SearchChoice == 1)
                        {
                            Console.Write("Enter Student Id: ");
                            StdId = Convert.ToInt32(Console.ReadLine());
                            foundStudent = Manager1.FindStudent(StdId);
                        }
                        else if (SearchChoice == 2)
                        {
                            Console.Write("Enter Student Name: ");
                            StdName = Console.ReadLine();
                            foundStudent = Manager1.FindStudent(0,StdName);
                        }
                        else
                            Console.WriteLine("Invalid Choice");

                        if (foundStudent != null)
                        {
                            Console.WriteLine("==================");
                            Console.WriteLine(foundStudent.PrintDetails());
                            Console.WriteLine("==================");
                        }
                        else
                            Console.WriteLine("Course not found.");
                        break;

                    case 9:
                        Console.WriteLine("Search by: 1. Id  2. Name");
                        SearchChoice = Convert.ToInt32(Console.ReadLine());
                        foundCourse = null;

                        if (SearchChoice == 1)
                        {
                            Console.Write("Enter Course Id: ");
                            CourseId = Convert.ToInt32(Console.ReadLine());
                            foundCourse = Manager1.FindCourse(CourseId);
                        }
                        else if (SearchChoice == 2)
                        {
                            Console.Write("Enter Course Title: ");
                            CourseTitle = Console.ReadLine();
                            foundCourse = Manager1.FindCourse(0,CourseTitle);
                        }
                        else
                            Console.WriteLine("Invalid choice");

                        if (foundCourse != null)
                        {
                            Console.WriteLine("==================");
                            Console.WriteLine(foundCourse.PrintDetails());
                            Console.WriteLine("==================");
                        }
                        else
                            Console.WriteLine("Course not found.");
                        break;

                    case 10:
                        IsRunning = false;
                        break;
                }
            } while (IsRunning);
            
            



            //int id = Convert.ToInt32(Console.ReadLine());

            //Student found = Manager1.FindStudent(id);
            //if (found != null)
            //    Console.WriteLine(found.PrintDetails());
            //else
            //    Console.WriteLine("Student not found.");










        }
    }
    public class StudentManager
    {
        public StudentManager()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }

        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }

        public bool AddStudent(Student student)
        {
            if (Students.Contains(student)) return false;
            Students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            if (Courses.Contains(course)) return false;
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            if (Instructors.Contains(instructor)) return false;
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId = 0, string studentName = null)
        {
            foreach (Student student in Students)
            {
                if(student.StudentId == studentId || student.StudentName == studentName) return student;
            }
            return null;
        }
        public Course FindCourse(int courseId = 0, string courseTitle = null)
        {
            foreach(Course course in Courses)
            {
                if(course.CourseId == courseId || course.CourseTitle == courseTitle) return course;
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            foreach(Instructor instructor in Instructors)
            {
                if(instructor.InstructorId == instructorId) return instructor;
            }
            return null;
        }
        //public bool EnrollStudentInCourse(int studentId,int courseId)
        //{
        //    return true;
        //}
    }
}
