﻿using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}