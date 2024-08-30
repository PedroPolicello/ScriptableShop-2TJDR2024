using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemText;

    public event Action<InventoryItemDisplay> OnItemSelected;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(InvokeOnItemSelected);  
    }

    private void InvokeOnItemSelected()
    {
        OnItemSelected?.Invoke(this);
    }

    public void PopulateDisplay(Item item)
    {
        itemText.text = item.name;
        itemImage.sprite = item.image;
    }
}
