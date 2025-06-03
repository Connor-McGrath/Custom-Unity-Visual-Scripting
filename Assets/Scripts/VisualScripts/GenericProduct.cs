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
            var valueList = values.ToList();
            var result = valueList[0];

            for (int i = 1; i < valueList.Count; i++)
            {
                result = Operation(result, valueList[i]);
            }

            return result;
        }
    }
}
