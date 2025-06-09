using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

/// BitwiseXOR - Custom Visual Scripting Node
/// by Connor McGrath
///
/// Applies the bitwise '^' operator to the input values and returns the result.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitCategory("Logic/Bitwise")]
    [UnitTitle("Bitwise XOR")]
    [UnitSurtitle("Bitwise")]
    [UnitShortTitle("XOR")]
    [TypeIcon(typeof(ExclusiveOr))]
    public sealed class BitwiseXOR : Unit
    {
        [DoNotSerialize]
        public ValueInput A;

        [DoNotSerialize]
        public ValueInput B;

        [DoNotSerialize, PortLabelHidden]
        public ValueOutput result;

        protected override void Definition()
        {
            A = ValueInput<int>("A");
            B = ValueInput<int>("B");

            result = ValueOutput<int>("A \u2295 B", (flow) =>
            {
                return flow.GetValue<int>(A) ^ flow.GetValue<int>(B);
            });
        }
    }
}
