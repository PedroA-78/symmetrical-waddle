using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
public class ResetProducts : MonoBehaviour
{
    public GameObject product, gondola;
    GameObject shelfChild;
    public float time = 3f;
    private float initTime;
    private int index;
    List<GameObject> shelfs = new List<GameObject>();
    List<string> products = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gondola.transform.childCount; i++) {
            if (gondola.transform.GetChild(i).ToString().Contains("Shelf")) {
                shelfs.Add(gondola.transform.GetChild(i).transform.gameObject);
            }
        }

        initTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            shelf();
            // if (shelfs.Count <= 1) {
            //     Debug.Log("Vazio");
            //     init();
            // } else {
            //     Debug.Log("Cheio");
            // }
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            GameObject shelf = selectShelf();
            GameObject product;

            if (shelf == null) {
                return;
            } else {
                product = selectProduct(shelf);
            }

            products.Add(product.name);
            Destroy(product);
        }

        // time -= Time.deltaTime;
        // if (time <= 0f) {
        //     GameObject shelf = selectShelf();
        //     GameObject product;

        //     if (shelfs.Count <= 0) {
        //         init();
        //     }

        //     if (shelf == null) {
        //         return;
        //     } else {
        //         product = selectProduct(shelf);
        //     }

        //     Destroy(product);

        //     time = initTime;
        // }
    }

    public GameObject selectProduct(GameObject shelf) {
        List<GameObject> products = new List<GameObject>();

        for (int i = 0; i < shelf.transform.childCount; i++) {
            GameObject product = shelf.transform.GetChild(i).transform.gameObject;

            if (product.transform.ToString().Contains("Cube F")) {
                products.Add(product);
            }
        }

        if (products.Count <= 0) {
            for (int i = 0; i < shelf.transform.childCount; i++) {
                products.Add(shelf.transform.GetChild(i).transform.gameObject);
            }
        }

        return products[Random.Range(0, products.Count)];
    }

    public GameObject selectShelf() {
        int index;
        while (shelfs.Count > 0) {
            index = Random.Range(0, shelfs.Count);
            if (!emptyShelf(shelfs[index])) {
                return shelfs[index];
            } else {
                shelfs.RemoveAt(index);
            }

        }

        return null;
    }

    public bool emptyShelf(GameObject shelf) {
        if (shelf.transform.childCount <= 0) {
            return true;
        } else {
            return false;
        }
    }

    public void init() {

        GameObject shelf;
        float coordX = 1f;

        for (int i = 0; i <= 3; i++) {
            shelf = gondola.transform.Find("Shelf " + i).transform.gameObject;
            for (int y = 0; y <= 4; y++) {
                GameObject productF = Instantiate(product);
                GameObject productB = Instantiate(product);

                productF.name = "Cube F" + y;
                productB.name = "Cube B" + y;

                productF.transform.SetParent(shelf.transform);
                productF.transform.localPosition = new Vector3(coordX,0,.25f);

                productB.transform.SetParent(shelf.transform);
                productB.transform.localPosition = new Vector3(coordX,0,-.25f);
                
                coordX -= .5f;
            }
                shelfs.Add(gondola.transform.GetChild(i + 1).transform.gameObject);
                coordX = 1f;
        }
    }

    public void shelf() {
        foreach (var shelf in shelfs) {
            for (int i = 0; i < 10; i++) {
                Debug.Log(shelf.name + ", " + shelf.transform.GetChild(i).name);
            }
        }
    }
}
