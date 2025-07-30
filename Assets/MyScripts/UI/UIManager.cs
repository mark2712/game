using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;



public class UIManager : MonoBehaviour
{
    // Ссылки на панели меню и инвентаря
    public GameObject MenuPanel;
    public GameObject InventoryPanel;
    public GameObject ConsolePanel;
    public GameObject PauseMenu;

    void Awake()
    {
        if (MenuPanel == null) MenuPanel = GameObject.Find("Menu");
        if (InventoryPanel == null) InventoryPanel = GameObject.Find("Inventory");
        if (ConsolePanel == null) ConsolePanel = GameObject.Find("Console");
        if (PauseMenu == null) PauseMenu = GameObject.Find("PauseMenu");
        CloseAll();
    }

    public void CloseAll()
    {
        MenuPanel.SetActive(false);  // Открыть меню
        InventoryPanel.SetActive(false); // Закрыть инвентарь, если он открыт
        ConsolePanel.SetActive(false);
        PauseMenu.SetActive(false);
    }

    // Метод для открытия/закрытия меню
    public void ToggleMenu(bool open)
    {
        CloseAll();
        MenuPanel.SetActive(open);
    }

    // Метод для открытия/закрытия инвентаря
    public void ToggleInventory(bool open)
    {
        CloseAll();
        InventoryPanel.SetActive(open);
    }

    public void ToggleConsole(bool open)
    {
        CloseAll();
        ConsolePanel.SetActive(open);
    }

    public void TogglePauseMenu(bool open)
    {
        CloseAll();
        PauseMenu.SetActive(open);
    }
}

