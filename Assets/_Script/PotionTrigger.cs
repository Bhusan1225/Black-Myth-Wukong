using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTrigger : MonoBehaviour
{


    [SerializeField] SpawnManager spawnManager;

    private void Start()
    {
       
    }
    //// Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

       

        if (other.GetComponent<CharacterMovement>() != null)
        {
            GameObject player = other.GetComponent<CharacterMovement>().gameObject;
            player.GetComponent<PotionCollector>().Collection();
            spawnManager.DestroySpawnnedPotion();
            Destroy(gameObject);
        }

    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    GameObject player = collision.gameObject.GetComponent<CharacterMovement>()?.gameObject;

    //    if (player != null)
    //    {
    //        player.GetComponent<PotionCollector>().Collection();
    //        spawnManager.DestroySpawnnedPotion();
    //        Destroy(gameObject);
    //    }
    //}
}
