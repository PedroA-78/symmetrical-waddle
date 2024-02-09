using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    static List<GameObject> items = new List<GameObject>();
    static int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
            items.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void adding(String name){
        foreach (var item in items) {
            Debug.Log(item.name == name);
            if (item.name == name) {
                Text textfield = item.transform.Find("Text").GetComponent<Text>();
                number = int.Parse(textfield.text);
                number++;
                textfield.text = number.ToString();
            }
        }
    }
    
}
