using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    private float timeElapsed;
    [SerializeField] private float spawnTime = 2.5f;
    [SerializeField] private GameObject itemsPrefab;
    [SerializeField] private int poolSize = 5;

    private GameObject[] items;
    private int itemsCount;

    // Start is called before the first frame update
    void Start()
    {
        PrepareItems();
    }

    void PrepareItems()
    {
        GameObject parent = GameObject.Find("Items");
        items = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            items[i] = Instantiate(itemsPrefab, parent.transform);
            items[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > spawnTime && Input.GetKey("space"))
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        timeElapsed = 0f;
        SetItem();
        itemsCount++;

        if (itemsCount == poolSize)
        {
            itemsCount = 0;
        }
    }

    void SetItem()
    {
        Vector3 spawnPosition = gameObject.GetComponent<Rigidbody>().position;
        items[itemsCount].transform.position = spawnPosition;

        if (!items[itemsCount].activeSelf)
        {
            items[itemsCount].SetActive(true);
        }
    }
}
