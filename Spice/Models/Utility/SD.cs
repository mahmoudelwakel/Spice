using System;

namespace Spice.Models.Utility
{
    public static class SD
    {
        public const string ManagerUser = "Manager";
        public const string KitchenUser = "Kitchen";
        public const string FrontDeskUser = "FrontDesk";
        public const string CustomerUser = "Customer";
        public const string ShoppingCartCount = "ShoppingCartCount";
        public const string ssCouponCode = "ssCouponCode";

        public const string StatusSubmitted = "Submitted";
        public const string StatusInProccess= "Begin  Prepared";
        public const string StatusReady = "Ready For PickUp";
        public const string StatusComleted = "Completed";
        public const string StatusCancelled= "Cancelled";


        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";
        public static double DiscountPrice(Coupon coupon,double OrderTotalOrginal)
        {
            if (coupon == null)
            {
                return Math.Round(OrderTotalOrginal,2);
            }
            else
            {
                if (coupon.MinimumAmount > OrderTotalOrginal)
                {
                    return Math.Round(OrderTotalOrginal, 2);
                }
                else
                {
                    if (int.Parse(coupon.CouponType) == (int)Coupon.ECouponType.Dollar)
                    {
                        return Math.Round(OrderTotalOrginal-coupon.Discount,2); 

                    }
                    else
                    {
                        return Math.Round(OrderTotalOrginal - (OrderTotalOrginal* coupon.Discount/100), 2);

                    }
                }
            }
        }
    }
}
