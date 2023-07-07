using UnityEngine;
using UnityEngine.UI;


public class ShopSlot : MonoBehaviour
{
    public Image icon;
    public Item item;
    public Text price;

    private void Start()
    {
        price.text = item.price.ToString();
    }

    public void ItemSold()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        price.enabled = false;
    }
}
