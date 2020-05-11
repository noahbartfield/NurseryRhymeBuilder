﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.Data
{
    public class Word
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Favorite { get; set; }
        public Word()
        {
            Favorite = false;
        }
    }
}
