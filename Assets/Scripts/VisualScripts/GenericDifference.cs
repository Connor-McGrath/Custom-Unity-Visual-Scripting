using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

/// GenericDifference - Custom Visual Scripting Node
/// by Connor McGrath
///
/// Subtracts all subsequent input values from the first and returns the difference.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitCategory("Math/Generic/...")]
    [UnitTitle("Subtract")]
    [TypeIcon(typeof(Subtract<>))]
    public sealed class GenericDifference : Sum<object>
    {
        public override object Operation(object a, object b)
        {
            return OperatorUtility.Subtract(a, b);
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
