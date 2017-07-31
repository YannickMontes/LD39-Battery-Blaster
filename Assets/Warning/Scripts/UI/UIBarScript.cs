using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIBarScript : MonoBehaviour
{

    [SerializeField]
    private float fillValue;

    [SerializeField]
    private Image barContent;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Text textValue;

    public float MaxValue
    {
        get; set;
    }

    public float Value
    {
        set
        {
            fillValue = CalculateFillAmountFromValue(value, 0, MaxValue);
            if(textValue != null)
                textValue.text = value.ToString();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        if (fillValue != barContent.fillAmount)
        {
            barContent.fillAmount = Mathf.Lerp(barContent.fillAmount, fillValue, Time.deltaTime * lerpSpeed);
        }
    }

    private float CalculateFillAmountFromValue(float value, float inMin, float inMax)
    {
        return (value - inMin) / (inMax - inMin);
    }
}
