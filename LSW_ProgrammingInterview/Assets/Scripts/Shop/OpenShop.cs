using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Inventory;
    public GameObject welcomeSpeech, exitSpeech;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(OpenShopRoutine());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(CloseShopRoutine());
    }

    IEnumerator OpenShopRoutine()
    {
        welcomeSpeech.SetActive(true);
        
        yield return new WaitForSeconds(2.5f);

        welcomeSpeech.SetActive(false);
        Shop.SetActive(true);
        Inventory.SetActive(true);
    }

    IEnumerator CloseShopRoutine()
    {
        Shop.SetActive(false);
        Inventory.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        exitSpeech.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        exitSpeech.SetActive(false);    

        
    }
}
