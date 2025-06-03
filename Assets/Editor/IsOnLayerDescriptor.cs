using Unity.VisualScripting;

/// IsOnLayer - Custom Visual Scritping Node
/// by Connor McGrath
///
/// Return boolean value from testing the layer of a game object against a supplied layermask.
/// 
/// Licensed under CC BY-NC-ND 4.0
/// https://creativecommons.org/licenses/by-nc-nd/4.0/

namespace CM.VSNodes
{
    [Descriptor(typeof(IsOnLayer))]
    public class IsOnLayerDescriptor : UnitDescriptor<IsOnLayer>
    {
        public IsOnLayerDescriptor(IsOnLayer unit) : base(unit) { }

        protected override void DefinedPort(IUnitPort port, UnitPortDescription description)
        {
            base.DefinedPort(port, description);
            switch (port.key)
            {
                case "object":
                    description.summary = "The Game Object being tested.";
                    break;
                case "layerMask":
                    description.summary = "The Layer Mask to match against.";
                    break;
                case "result":
                    description.summary = "Returns True if the layer of the Game Object is included in the Layer Mask.";
                    break;
            }
        }
    }
}