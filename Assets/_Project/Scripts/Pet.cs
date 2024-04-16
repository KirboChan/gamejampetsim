using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    [SerializeField] float secondsPerDegradationTick;
    [SerializeField] float hungerDegradationRate;
    [SerializeField] float boredomDegradationRate;
    [SerializeField] float boredomIncreaseRate;
    public TMP_Text moneyText;
    public Slider hungerBar;
    public Slider boredomBar;
    public string petName;
    public float hunger;
    public float boredom;
    public int money;
    IEnumerator DegradeHunger()
    {
        ChangeStatValue(ref hunger, hungerBar, -hungerDegradationRate);
        yield return new WaitForSeconds(secondsPerDegradationTick);
        if(hungerBar.value > 0) StartCoroutine(DegradeHunger());
        else hungerBar.value = 0;
    }
    IEnumerator DegradeBoredom()
    {
        ChangeStatValue(ref boredom, boredomBar, -boredomDegradationRate);
        yield return new WaitForSeconds(secondsPerDegradationTick);
        if (boredomBar.value > 0) StartCoroutine(DegradeBoredom());
        else boredomBar.value = 0;
    }
    public void Start()
    {
        StartCoroutine(DegradeHunger());
        StartCoroutine(DegradeBoredom());
    }
    public void OnMouseDown()
    {
        ChangeStatValue(ref boredom, boredomBar, boredomIncreaseRate);
        ChangeStatValue(ref money, 5, moneyText);
    }

    public void ChangeStatValue(ref float stat , Slider bar , float amount)
    {
        if (bar.value <= 0 || bar.value >= 100) return;
        bar.value += amount;
        stat = bar.value * 100f;
    }
    public void ChangeStatValue(ref int stat , int amount, TMP_Text text)
    {
        stat += amount;
        text.text = $"Money: {stat}";
    }
}
