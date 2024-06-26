using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridElement : MonoBehaviour
{
    [SerializeField] FoodSO foodType;
    [SerializeField] HatSO hatType;
    [SerializeField] Pet inGamePet;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemCost;
    [SerializeField] Image portrait;
    [SerializeField] AudioManager audioManager;
    public void FoodSelect()
    {
        if (inGamePet.money >= foodType.price)
        {
            inGamePet.ChangeStatValue(ref inGamePet.money, -foodType.price, inGamePet.moneyText);
            inGamePet.ChangeStatValue(ref inGamePet.hunger, inGamePet.hungerBar, (foodType.healAmount * 0.01f));
            audioManager.PlaySFX(audioManager.audioSource, audioManager.randomAudioClips, 0);
        }
    }

    public void HatSelect()
    {
        if(inGamePet.money >= hatType.price)
        {
            inGamePet.ChangeStatValue(ref inGamePet.money, -hatType.price, inGamePet.moneyText);
            inGamePet.hat.sprite = hatType.graphic;
            audioManager.PlaySFX(audioManager.audioSource, audioManager.randomAudioClips, 3);
        }
        
    }
    public void Start()
    {

        audioManager = GameObject.Find("_Scripts").GetComponent<AudioManager>();
        if (foodType != null)
        {
            itemName.text = foodType.name;
            portrait.sprite = foodType.foodImage;
            itemCost.text = $"Cost: {foodType.price}";
        }
        else 
        {
            itemName.text = hatType.name;
            portrait.sprite = hatType.graphic;
            itemCost.text = $"Cost: {hatType.price}";
        }
        

    }
}
