using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Models.Views
{
    public class Training : ILinkContaining
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public string Program { get; set; }
        public int Duration { get; set; }

        // --- link support start ---
        private List<Link> _links;
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
        // --- link support end   ---
    }
}
