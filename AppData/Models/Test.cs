using System;

namespace AppData.Models
{
    public class Test : Entity
    {
        public Test()
        { }

        public string Body { get; set; }

        public string CreatedBy { get; set; }
    }
}