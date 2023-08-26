using MStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static MStore.Domain.Utils.Constants;

namespace MStore.Domain.Entities.Financials
{
    public class GiftCard : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public string CardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? CustomerId { get; set; }
        public Offertype Offertype { get; set; }
        public float Value { get; set; }
        public float? Balance { get; set; }
        public bool IsActive { get; set; }


    }

    
}
