using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/New Item")]
public class Item : ScriptableObject
{
    public string name;
    public int price;
    public Sprite image;
    public ItemType type;
    public ItemState state;
}
