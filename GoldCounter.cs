using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    public Text goldDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldDisplay.text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().goldAmount.ToString();
    }
}
