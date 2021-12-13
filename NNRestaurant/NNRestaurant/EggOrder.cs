using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNRestaurant
{
    class EggOrder
    {
        static Random r = new Random();
        int quantity = 0;
        public static int objs = 0;
        public int? quality;
        public EggOrder(int quantity)
        {
            objs++;
            this.quantity = quantity;
        }
        public int GetQuantity()
        {
            return this.quantity;
        }
        public int? GetQuality()
        {
            quality = r.Next(1, 100);
            if (objs % 2 == 0 && objs != 0)
            {
                return null;
            }
            else
            {
                return quality;
            }
        }
        public void Crack()
        {
            if (quality < 25)
            {
                throw new Exception("Протухших");
            }
        }
        public void DiscardShell() { }
        public void Cook() { }
    }
}
