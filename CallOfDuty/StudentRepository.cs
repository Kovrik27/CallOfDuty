
using System.Text.Json;
using System.Xml.Linq;

namespace CallOfDuty
{
    public class StudentRepository
    {
        public List<Student> Students { get; set; }

        public StudentRepository()
        {
            Students = new List<Student>();
        }

        public StudentRepository(string file)
        {
            var lines = File.ReadAllLines(file);
            Students = new List<Student>(lines.Length);
            foreach (var line in lines)
            {
                var cols = line.Split(';');
                Students.Add(new Student { Name = cols[0], Info = cols[1] });
            }
        }

        public Student Create()
        {
            Student newStudent = new Student();
            Students.Add(newStudent);
            return newStudent;
        }

        public bool Update(Student student)
        {
            if (Students.Contains(student))
                Save();
            else 
                return false;
            return true;
        }

        public bool Delete(Student student)
        {
            Students.Remove(student);
            Save();
            return true;
        }

         void Save() 
        {
            using (FileStream fs = new FileStream("Students.txt", FileMode.Open))
            {
                JsonSerializer.Serialize(fs, Students);
            }
        }
    }
}