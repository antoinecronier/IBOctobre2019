using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Lesson.Services
{
    public class MyService
    {
        private int myIncrementalInt;

        public int MyIncrementalInt
        {
            get { return myIncrementalInt; }
        }


        public MyService()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                    myIncrementalInt++;
                }
            });
        }
    }
}
