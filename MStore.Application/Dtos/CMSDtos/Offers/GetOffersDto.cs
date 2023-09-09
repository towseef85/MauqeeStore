using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.CMSDtos.Offers
{
    public class GetOffersDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ImageData { get; set; }
        public string RedirectTo { get; set; }
    }
}
