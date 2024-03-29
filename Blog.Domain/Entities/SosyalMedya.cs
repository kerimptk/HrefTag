﻿using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class SosyalMedya : Entity<int>
    {
        public int Id { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Linkedin { get; set; }
    }
}