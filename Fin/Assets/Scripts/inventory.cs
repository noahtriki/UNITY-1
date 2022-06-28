using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    [SerializeField]
    public List<itemData> content = new List<itemData>();

    [SerializeField]
    private GameObject inventoryPanel;

    [SerializeField]
    private Transform inventorySlotsParent;

    const int InventorySize= 25;

    private void Start()
    {
        inventoryPanel.SetActive(false);
        RefreshContent();
    }

    public void Additem(itemData item)
    {
        content.Add(item);
        RefreshContent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

    public void RefreshContent()
    {
        for (int i = 0; i < content.Count; i++)
        {
            inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].visual;
        }
    }

    public bool IsFull()
    {
        return InventorySize == content.Count;
    }
}