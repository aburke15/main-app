using System;

namespace AppData.Models
{
    public class Test
    {
        public Test() 
            => CreatedOn = DateTime.Now;

        public int ID { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public string Body { get; set; }

        public string CreatedBy { get; set; }
    }
}