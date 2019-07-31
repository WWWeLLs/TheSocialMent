using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Data
{
    public class Connection
    {
       [Key]
        public int ConnectionId { get; set; }

        public string MentorsId { get; set; }
        public string MentoreeId { get; set; }

        public DateTime ConnectionDate { get; set; }


    }
}
