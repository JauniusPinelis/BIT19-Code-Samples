using System;

namespace TodoListApplication.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }
    }
}
