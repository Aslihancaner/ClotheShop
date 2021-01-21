using ClotheShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClotheShop.Entities.Concrete
{
    public class Clothe : IEntity
    {
        public int ClotheId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Clothe()
        {

        }
        public Clothe(int clotheId, string name, decimal unitPrice)
        {
            ClotheId = clotheId;
            Name = name;
            UnitPrice = unitPrice;
        }

        public override string ToString()
        {
            return $"{ClotheId,-10}{Name,-10}{UnitPrice,-10}";
        }
    }
}
