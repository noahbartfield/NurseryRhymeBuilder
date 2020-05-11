using Capstone.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class NurseryRhyme
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Rhyme { get; set; }
        [Required]
        public int WordId { get; set; }
        [Required]
        public Word Word { get; set; }
        [Required]
        public bool Favorite { get; set; }
        public NurseryRhyme()
        {
            Favorite = false;
        }

    }
}
