using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXSeconds : MonoBehaviour
{
    public float delay = 5f; // Delay in seconds before destroying the object

    // Start is called before the first frame update
    void Start()
    {
        // Call the DestroyObject() method after the specified delay
        Destroy(gameObject, delay);
    }
}
