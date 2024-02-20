using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public void activateSpawner()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        Instantiate(enemy, transform.position, transform.rotation);
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
