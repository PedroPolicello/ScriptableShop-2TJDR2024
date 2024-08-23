using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "ScriptableObjects/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itens; 
}
