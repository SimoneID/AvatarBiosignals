using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_to_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
