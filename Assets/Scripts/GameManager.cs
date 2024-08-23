using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [SerializeField] private GameObject shopUI;
    private bool isOpen = false;
    private void Awake()
    {
        Instance = this;
        InputManager = new InputManager();
        shopUI.SetActive(false);
    }

    public void OpenCloseShopUI() 
    {
        if (!isOpen)
        {
            ShopManager.Instance.DisplayInventoryItens();
            shopUI.SetActive(true);
            InputManager.DisableMovement();
            isOpen = true;
        }
        else
        {
            ShopManager.Instance.DestroyInventoryItens();
            shopUI.SetActive(false);
            InputManager.EnableMovement();
            isOpen = false;
        }
    }

}
