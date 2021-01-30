using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using Countdown_ASP.NET.Controllers;

namespace Countdown_ASP.NET.Models
{
    public class Collection1Entity : UniqueEntity
    {
        public string Title { get; set; }

        public string CreatorName { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

    }

    public class Collection1NewEntityDto
    {
        [NotNull]
        [Required]
        [StringLength(
          100,
          MinimumLength = 10,
          ErrorMessage = "Title must be between 10 and 100 characters"
        )]
        public string Title { get; set; }

        [NotNull]
        [Required]
        [StringLength(
            100,
            MinimumLength = 3,
            ErrorMessage = "Name of the Author/Studio must be between 3 and 100 characters"
            )]
        public string CreatorName { get; set; }

        [NotNull]
        [Required]
        [StringLength(1000, ErrorMessage = "Description can't be more than 1000 characters")]
        public string Description { get; set; }

        [Required] [NotNull] public DateTime ReleaseDate { get; set; }
    }
}
