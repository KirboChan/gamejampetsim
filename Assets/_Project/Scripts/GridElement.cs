
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridElement : MonoBehaviour
{
    [SerializeField] FoodSO foodType;
    [SerializeField] Pet inGamePet;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemCost;
    [SerializeField] Image portrait;
    public void FoodSelect()
    {
        Debug.Log($"Function called");
        if (inGamePet.money >= foodType.price)
        {
            inGamePet.ChangeStatValue(ref inGamePet.money, -foodType.price, inGamePet.moneyText);
            inGamePet.ChangeStatValue(ref inGamePet.hunger, inGamePet.hungerBar, (foodType.healAmount * 0.01f));
        }
        else Debug.Log("Not Enough Money!");
    }
    public void Start()
    {
        itemName.text = foodType.name;
        portrait.sprite = foodType.foodImage;
        itemCost.text = $"Cost: {foodType.price}";

    }
}
