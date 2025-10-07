using System.Collections.Generic;
using UnityEngine;

namespace UI_1
{
    public enum UINames
    {
        Exemple,
        Menu,
        Inventory,
        Console,
        PauseMenu,
    }

    public static class Components
    {
        public static Dictionary<UINames, ComponentNamed> components = new(); // все именованные компоненты в игре 
        public static HashSet<Component> ComponentsNeedRender = new(); // эти компоненты должны перерендерится в конце кадра

        public static Component GetUI(UINames UIName)
        {
            return components[UIName];
        }

        public static void Reg(ComponentNamed Component) // зарегистрировать именованный компонент
        {
            components.Add(Component.Name, Component);
        }

        public static void MarkForRender(Component Component) // добавить в очередь на рендер
        {
            ComponentsNeedRender.Add(Component);
        }

        public static void Render()
        {
            foreach (var component in ComponentsNeedRender)
            {
                component.Render();
            }
            ComponentsNeedRender.Clear(); // очищаем очередь после рендера
        }
    }
}