using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Food Type" , menuName = "Scriptable Objects/Food Type") ]
public class FoodSO : ScriptableObject
{
    public string foodName;
    public int price;
    [Range(0f, 100f)]
    public float healAmount;
    public Sprite foodImage;
}
