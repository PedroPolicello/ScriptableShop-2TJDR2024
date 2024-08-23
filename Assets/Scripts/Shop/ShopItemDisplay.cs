using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Image itemImage;

    public void PopulateDisplay(Item item)
    {
        nameText.text = item.name;
        priceText.text = item.price.ToString();
        itemImage.sprite = item.image; 
    }
}
