using System;
using System.Collections.Generic;
using System.Linq;
namespace Base.Objects
{
    internal class Suited: Record
    {
        public Suited(int count, int left, int right)
        : base(count,left,right){
            _suited = "true";
        }
    }
}