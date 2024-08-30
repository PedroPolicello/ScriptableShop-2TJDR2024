using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Button sellButton;
    [SerializeField] private Transform inventoryContainer;
    [SerializeField] private InventoryItemDisplay inventoryItemPrefab;
    private InventoryItemDisplay selectedDisplay;

    private void Awake()
    {
        DisplayInventoryItens();
    }

    public void DisplayInventoryItens()
    {
        foreach (Item item in inventory.itens)
        {
            InstantiatePopulateDisplay(item);
        }
    }

    private void InstantiatePopulateDisplay(Item item)
    {
        InventoryItemDisplay itemToDisplay = Instantiate(inventoryItemPrefab, inventoryContainer);
        inventoryItemPrefab.PopulateDisplay(item);
        inventoryItemPrefab.OnItemSelected += StoreSelectedItem;
    }

    private void StoreSelectedItem(InventoryItemDisplay selectedItem)
    {
        selectedDisplay = selectedItem;
    }

    public void UpdateInventory(Item item)
    {
        inventory.itens.Add(item);
        InstantiatePopulateDisplay(item);
    }
}
