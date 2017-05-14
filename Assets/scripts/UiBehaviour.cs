using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBehaviour : MonoBehaviour 
{
    public GameObject container;
    public float delay;
    public string message;
    GameObject info;
    float timer = 0;
    bool doCountTime;

    void Update()
    {
        if (doCountTime)
        {
            timer += Time.deltaTime;

            if (timer > delay)
            {
                ShowMessage();
            }
        }
    }

    public void PointerEntersButton(string message)
    {
        doCountTime = true;
        this.message = message;
    }

    public void PointerExitsButton()
    {
        doCountTime = false;
        timer = 0;
        message = null;

        if (info != null)
        {
            Destroy(info);
            info = null;   
        }
    }

    void ShowMessage()
    {
        doCountTime = false;

        container.transform.GetChild(0).GetComponent<Text>().text = message;
        info = Instantiate(container, Input.mousePosition, new Quaternion(0, 0, 0, 0), transform);
    }
}