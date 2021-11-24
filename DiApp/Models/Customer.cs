using System.Collections.Generic;

namespace DiAndSignalRApp.Models
{
    public class Customer
    {
        public Customer()
        {
            ReferralCustomers = new List<CustomerWithReferrals>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CustomerWithReferrals> ReferralCustomers { get; set; }
    }


}
