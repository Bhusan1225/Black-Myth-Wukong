
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  

    [SerializeField] GameObject spawnPrefab;

    [SerializeField] Vector3 spawnZoneMin;
    [SerializeField] Vector3 spawnZoneMax;

    [SerializeField] bool isPotionThere;
    
    private float countdownTimer = 0f;
    [SerializeField] float potionSwawnTime;
    bool isCountingDown = false;

    GameObject ImmobilizePotion;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 

    // Update is called once per frame
    void Update()
    {

        if (!isPotionThere)
        {
            potionSpawn();
        }

        if (isCountingDown)
        {
            countdownTimer -= Time.deltaTime;

            if (countdownTimer <= 0f)
            {
                DestroySpawnnedPotion();
            }

        }


    }
    private void potionSpawn()
    {
        isPotionThere = true;
        Vector3 randomSpawn = new Vector3(Random.Range(spawnZoneMin.x, spawnZoneMax.x), 1, Random.Range(spawnZoneMin.z, spawnZoneMax.z));
        ImmobilizePotion = Instantiate(spawnPrefab, randomSpawn, spawnPrefab.transform.rotation);
        countdownTimer = potionSwawnTime;
        isCountingDown = true;
    }

    public void DestroySpawnnedPotion()
    {
        Destroy(ImmobilizePotion);
        isPotionThere = false;
    }

   
}
