using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    [SerializeField] GameObject gameoverScreen;
    [SerializeField] float secondsPerDegradationTick;
    [SerializeField] float hungerDegradationRate;
    [SerializeField] float boredomDegradationRate;
    [SerializeField] float boredomIncreaseRate;
    public SpriteRenderer hat;
    public TMP_Text moneyText;
    public Slider hungerBar;
    public Slider boredomBar;
    public string petName;
    public float hunger;
    public float boredom;
    public int money;
    [SerializeField] AudioManager audioManager;

    IEnumerator DegradeHunger()
    {
        ChangeStatValue(ref hunger, hungerBar, -hungerDegradationRate);
        yield return new WaitForSeconds(secondsPerDegradationTick);
        if (hungerBar.value > 0) StartCoroutine(DegradeHunger());
        else
        {
            gameoverScreen.gameObject.SetActive(true);
            hungerBar.value = 0;
            audioManager.PlaySFX(audioManager.audioSource, audioManager.randomAudioClips, 1);

        }
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
        audioManager = GameObject.Find("_Scripts").GetComponent<AudioManager>();

    }
    public void OnMouseDown()
    {
        ChangeStatValue(ref boredom, boredomBar, boredomIncreaseRate);
        ChangeStatValue(ref money, 5, moneyText);
        audioManager.PlaySFX(audioManager.audioSource, audioManager.randomAudioClips, 4);
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
