using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNRestaurant
{
    class ChickenOrder
    {
        int quantity = 0;
        public ChickenOrder(int quantity)
        {
            this.quantity = quantity;
        }
        public int GetQuantity()
        {
            return this.quantity;
        }
        public void CutUp() { }
        public void Cook() { }
    }
}
