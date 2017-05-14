using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
    public GameObject characterToFollow;
    public float scrollingSpeed, zoomingSpeed;

	void Update() 
    {
        if (characterToFollow != null)
            FollowSoldier();
        else
            MovingCameraWithMouse();

        Zooming();
	}

    void FollowSoldier()
    {
        Vector3 pos = transform.position;
        pos.x = characterToFollow.transform.position.x;
        pos.y = characterToFollow.transform.position.y + 10;
        pos.z = characterToFollow.transform.position.z - 10;

        transform.position = pos;
    }

    void MovingCameraWithMouse()
    {
        int boundary = 30;

//        if (Input.mousePosition.x > Screen.width - boundary)
//        {
//            transform.position += new Vector3(scrollingSpeed * Time.deltaTime, 0, 0);
//        }
//        else if (Input.mousePosition.x < 0 + boundary)
//        {
//            transform.position -= new Vector3(scrollingSpeed * Time.deltaTime, 0, 0);
//        }
//     
//        if (Input.mousePosition.y > Screen.height - boundary)
//        {
//            transform.position += new Vector3(0, 0, scrollingSpeed * Time.deltaTime);
//        }
//        else if (Input.mousePosition.y < 0 + boundary)
//        {
//            transform.position -= new Vector3(0, 0, scrollingSpeed * Time.deltaTime);
//        }

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * scrollingSpeed * Time.deltaTime;

        transform.position = new Vector3(
            transform.position.x, 
            Mathf.Clamp(transform.position.y, 7, 40),
            transform.position.z);
    }

    void Zooming()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            GetComponent<Camera>().orthographicSize += zoomingSpeed;
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            GetComponent<Camera>().orthographicSize -= zoomingSpeed;

        GetComponent<Camera>().orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize, 10, 40);
    }
}
