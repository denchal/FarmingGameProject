using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    public class data {
        public int goldAmount;
        public List<int> plantAmounts;
        public int plotsBuilt;
        public List<string> plots;
        public List<Vector3> plotPositions;
    }
    public GameObject prefab;
    public GameObject soil;
    // Start is called before the first frame update
    void Start()
    {
        Load(MainMenu.newGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save() {
        data saveData = new data();
        saveData.goldAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().goldAmount;
        saveData.plantAmounts = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantAmounts;
        saveData.plotsBuilt = MainScript.plotsBuilt;
        saveData.plotPositions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().plotPositions;
        saveData.plots = new List<string>();
        foreach(GameObject soil in GameObject.FindGameObjectsWithTag("Soil")){
            saveData.plots.Add(soil.GetComponent<SoilBehaviour>().contains);
        }
        string dataOut = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.dataPath + "/save.txt", dataOut);
    }

    public void Load(bool newGame) {
        string path = Application.dataPath + "/save.txt";
        string rawData = File.ReadAllText(path);
        data saveData = JsonUtility.FromJson<data>(rawData);
        if (!newGame) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().goldAmount = saveData.goldAmount;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantAmounts = saveData.plantAmounts;
            MainScript.plotsBuilt = saveData.plotsBuilt;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().plotPositions = saveData.plotPositions;
            foreach (Vector3 position in saveData.plotPositions) {
                Instantiate(prefab, position, Quaternion.identity);
                Instantiate(soil, position, Quaternion.identity);
            }
            for (int i = 0; i<saveData.plots.Count; i++) {
                if (saveData.plots[i] != "") {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().PlantAmounts[MainScript.PlantNameToInt(saveData.plots[i])] += 1;
                }
            }
        }
    }
}
