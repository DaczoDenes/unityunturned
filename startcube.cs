using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startcube : MonoBehaviour
{
    public Rigidbody rigidbody3;
    void Start()
    {
        Vector3 temp = new Vector3(5f, 10f, 0f);
        gameObject.transform.position = temp;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -9)
        {
            StartCoroutine("Drop");
        }
    }
    IEnumerator Drop()
    {
        rigidbody3.velocity = Vector3.zero;
        yield return new WaitForSeconds(3);
        Vector3 temp = new Vector3(5f, 10f, 0f);
        gameObject.transform.position = temp;
    }
}
