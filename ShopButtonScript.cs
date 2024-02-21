using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(ShopSwitch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShopSwitch() {
        if (GameObject.Find("SellPanel").GetComponent<ShopScript>().isShopOpen) {
            GameObject.Find("SellPanel").GetComponent<ShopScript>().isShopOpen = !GameObject.Find("SellPanel").GetComponent<ShopScript>().isShopOpen;
        }
        GameObject.Find("ShopPanel").GetComponent<ShopScript>().isShopOpen = !GameObject.Find("ShopPanel").GetComponent<ShopScript>().isShopOpen;
    }
}
