using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Stat
{

    [NonSerialized]
    [SerializeField]
    private UIBarScript bar;

    [SerializeField]
    private float currentValue;

    [SerializeField]
    private float maxValue;

    public UIBarScript Bar
    {
        get
        {
            return this.bar;
        }

        set
        {
            this.bar = value;
            this.bar.MaxValue = this.maxValue;
            this.bar.Value = this.currentValue;
        }
    }

    public float MaxValue
    {
        get
        {
            return this.maxValue;
        }

        set
        {
            this.maxValue = value;
            if (bar != null)
            {
                bar.MaxValue = this.maxValue;
            }
        }
    }

    public float CurrentValue
    {
        get
        {
            return this.currentValue;
        }

        set
        {
            this.currentValue = Mathf.Clamp(value, 0, MaxValue);
            if (bar != null)
            {
                bar.Value = this.currentValue;
            }
        }
    }

    public Stat(int max)
    {
        this.Initialize(max);
    }

    public void Initialize(int max, UIBarScript barUI = null)
    {
        if (barUI != null)
        {
            this.bar = barUI;
        }
        this.MaxValue = max;
        this.CurrentValue = max;
    }
}
