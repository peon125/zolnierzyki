using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderMovement : MonoBehaviour 
{
    public float speed, jumpValue;
    public bool isSelected;
    public GameObject selection, myPrivate;
    Vector3 prevPos;
    float timer;
    bool isGrounded;

    void Start()
    {
        isGrounded = true;
    }

    void FixedUpdate () 
    {
        if (isSelected)
            Move();
        else
            RandomMovement();

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, 0, 500),
            transform.position.y,
            Mathf.Clamp(transform.position.z, 0, 500));
    }

    void Update()
    {
        if (isSelected)
        {
            selection.transform.position = new Vector3 (transform.position.x, 
                GameObject.Find("Terrain").GetComponent<Terrain>().SampleHeight(transform.position) + 0.2f, 
                transform.position.z);
        }
    }

    void RandomMovement()
    {
        timer -= Time.deltaTime;
        transform.position += transform.forward * Time.deltaTime * speed;

        if (timer <= 0)
        {
            timer = Random.Range(2, 5);

            transform.rotation = Quaternion.Euler(0, (float)Random.Range(0,360), 0);
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        }

        if (Input.GetButton("Jump") && isGrounded)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z); //gdy nie zerowala sie predkosc y-owa, postac podczas wspinania sie pod gore wybijala sie wysoko w powietrze podczas skoku
            rigidbody.AddForce(new Vector3(0, jumpValue, 0), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            isGrounded = false;
        }
    }
}
