using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Image itemImage;
    private Button selectItemButton;
    private Item storedItem;

    public event Action<ShopItemDisplay> OnItemSelected;

    private void Awake()
    {
        selectItemButton = GetComponent<Button>();
        selectItemButton.onClick.AddListener(InvokeOnItemSelected);
    }

    public void PopulateDisplay(Item item)
    {
        nameText.text = item.name;
        priceText.text = item.price.ToString();
        itemImage.sprite = item.image; 
        storedItem = item;
    }

    private void InvokeOnItemSelected()
    {
        OnItemSelected?.Invoke(this);
    }

    public Item GetItem()
    {
        return storedItem;
    }
}
