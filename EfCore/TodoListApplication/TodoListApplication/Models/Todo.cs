﻿using System.ComponentModel.DataAnnotations;

namespace TodoListApplication.Models
{
    public class Todo : NamedEntity
    {
        [MinLength(2)]
        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
