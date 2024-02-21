using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyScript : MonoBehaviour
{
    public string plantName;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Buy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Buy() {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        if (player.goldAmount - MainScript.PlantBuyPrice(plantName) >= 0) {
            player.goldAmount -= MainScript.PlantBuyPrice(plantName);
            player.PlantAmounts[MainScript.PlantNameToInt(plantName)] += 1;
        }
    }
}
