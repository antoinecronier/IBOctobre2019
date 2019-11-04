using LessonEF6.Database;
using LessonEF6.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonEF6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();

            for (int i = 0; i < 50; i++)
            {
                User user1 = new User();
                user1.Firstname = "f1";
                user1.Lastname = "l" + i;
                user1.DateOfBirth = DateTime.Now;

                for (int j = 0; j < 20; j++)
                {
                    user1.Comments.Add(new Comment() { Data = "coucou " + i + " " + j, From = user1 });
                }

                db.UserDb.Add(user1);
            }

            db.SaveChanges();

            foreach (var item in db.UserDb.Include(x => x.Comments).ToList())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
