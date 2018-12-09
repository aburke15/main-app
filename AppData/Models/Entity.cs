using System;

namespace AppData.Models
{
    public abstract class Entity
    {
        public Entity() 
            => CreatedOn = DateTime.Now;

        public int Id { get; private set; }

        public DateTime CreatedOn { get; private set; }
    }
}