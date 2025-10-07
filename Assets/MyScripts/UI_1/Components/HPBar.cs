using UnityEngine;

namespace UI_1
{
    public class HPBar : Component
    {
        public int val1;
        public HPBar(UINames UIName) : base()
        {
            Use(ExempleFields.exempleField1, out val1);
        }

        public override void Render()
        {
            // base.Render();
            Debug.Log($"[ComponentExemple] val1 = {val1}");
        }
    }
}