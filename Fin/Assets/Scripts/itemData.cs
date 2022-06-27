using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New Item")]
public class itemData : ScriptableObject
{
    public string name;
    public Sprite visual;
    public GameObject prefab;
}
