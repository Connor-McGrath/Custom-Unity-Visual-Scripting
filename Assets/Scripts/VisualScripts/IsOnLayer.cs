using Unity.VisualScripting;
using UnityEngine;

/// IsOnLayer - Custom Visual Scripting Node
/// by Connor McGrath
///
/// Return boolean value from testing the layer of a game object against a supplied layermask.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [UnitTitle("Is On Layer")]
    [TypeIcon(typeof(LayerMask))]
    public class IsOnLayer : Unit
    {
        [DoNotSerialize]
        public ValueInput inGameObject;

        [DoNotSerialize]
        public ValueInput inLayerMask;

        [DoNotSerialize, PortLabelHidden]
        public ValueOutput outBool;

        protected override void Definition()
        {
            inGameObject = ValueInput<GameObject>("object");
            inLayerMask = ValueInput<LayerMask>("layerMask");

            outBool = ValueOutput<bool>("result", (flow) =>
            {
                GameObject obj = flow.GetValue<GameObject>(inGameObject);
                LayerMask mask = flow.GetValue<LayerMask>(inLayerMask);
                //Shift the object's layer id to be a mask, 
                //then compare with the layermask
                //and return true if any part matched.
                return ((1 << obj.layer) & mask.value) > 0;
            });
        }
    }
}