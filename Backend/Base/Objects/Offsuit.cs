using System;
using System.Collections.Generic;
using System.Linq;
namespace Base.Objects
{
    internal class Offsuit: Record
    {
        public Offsuit(int count, int left, int right)
        : base(count,left,right){
            _suited = "false";
        }
    }
}