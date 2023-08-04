using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.CMSDtos.Navigations
{
    public class GetNavigationDto
    {
        public Guid Id { get; set; }
        public string EngName { get; set; }
        public string OtherName { get; set; }
        public int DisplayOrder { get; set; }
        public string Url { get; set; }
        public bool Published { get; set; }
    }
}
