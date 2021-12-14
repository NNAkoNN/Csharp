using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNRestaurant
{
    class Employee
    {
        int quantityCopy;
        int? qualityCopy;
        bool firstOrder = false;
        string typeCopy;
        int newOrders = 0;
        int reqS = 0;
        public object NewRequest(int quantity, string menuItem)
        {
            newOrders++;
            reqS = newOrders - 1;
            firstOrder = true;
            quantityCopy = quantity;
            typeCopy = menuItem;
            if (newOrders % 3 == 0)
            {
                if (menuItem == "Chicken")
                {
                    EggOrder newEgg = new EggOrder(quantity);
                    qualityCopy = newEgg.GetQuality();
                    return newEgg;
                }
                else
                {
                    ChickenOrder newChick = new ChickenOrder(quantity);
                    return newChick;
                }
            }
            else
            {
                if (menuItem == "Chicken")
                {
                    ChickenOrder newChick = new ChickenOrder(quantity);
                    return newChick;
                }
                else
                {
                    EggOrder newEgg = new EggOrder(quantity);
                    qualityCopy = newEgg.GetQuality();
                    return newEgg;
                }
            }
        }
        public object CopyRequest()
        {
            newOrders++;
            reqS = newOrders - 1;
            if (!firstOrder)
            {
                throw new Exception("Заказов Ещё Не Было!");
            }
            else
            {
                if (typeCopy == "Egg")
                {
                    EggOrder eggCopy = new EggOrder(quantityCopy);
                    eggCopy.quality = qualityCopy;
                    return eggCopy;
                }
                else
                {
                    ChickenOrder chickCopy = new ChickenOrder(quantityCopy);
                    return chickCopy;
                }
            }
        }
        public string Inspect(object order)
        {
            if (order is EggOrder)
            {
                return ((EggOrder)order).GetQuality().ToString();
            }
            else
            {
                return "Проверка Не Нужна!";
            }
        }
        public string PrepareFood(object order)
        {
            reqS++;
            if(reqS > newOrders)
            {
                throw new Exception("Нельзя Приготовить Уже Приготовленный Заказ!");
            }
            if (order is ChickenOrder)
            {
                int i;
                for (i = 0; i < ((ChickenOrder)order).GetQuantity(); i++)
                {
                    ((ChickenOrder)order).CutUp();
                }
                ((ChickenOrder)order).Cook();
                return "Приготовлено " + i + " Куриц!";
            }
            else
            {
                int i;
                string newStr = "";
                for (i = 0; i < ((EggOrder)order).GetQuantity(); i++)
                {
                    try
                    {
                        ((EggOrder)order).Crack();
                    }
                    catch (Exception myExc)
                    {
                        newStr = myExc.Message;
                    }
                    ((EggOrder)order).DiscardShell();
                }
                ((EggOrder)order).Cook();
                newStr = "Приготовлено " + i + " " + newStr + " Яиц!";
                return newStr;
            }
        }
    }
}