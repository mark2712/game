using System.Collections.Generic;

namespace UI
{
    public static class ExempleFields
    {
        public static ObservableField<int> exempleField1 = new(2);
        public static ObservableField<float> exempleField2 = new(12.7f);
        public static ObservableField<string> exempleField3 = new("exemple Field 3");
    }


    public class ObservableField<T>
    {
        private T _value;
        private HashSet<Component> subscribers = new();

        public T Value
        {
            get => _value;
            set => Set(value);
        }

        public ObservableField(T initialValue = default)
        {
            _value = initialValue;
        }

        public void Set(T newValue)
        {
            if (!Equals(_value, newValue))
            {
                _value = newValue;
                NotifySubscribers();
            }
        }

        public void Subscribe(Component component)
        {
            subscribers.Add(component); // при использовании свойства в компоненте это свойство запоминает в каких компонентах оно используется
        }

        public void Unsubscribe(Component component)
        {
            subscribers.Remove(component);
        }

        private void NotifySubscribers() // при изменении свойства оно пометит (перерендерись в конце кадра) все компоненты в которых оно используется
        {
            foreach (var component in subscribers)
            {
                Components.MarkForRender(component);
            }
        }
    }
}


// public interface IObservableData<T>
// {
//     T Value { get; set; }
//     void Subscribe(Component component);
//     void Unsubscribe(Component component);
// }