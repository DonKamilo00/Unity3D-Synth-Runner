using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{




    public float fallDelay = 0.1f;

    void OnCollisionEnter(Collision collidedWithThis)
    {

        int chance = Random.Range(1, 100);

        Debug.Log(chance);

        if (collidedWithThis.gameObject.name == "Player" && chance > 1)
        {
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
    
