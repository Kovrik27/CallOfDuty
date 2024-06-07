using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.EditStudent
{
 class CommandCreateStudent : UserCommand
    {
        private StudentRepository file;

        public CommandCreateStudent (StudentRepository file)
        {
            this.file = file;
        }

        public override void Execute()
        {
            Console.WriteLine("Создание студента");
            Student newStudent = db.Create();
            Console.WriteLine("Введите фамилию студента");
            newStudent.Name = Console.ReadLine();
            Console.WriteLine("Введите имя студента");
            newStudent.Info = Console.ReadLine();

            if (db.Update(newStudent))
                Console.WriteLine("Студент создан");
            else
                Console.WriteLine("Нет.");
                
        }
    }
}
