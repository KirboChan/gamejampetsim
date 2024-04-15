using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject food;

    void ToggleGameObject(GameObject go)
    {
       go.SetActive(!go.activeSelf);
    }
    public void ToggleInventory()
    {
        ToggleGameObject(inventory);
    }
    public void ToggleFood()
    {
        ToggleGameObject(food);
    }
    public void ToggleShop()
    {
        ToggleGameObject(shop);
    }
}
