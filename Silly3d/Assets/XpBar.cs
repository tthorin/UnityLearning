
using System;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    Slider slider;
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        slider = GetComponent<Slider>();
        slider.value = 0;
    }

    public void SetMaxXp(int maxXp)
    {
        slider.maxValue = maxXp;
    }
    public void SetXp(int xp)
    {
        slider.value = xp;
    }
    public void SetText(string text)
    {
        this.text = text;
    }

    internal void Reset()
    {
        slider.value = 0;
    }
}
