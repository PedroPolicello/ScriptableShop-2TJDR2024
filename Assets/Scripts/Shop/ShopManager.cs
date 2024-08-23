using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [SerializeField] private Inventory shopInventory;
    [SerializeField] private ShopItemDisplay shopItemPrefab;

    [SerializeField] private ShopItemDisplay[] itensInShop;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
    }

    public void DisplayInventoryItens()
    {
        foreach (Item item in shopInventory.itens)
        {
            ShopItemDisplay itemToDisplay = Instantiate(shopItemPrefab, this.transform);
            itemToDisplay.PopulateDisplay(item);
        }
            itensInShop = GetComponentsInChildren<ShopItemDisplay>();
    }

    public void DestroyInventoryItens()
    {
        foreach (ShopItemDisplay item in itensInShop)
        {
            Destroy(item.gameObject);
        }
    }
}
