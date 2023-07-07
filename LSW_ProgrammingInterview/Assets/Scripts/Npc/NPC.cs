using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Inventory inventory;

    public GameObject shop;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += SetTrigger;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isShopOpen", shop.activeInHierarchy);
    }

    void SetTrigger()
    {
        animator.SetTrigger("itemBought");
        animator.SetTrigger("itemSold");
    }
}
