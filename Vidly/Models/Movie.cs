﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName="datetime2") ]
        
        public DateTime? ReleaseDate { get; set; }
       
        public DateTime DateAdded { get; set; }
        
        [Display(Name="Number In Stock")]
        [Required]
        [Range(1,20)]
        public int NumberInStock { get; set; }
    }
}