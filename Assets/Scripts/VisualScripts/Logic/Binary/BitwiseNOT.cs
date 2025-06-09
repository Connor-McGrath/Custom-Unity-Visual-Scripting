using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

/// BitwiseNOT - Custom Visual Scripting Node
/// by Connor McGrath
///
/// Applies the bitwise '~' operator to the input and returns the result.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitCategory("Logic/Bitwise")]
    [UnitTitle("Bitwise NOT")]
    [UnitSurtitle("Bitwise")]
    [UnitShortTitle("NOT")]
    [UnitSubtitle("'~' Complement")]
    [TypeIcon(typeof(Negate))]
    public sealed class BitwiseNOT : Unit
    {
        [DoNotSerialize]
        public ValueInput A;

        [DoNotSerialize, PortLabelHidden]
        public ValueOutput result;

        protected override void Definition()
        {
            A = ValueInput<int>("A");

            result = ValueOutput<int>("\u007EA", (flow) =>
            {
                return ~flow.GetValue<int>(A);
            });
        }
    }
}
