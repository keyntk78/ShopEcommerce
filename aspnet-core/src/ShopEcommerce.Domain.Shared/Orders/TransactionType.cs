using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEcommerce.Orders
{
    public enum TransactionType
    {

        ConfirmOrder,
        StartProcessing,
        FinishOrder,
        CancelOrder
    }
}
