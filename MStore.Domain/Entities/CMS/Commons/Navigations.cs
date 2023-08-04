using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.CMS.Commons
{
    public class Navigation : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string EngName { get; set; }
        public string OtherName { get; set; }
        public int DisplayOrder { get; set; }
        public string Url { get; set; }
        public bool Published { get; set; }
    }
}
