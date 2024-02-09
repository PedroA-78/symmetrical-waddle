using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Desk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciado");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;
        Debug.DrawRay(transform.position + new Vector3(0,1,0), Vector3.right * 2, Color.yellow);

        if (Physics.Raycast(transform.position + new Vector3(0,1,0), Vector3.right, out hit, 10f)) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Debug.Log("Hello");
                InventoryController.adding(transform.GetChild(1).name);
            }
        }

    }
}
