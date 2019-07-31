using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Data
{
    public class Vids
    {
        [Key]
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string YouTubeCode { get; set; }

    }
}
