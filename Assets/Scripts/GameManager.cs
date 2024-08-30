using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject inventoryUI;
    private bool isShopOpen = false;
    private bool isInventoryOpen = false;

    private void Awake()
    {
        Instance = this;
        InputManager = new InputManager();
        shopUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    public void OpenCloseShopUI() 
    {
        if (!isShopOpen)
        {
            ShopManager.Instance.DisplayInventoryItens();
            shopUI.SetActive(true);
            InputManager.DisableMovement();
            isShopOpen = true;
        }
        else
        {
            //ShopManager.Instance.DestroyInventoryItens();
            shopUI.SetActive(false);
            InputManager.EnableMovement();
            isShopOpen = false;
        }
    }

    public void OpenCloseInventory()
    {
        if (!isInventoryOpen)
        {
            inventoryUI.SetActive(true);
            InputManager.DisableMovement();
            isInventoryOpen = true;
        }
        else
        {
            inventoryUI.SetActive(false);
            InputManager.EnableMovement();
            isInventoryOpen = false;
        }
    }

    public void TrasnferItemToInventory(Item item)
    {
        playerInventory.UpdateInventory(item);
    }

}
