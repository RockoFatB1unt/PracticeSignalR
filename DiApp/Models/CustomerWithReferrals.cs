namespace DiAndSignalRApp.Models
{
    public class CustomerWithReferrals
    {
        //[Key, Column(Order = 0)]
        //[ForeignKey("Customer")]
        public int CustomerId { get; set; }

        //[Key, Column(Order = 1)]
        //[ForeignKey("Referral")]
        public int ReferralId { get; set; }


        public Customer Customer { get; set; }
        public Customer Referral { get; set; }
    }
}
