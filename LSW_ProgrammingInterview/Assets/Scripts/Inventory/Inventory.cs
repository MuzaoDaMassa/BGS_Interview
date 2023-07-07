using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory detected!");
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int coins = 0;
    public int space = 8;

    public List<Item> items = new List<Item>();

    public GameObject head, torso, legs, belt;
    public GameObject shopUI;

    private Shop shop;

    private void Start()
    {
        shop = GetComponent<Shop>();
    }

    public void Add(Item item)
    {
        if (items.Count >= space || coins < item.price)
        {
            return;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return;
    }

    public void EquipOrSellItem()
    {
        if (shopUI.activeInHierarchy)
        {
            SellItem();
        }
        else
        {
            EquipIem();
        }
    }

    private void EquipIem()
    {
        string item = EventSystem.current.currentSelectedGameObject.GetComponentInParent<InventorySlot>().name;
        string slot = Regex.Match(item, @"\d+").Value;
        int slotNumber;
        int.TryParse(slot, out slotNumber);

        string itemName = items[slotNumber].name;

        if (itemName.Contains("Torso"))
        {
            torso.GetComponent<SpriteRenderer>().sprite = items[slotNumber].icon;
        }
        else if (itemName.Contains("Legs"))
        {
            legs.GetComponent<SpriteRenderer>().sprite = items[slotNumber].icon;
        }
        else if (itemName.Contains("Head"))
        {
            head.GetComponent<SpriteRenderer>().sprite = items[slotNumber].icon;
        }
        else if (itemName.Contains("Belt"))
        {
            belt.GetComponent<SpriteRenderer>().sprite = items[slotNumber].icon;
        }
    }

    private void SellItem()
    {
        string item = EventSystem.current.currentSelectedGameObject.GetComponentInParent<InventorySlot>().name;
        string slot = Regex.Match(item, @"\d+").Value;
        int slotNumber;
        int.TryParse(slot, out slotNumber);

        coins += items[slotNumber].sellValue;

        items.Remove(items[slotNumber]);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return;
    }
}
