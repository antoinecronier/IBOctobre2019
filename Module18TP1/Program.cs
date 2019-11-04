using Module18TP1ClassLibrary.Database;
using Module18TP1ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18TP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new EmployeeContext())
            {
                foreach (var item in db.Employees.Include(x => x.Department))
                {
                    Console.WriteLine(item);
                }

                Random random = new Random();
                Employee employee = new Employee();
                employee.Firstname = "firstname";
                employee.Lastname = "lastname";
                employee.Function = "functionbase";
                employee.Salary = 10F;
                employee.DateOfBirth = DateTime.Now;
                employee.Department = db.Services.Find(random.Next(1, db.Services.Count()));
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            
            Console.ReadLine();
        }
    }
}
