using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeSpawnPoint;
    public float throwForce;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSpawnPoint.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSpawnPoint.forward * throwForce);
        }
    }
}
