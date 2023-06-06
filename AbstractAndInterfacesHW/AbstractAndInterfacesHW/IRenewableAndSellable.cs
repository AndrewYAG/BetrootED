using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractAndInterfacesHW
{
    public interface IRenewableAndSellable
    {
        void RenewProductAmountInStock(int amountToRenew);

        void SellProductFromStock(int amountToSell);
    }
}
