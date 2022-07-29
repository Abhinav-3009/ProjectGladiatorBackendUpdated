using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectGladiator.Models
{
    public partial class Scholarship
    {
        public Scholarship()
        {
            ScholarshipApplications = new HashSet<ScholarshipApplication>();
        }

        public int ScholarshipId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ScholarshipApplication> ScholarshipApplications { get; set; }
    }
}
