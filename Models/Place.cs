﻿using System.Text.Json.Serialization;

namespace APITraining.Models
{
    public class Place
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
