using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Component
    {
        private List<IFieldSubscription> _subscriptions = new();

        public T Use<T>(ObservableField<T> field) // использовать в компоненте свойство ObservableField (компонент будет наблюдать за изменением ObservableField)
        {
            field.Subscribe(this);
            _subscriptions.Add(new FieldSubscription<T>(field, this));
            return field.Value;
        }

        public void Use<T>(ObservableField<T> field, out T value)
        {
            field.Subscribe(this);
            _subscriptions.Add(new FieldSubscription<T>(field, this));
            value = field.Value;
        }

        // Универсальный интерфейс для хранения подписок
        private interface IFieldSubscription
        {
            void Unsubscribe();
        }

        // сохраняем и компонент и ObservableField чтобы потом удобно отписаться
        private class FieldSubscription<T> : IFieldSubscription
        {
            private ObservableField<T> _field;
            private Component _component;

            public FieldSubscription(ObservableField<T> field, Component component)
            {
                _field = field;
                _component = component;
            }

            public void Unsubscribe()
            {
                _field.Unsubscribe(_component);
            }
        }

        public virtual void Dispose() // при уничтожении компонента он отпишется от всех ObservableField
        {
            foreach (var sub in _subscriptions)
                sub.Unsubscribe();

            _subscriptions.Clear();
        }

        public virtual void Render() { }
    }


    public class ComponentNamed : Component
    {
        public UINames Name { get; private set; }

        public ComponentNamed(UINames UIName) : base() //дать компоненту имя и зарегистрировать его
        {
            Name = UIName;
            Components.Reg(this);
        }
    }


    // public class Component
    // {
    //     public UINames Name { get; private set; }
    //     public Component(UINames UIName)
    //     {
    //         Name = UIName;
    //         Components.RegUI(this);
    //     }

    //     protected T GetParm<T>(ObservableField<T> observableField)
    //     {
    //         observableField.Subscribe(this);
    //         return observableField.Value;
    //     }

    //     public virtual void Render()
    //     {
    //         Debug.Log($"Rendering {Name}");
    //     }
    // }
}