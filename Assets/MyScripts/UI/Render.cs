using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIRender : MonoBehaviour
    {
        public Component ComponentExemple;
        protected float statUpdateTimer = 0f;
        protected const float StatUpdateInterval = 3f;

        void Awake()
        {
            ComponentExemple = new ComponentExemple();
            Components.MarkForRender(ComponentExemple);
        }

        void LateUpdate()
        {
            Components.Render();
        }

        void FixedUpdate()
        {
            // statUpdateTimer += Time.deltaTime;

            // if (statUpdateTimer >= StatUpdateInterval)
            // {
            //     ExempleFields.exempleField2.Value += statUpdateTimer;
            //     statUpdateTimer = 0f;
            // }
        }

        void OnDestroy()
        {
            ComponentExemple?.Dispose();
        }
    }
}