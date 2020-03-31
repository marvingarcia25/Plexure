using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public interface ICouponProvider
    {
        Task<Coupon> Retrieve(Guid couponId);
    }
}
