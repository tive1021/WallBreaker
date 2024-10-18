using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public GameObject[] items; 
    public float fixedY = 5.0f; 
    public float minX = -2.35f;
    public float maxX = 2.35f; 
    public float spawnInterval = 5.0f; 

    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true) 
        {
            SpawnRandomItem();
            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    void SpawnRandomItem()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, fixedY);

        if (SceneManager.GetActiveScene().name == "InfinityModeScene")
        {
            Instantiate(items[1], spawnPosition, Quaternion.identity);
        }
        else
        {
            int randomIndex = Random.Range(0, items.Length);
            Instantiate(items[randomIndex], spawnPosition, Quaternion.identity);
        }
    }

}
