using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorNewMenu : MonoBehaviour
{
    Rigidbody rB;

    [SerializeField] private Vector3 _speed;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rB.AddForce(_speed);
        //rB.velocity = new Vector3(_speed.x, _speed.y, _speed.z);
        
        if(transform.position.z > 31)
        {
            Destroy(gameObject);
        }
    }
}
