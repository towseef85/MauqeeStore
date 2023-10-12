using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Customers
{
    
        /// <summary>
        /// Address
        /// </summary>
        public partial class Address : BaseEntity
        {
            /// <summary>
            /// Gets or sets the first name
            /// </summary>
            public string EngDesc { get; set; }

            /// <summary>
            /// Gets or sets the last name
            /// </summary>
            public string ArbDesc { get; set; }

        
            /// <summary>
            /// Gets or sets the country identifier
            /// </summary>
            public int? CountryId { get; set; }

            /// <summary>
            /// Gets or sets the state/province identifier
            /// </summary>
            public int? StateProvinceId { get; set; }

            /// <summary>
            /// Gets or sets the county
            /// </summary>
            public string County { get; set; }

            /// <summary>
            /// Gets or sets the city
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// Gets or sets the address 1
            /// </summary>
            public string Address1 { get; set; }

            /// <summary>
            /// Gets or sets the address 2
            /// </summary>
            public string Address2 { get; set; }

            /// <summary>
            /// Gets or sets the zip/postal code
            /// </summary>
            public string ZipPostalCode { get; set; }

            /// <summary>
            /// Gets or sets the phone number
            /// </summary>
            public string PhoneNumber { get; set; }

            /// <summary>
            /// Gets or sets the fax number
            /// </summary>
            public string FaxNumber { get; set; }
             public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        }
    }

