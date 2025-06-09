using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

/// BinaryLeftShift - Custom Visual Scripting Node
/// by Connor McGrath
///
/// Applies the binary '<<' operator to the first value by the second and returns the result.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitCategory("Logic/Bitwise")]
    [UnitTitle("Binary Left Shift")]
    [UnitSurtitle("Left Shift")]
    [UnitShortTitle("<<")]
    [TypeIcon(typeof(int))]
    public sealed class BinaryLeftShift : Unit
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
            B = ValueInput<int>("B", 0);

            result = ValueOutput<int>("A \u003C\u003C B", (flow) =>
            {
                return flow.GetValue<int>(A) << flow.GetValue<int>(B);
            });
        }
    }
}
