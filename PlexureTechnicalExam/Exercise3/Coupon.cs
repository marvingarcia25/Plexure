using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxNumOfCouponPerUser { get; set; }
        public int MaxNumOfCouponUsage { get; set; }

    }
}
