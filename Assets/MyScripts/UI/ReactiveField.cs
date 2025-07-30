using System;

public class ReactiveField<T>
{
    private T _value;

    public T Value
    {
        get => _value;
        set => Set(value);
    }

    public event Action<T> OnChanged;

    public ReactiveField(T initialValue = default)
    {
        _value = initialValue;
    }

    public void Set(T newValue)
    {
        if (!Equals(_value, newValue))
        {
            _value = newValue;
            OnChanged?.Invoke(_value);
        }
    }

    public void ForceNotify()
    {
        OnChanged?.Invoke(_value);
    }

    public void Subscribe(Action<T> listener)
    {
        OnChanged += listener;
        listener(_value); // сразу вызвать с текущим значением
    }

    public void Unsubscribe(Action<T> listener)
    {
        OnChanged -= listener;
    }
}