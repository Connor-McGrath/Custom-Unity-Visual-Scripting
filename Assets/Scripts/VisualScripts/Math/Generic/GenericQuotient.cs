using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

/// GenericQuotient - Custom Visual Scripting Node
/// by Connor McGrath
///
/// Divides all subsequent input values from the first and returns the quotient.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitCategory("Math/Generic/...")]
    [UnitTitle("Divide")]
    [TypeIcon(typeof(Divide<>))]
    public sealed class GenericQuotient : Sum<object>
    {
        public override object Operation(object a, object b)
        {
            return OperatorUtility.Divide(a, b);
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
