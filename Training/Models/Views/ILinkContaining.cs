using System.Collections.Generic;

namespace Training.Models.Views
{
    public interface ILinkContaining
    {
        List<Link> Links { get; set; }
        void AddLink(Link link);
    }
}