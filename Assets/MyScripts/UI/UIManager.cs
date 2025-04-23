using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Ссылки на панели меню и инвентаря
    public GameObject menuPanel;
    public GameObject inventoryPanel;
    public GameObject consolePanel;

    void Awake()
    {
        if (menuPanel == null) menuPanel = GameObject.Find("Menu");
        if (inventoryPanel == null) inventoryPanel = GameObject.Find("Inventory");
        if (consolePanel == null) consolePanel = GameObject.Find("Console");
        CloseAll();
    }

    public void CloseAll()
    {
        menuPanel.SetActive(false);  // Открыть меню
        inventoryPanel.SetActive(false); // Закрыть инвентарь, если он открыт
    }

    // Метод для открытия/закрытия меню
    public void ToggleMenu(bool open)
    {
        CloseAll();
        menuPanel.SetActive(open);
    }

    public void ToggleConsole(bool open)
    {
        CloseAll();
        consolePanel.SetActive(open);
    }

    // Метод для открытия/закрытия инвентаря
    public void ToggleInventory(bool open)
    {
        CloseAll();
        inventoryPanel.SetActive(open);
    }
}