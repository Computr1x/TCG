﻿using ExNihilo.Base.Interfaces;

namespace ExNihilo.Base.Abstract;

public abstract class GenericProperty<T> : Property where T : class
{
    protected bool ValueIsRandomized { get; set; } = false;

    T _value;
    public T Value { 
        get => _value; 
        set
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            ValueIsRandomized = false;
        }
    }

    T _defaultValue;
    public virtual T DefaultValue {
        get => _defaultValue;
        set => _defaultValue = value;
    }

    public GenericProperty(T defaultValue)
    {
        DefaultValue = defaultValue;
    }

    public override void Randomize(Random r, bool force = false)
    {
        if (Value != null && !ValueIsRandomized && !force)
            return;

        RandomizeImplementation(r); 
        ValueIsRandomized = true; 
    }
    protected abstract void RandomizeImplementation(Random r);

    public virtual GenericProperty<T> WithValue(T value)
    {
        Value = value;
        return this;
    }

    public static implicit operator T(GenericProperty<T> genericValue) => genericValue.Value ?? genericValue.DefaultValue;  
}
