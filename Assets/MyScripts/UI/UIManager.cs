using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Ссылки на панели меню и инвентаря
    public GameObject menuPanel;
    public GameObject inventoryPanel;

    void Awake()
    {
        if (menuPanel == null) menuPanel = GameObject.Find("Menu");
        if (inventoryPanel == null) inventoryPanel = GameObject.Find("Inventory");
        CloseAll();
    }

    public void CloseAll()
    {
        menuPanel.SetActive(false);  // Открыть меню
        inventoryPanel.SetActive(false); // Закрыть инвентарь, если он открыт
    }

    public void OpenMenu() { menuPanel.SetActive(true); }
    public void CloseMenu() { menuPanel.SetActive(false); }

    // Метод для открытия/закрытия меню
    public void ToggleMenu()
    {
        CloseAll();
        menuPanel.SetActive(true);
    }

    // Метод для открытия/закрытия инвентаря
    public void ToggleInventory()
    {
        CloseAll();
        inventoryPanel.SetActive(true);
    }
}