namespace MStore.Application.Dtos.FinanceDto.CityDto
{
    public class PostCityDto
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string Abbreviation { get; set; }

        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        //public bool LimitedToStores { get; set; }
        
        
    }
}