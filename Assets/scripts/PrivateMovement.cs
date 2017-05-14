using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivateMovement : MonoBehaviour 
{
    public GameObject myCommander;
    public float speed, distanceToKeep;

	void Update()
    {
        transform.LookAt(myCommander.transform.position);

        if (Vector3.Distance(transform.position, myCommander.transform.position) > distanceToKeep)
        {
            bool toCommander = Vector3.Distance(transform.position, myCommander.transform.position) > distanceToKeep;
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
	}

    void Move(bool toCommander)
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}