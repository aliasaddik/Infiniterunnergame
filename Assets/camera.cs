using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffSet;
    private Vector3 initialpos;

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        initialpos = transform.position;
        startOffSet = transform.position - lookAt.position;

        
    }

    // Update is called once per frame
    void Update()

    {
        transform.position = new Vector3(lookAt.position.x + startOffSet.x, initialpos.y, initialpos.z);
    }
}
