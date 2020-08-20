using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int OrnamentComfort = 1;
        private const decimal OrnamentPrice = 5;
        public Ornament() 
            : base(OrnamentComfort, OrnamentPrice)
        {
        }
    }
}
