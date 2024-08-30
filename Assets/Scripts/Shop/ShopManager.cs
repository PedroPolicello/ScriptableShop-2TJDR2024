using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [SerializeField] private Inventory shopInventory;
    [SerializeField] private ShopItemDisplay shopItemPrefab;
    [SerializeField] private ShopItemDisplay[] itensInShop;

    [SerializeField] private Button buyItemButton;
    private ShopItemDisplay selectedDisplay;
    private Item selectedItem;

    private void Awake()
    {
        Instance = this;
        buyItemButton.onClick.AddListener(BuySelectedItem);
    }

    private void BuySelectedItem()
    {
        shopInventory.itens.Remove(selectedItem);
        Destroy(selectedDisplay.gameObject);
        GameManager.Instance.TrasnferItemToInventory(selectedItem);
    }

    public void DisplayInventoryItens()
    {
        foreach (Item item in shopInventory.itens)
        {
            ShopItemDisplay itemToDisplay = Instantiate(shopItemPrefab, this.transform);
            itemToDisplay.PopulateDisplay(item);

            itemToDisplay.OnItemSelected += StoreSelectedItem;
        }
            itensInShop = GetComponentsInChildren<ShopItemDisplay>();
    }

    //public void DestroyInventoryItens()
    //{
    //    foreach (ShopItemDisplay item in itensInShop)
    //    {
    //        Destroy(item.gameObject);
    //    }
    //}

    private void StoreSelectedItem(ShopItemDisplay selectedDisplay)
    {
        selectedItem = selectedDisplay.GetItem();
        this.selectedDisplay = selectedDisplay;
    }
}
