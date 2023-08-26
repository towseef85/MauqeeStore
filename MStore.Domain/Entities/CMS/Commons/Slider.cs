using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.CMS.Commons
{
    public class Slider : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string Title{ get; set; }
        public string? Description { get; set; }
        public string ImageData { get; set; }
        public string RedirectTo { get; set; }

    }
}
