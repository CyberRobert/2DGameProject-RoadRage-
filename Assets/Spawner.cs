using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    public GameObject carPrefab;
    public GameObject semiPrefab;
    void Start()
    {
        StartCoroutine(SpawnTraffic()); // starts spawning the traffic
    }

    void Update()
    {
        
    }

    void cars()
    {
        /** if the spawner in on the left side of the highway = spawn 
        cars facing down and with a faster speed, else = spawn them 
        facing up **/
        if (transform.position.x < -1) 
        {
            Traffic traffic = Instantiate(carOrSemi(), transform.position, Quaternion.Euler(0, 0, 180)).GetComponent<Traffic>();
            traffic.Speed = 10f;
        }
        else
        {
            Instantiate(carOrSemi(), transform.position, transform.rotation);
        }
    }

    IEnumerator SpawnTraffic()
    {
        while (true)
        {
            int randomDelay = Random.Range(6, 18);
            yield return new WaitForSeconds(randomDelay);
            cars();
        }
    }

    GameObject carOrSemi()
    {
        System.Random rand = new System.Random();
        double randomValue = rand.NextDouble();
        bool spawnSemi = randomValue < 0.1; // 10% chance to spawn a semi
        if (spawnSemi)
        {
            return semiPrefab;
        } else
        {
            return carPrefab;
        }
    }
}
