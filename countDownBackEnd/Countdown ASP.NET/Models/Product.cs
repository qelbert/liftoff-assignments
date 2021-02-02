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
    public class Product : UniqueEntity
    {
        public ProductType Type { get; set; }

        public int TypeId { get; set; }

        public List<ProductCategory> Categories { get; set; }

        public string Title { get; set; }

        public ProductVendor Vendor { get; set; } // artist who has the right to sell and promote the work under their own name or on behalf of a single team/band

        public int VendorId { get; set; }


        // public Distributors Distributor { get; set; } // production company, publishing house, record company, who has right to sell products under *several* vendor names

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int SourceId { get; set; } // either UID (Authenticated User), VID (Vendor Id) or AID (API url) ore even WID (webcrawler) -- the source ID can be used to determine en entry as being "Verified" or a "Rumor"

        public bool Verified { get; set; } // does the VenderID


        // public List<Contributor> Contributors { get; set; } // cast of actors, illustrator, featured music artist, etc -- offer a dropdown list of users to add, but set as a new table of Ids to cover instances where a Vendor adds names of ppl who are not users of the software

        // public List<Outlet> Outlets { get; set; } // where product will be able to be found once released

    }

    // When a product is created, the UserId will be applied as the sourceID, unless the User selects the checkbox indicating that they are the producers of that product, in which case their (new or pre-existing) VID will be
    // placed as the SourceId. If the VID and SourceID don't match, we won't mark the product as "Verified". If the SourceID is an API ID, we can automatically mark the product as "Verified"

    public class NewProductDto
    {
        [NotNull]
        [Required]
        public ProductType Type { get; set; }

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
        public DateTime ReleaseDate { get; set; }

        [NotNull]
        [Required]
        [StringLength(
            100,
            MinimumLength = 3,
            ErrorMessage = "Name of the Artist/Representative must be between 3 and 100 characters"
            )]
        public string Vendor { get; set; }

        [NotNull]
        [Required]
        [StringLength(1000, ErrorMessage = "Description can't be more than 1000 characters")]
        public string Description { get; set; }
    }
}
