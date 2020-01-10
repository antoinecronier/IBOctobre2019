using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTP3.Entities
{
    public class Post : EntityBase
    {
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override object Copy()
        {
            throw new NotImplementedException();
        }

        public override void CopyFrom(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
