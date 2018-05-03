﻿using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}