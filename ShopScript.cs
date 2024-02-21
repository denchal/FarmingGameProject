using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public bool isShopOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShopOpen) {
            this.GetComponent<CanvasGroup>().interactable = true;
            this.GetComponent<CanvasGroup>().alpha = 1;
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else {
            this.GetComponent<CanvasGroup>().interactable = false;
            this.GetComponent<CanvasGroup>().alpha = 0;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
}
