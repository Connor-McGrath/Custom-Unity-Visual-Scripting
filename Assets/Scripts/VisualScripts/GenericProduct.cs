using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

/// GenericProduct - Custom Visual Scritping Node
/// by Connor McGrath
///
/// Multiplies all input values and returns their product.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitCategory("Math/Generic")]
    [UnitTitle("Multiply")]
    [TypeIcon(typeof(Multiply<>))]
    public sealed class GenericProduct : Sum<object>
    {
        public override object Operation(object a, object b)
        {
            return OperatorUtility.Multiply(a, b);
        }

        public override object Operation(IEnumerable<object> values)
        {
            //Convert the enumerable values to a list
            //For each pair of the (running total, next item)...
            //Call the overload Operation(a, b)
            return values.ToList().Aggregate((a, b) => Operation(a, b));
        }
    }
}
