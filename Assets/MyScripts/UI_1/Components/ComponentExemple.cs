using UnityEngine;

namespace UI_1
{
    public class ComponentExemple : Component
    {
        public override void Render()
        {
            int val1 = Use(ExempleFields.exempleField1);
            float val2 = Use(ExempleFields.exempleField2);
            string val3 = Use(ExempleFields.exempleField3);
            // Debug.Log($"ComponentExemple {val1} {val2} {val3} ");
        }
    }
}