namespace MStore.Application.Dtos.FinanceDto.StoreDto
{
    public class PostStoreDto
    {   public Guid Id { get; set; }
       public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string StoreURL { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StoreLogo  { get; set; }
        //SocialMedia Account Info
        public string FacebookAccount { get; set; }
        public string InstagramAccount { get; set; }
        public string TwitterAccount { get; set; }
        public string SnapchatAccount { get; set; }
        public string TikTokAccount { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid CurrencyId  { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool DisplayAddress { get; set; }
        public string CommercialName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerMobile { get; set; }
        public string IdNumber { get; set; }
        public string VatNumber { get; set; }
        public string CommercialRegistrationNumber { get; set; }
        public bool DisplayCRNumber { get; set; }
        public string OwnerIdImage { get; set; }
        public string VatRegistrationCertificate  { get; set; }
        public string FreelanceCertificate  { get; set; }
        public string EcommerceCertificate  { get; set; }
        public string CommercialRegistrationCertificate { get; set; }
        public string BankCertificate  { get; set; }
        public string ActivityLicenseCertificate  { get; set; }
        public bool CloseStorePermanently  { get; set; }
        public bool StopReceivingOrders  { get; set; }
        public bool ShowCountDownToReOpen  { get; set; }
        public string StoreCloseTitle  { get; set; }
        public string StoreCloseOtherTitle  { get; set; }
        public string StoreCloseDesc  { get; set; }
        public string StoreCloseOtherDesc  { get; set; }
        public DateTime StoreCloseFrom  { get; set; }
        public DateTime StoreCloseTo  { get; set; }
        public bool SendNotificationToCustomerWhenReOpenStore  { get; set; }
    }
}