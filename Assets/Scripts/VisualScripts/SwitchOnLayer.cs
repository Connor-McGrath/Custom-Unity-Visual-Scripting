using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// SwitchOnLayer - Custom Visual Scripting Node
/// by Connor McGrath
///
/// Divert flow based on the layer of a game object.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitCategory("Control")]
    [UnitTitle("Switch On Layer")]
    [UnitShortTitle("Switch")]
    [UnitSubtitle("On Layer")]
    [TypeIcon(typeof(IBranchUnit))]
    public class SwitchOnLayer : Unit, IBranchUnit
    {
        [DoNotSerialize]
        public Dictionary<int, ControlOutput> branches { get; private set; }

        [Serialize]
        private LayerMask includedLayers = 0b1;
        [Inspectable, UnitHeaderInspectable]
        public LayerMask IncludedLayers
        {
            get
            {
                return includedLayers;
            }
            set
            {
                includedLayers = value;
            }
        }

        [DoNotSerialize]
        [PortLabelHidden]
        public ControlInput enter { get; private set; }

        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput TestedObject { get; private set; }

        protected override void Definition()
        {
            branches = new Dictionary<int, ControlOutput>();
            enter = ControlInput(nameof(enter), Enter);
            TestedObject = ValueInput<GameObject>("");
            Requirement(TestedObject, enter);
            int index = 0;
            int mask = IncludedLayers;
            while (mask > 0)
            {
                if ((mask & 1) == 1)
                {
                    var branch = ControlOutput(index.ToString());
                    branches.Add(index, branch);
                    Succession(enter, branch);
                }
                index++;
                mask >>= 1;
            }
            var fallbackBranch = ControlOutput("fallback");
            branches.Add(-1, fallbackBranch);
            Succession(enter, fallbackBranch);
        }

        public ControlOutput Enter(Flow flow)
        {
            int layer = flow.GetValue<GameObject>(TestedObject).layer;
            if (branches.ContainsKey(layer))
            {
                return branches[layer];
            }
            else
            {
                return branches[-1];
            }
        }
    }
}