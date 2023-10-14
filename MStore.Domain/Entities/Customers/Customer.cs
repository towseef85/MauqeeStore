using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MStore.Domain.Entities.Sales.Orders;

namespace MStore.Domain.Entities.Customers
{
    public class Customer :BaseEntity
    {

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public Guid SubscriptionId { get; set; }

        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? Gender { get; set; }

        /// <summary>
        /// 0 Individual Or 1 Company
        /// </summary>
        public int CustomerType { get; set; }
        public int? CommercialRegister { get; set; }

        public int? TaxNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }


        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is tax exempt
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// Gets or sets the affiliate identifier
        /// </summary>
        public Guid AffiliateId { get; set; }

     
        /// <summary>
        /// Gets or sets a value indicating whether this customer has some products in the shopping cart
        /// <remarks>The same as if we run ShoppingCartItems.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load "ShoppingCartItems" navigation property for each page load
        /// It's used only in a couple of places in the presenation layer
        /// </remarks>
        /// </summary>
        public bool HasShoppingCartItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last login
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last activity
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

        
        
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order>Orders { get; set; }

    }
}

