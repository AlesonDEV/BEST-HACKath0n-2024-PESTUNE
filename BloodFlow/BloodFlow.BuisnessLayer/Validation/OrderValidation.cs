using BloodFlow.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodFlow.BuisnessLayer.Validation
{
    public static class OrderValidation
    {
        public static void ValidateOrder(OrderModel order)
        {
            BaseValidation.IsObjectNull(order, nameof(order));
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(order.Title);
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(order.Description);
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(order.ImportanceName);
            ValidateBloodVolume(order.BloodVolume);
        }

        private static void ValidateBloodVolume(int bloodVolume)
        {
            if (bloodVolume <= 0)
            {
                throw new ValidationException("Blood volume requirement must be greater than zero.");
            }
        }
    }
}
