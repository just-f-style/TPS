using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    public float maxBurstSize;
    public float burstSpeed;

    void Start()
    {
        transform.localScale = Vector3.zero; 
    }
    void Update()
    {
        transform .localScale += Vector3.one * Time.deltaTime * burstSpeed;
        if(transform.localScale.x >= maxBurstSize) Destroy(gameObject);
    }
}
