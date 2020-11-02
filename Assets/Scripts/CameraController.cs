using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public float camSpeed;



    
    void Update()
    {
        transform.Translate(Vector3.right * camSpeed * Time.deltaTime);

    }
}
