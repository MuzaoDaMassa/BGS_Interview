using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public Transform itemsParent;
    public List<Item> items = new List<Item>();

    public bool isShopOpen = false;

    Inventory inventory;
    ShopSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PopulateItems());

        inventory = Inventory.instance;    
    }

    // Update is called once per frame
    void Update()
    {
        isShopOpen = itemsParent.gameObject.activeInHierarchy;
    }

    public void BuyItem()
    {
        ShopSlot slot = EventSystem.current.currentSelectedGameObject.GetComponentInParent<ShopSlot>();
        string boughtItem = slot.item.name;

        for (int i = 0; i < items.Count; i++)
        {
            if (boughtItem == items[i].name)
            {
                if (inventory.coins >= items[i].price)
                {
                    inventory.Add(items[i]);
                    inventory.coins -= items[i].price;
                    slot.ItemSold();
                }
            }
        }
    }

    private IEnumerator PopulateItems()
    {
        while (!isShopOpen)
        {
            yield return new WaitForSeconds(1);
        }

        slots = itemsParent.GetComponentsInChildren<ShopSlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            Item item = slots[i].GetComponent<ShopSlot>().item;
            items.Add(item);
        }

        yield break;
    }
}
