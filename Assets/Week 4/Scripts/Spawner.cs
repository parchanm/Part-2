using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTimer;
    public float spawnRate = 3;
    float spawnPos = Random.Range(-5, 5);

    //public GameObject plane;
    public GameObject[] planeVariants;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = spawnTimer + Time.deltaTime;
        activateSpawner();
    }

    void activateSpawner()
    {
        if (spawnTimer > spawnRate)
        {
            int randomPlanes = Random.Range(0, planeVariants.Length);

            GameObject pickedPlane = Instantiate(planeVariants[randomPlanes]);
            //Instantiate(plane, transform.position, transform.rotation);
            spawnTimer = 0;
            //gameobject = gameobj random
            //vector3
        }
    }
}
