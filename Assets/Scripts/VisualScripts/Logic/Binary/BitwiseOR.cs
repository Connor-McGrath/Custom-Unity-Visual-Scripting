using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

/// BitwiseOR - Custom Visual Scripting Node
/// by Connor McGrath
///
/// Applies the bitwise '|' operator between all input values and returns the result.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitCategory("Logic/Bitwise")]
    [UnitTitle("Bitwise OR")]
    [UnitSurtitle("Bitwise")]
    [UnitShortTitle("OR")]
    [TypeIcon(typeof(Or))]
    public sealed class BitwiseOR : Sum<int>
    {
        public override int Operation(int a, int b)
        {
            return a | b;
        }

        public override int Operation(IEnumerable<int> values)
        {
            //Convert the enumerable values to a list
            //For each pair of the (running total, next item)...
            //Call the overload Operation(a, b)
            return values.ToList().Aggregate((a, b) => Operation(a, b));
        }
    }
}
