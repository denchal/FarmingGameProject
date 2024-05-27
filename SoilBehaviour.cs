using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilBehaviour : MonoBehaviour
{
    public string contains;
    public bool isEmpty = true;
    public GameObject containsGO;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (containsGO == null) {
            isEmpty = true;
            contains = "";
        }
    }
}
