using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public int health = 10;
    public GameObject hud;
    public float speed = 5;

    public

    void Start()
    {

    }
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }
        hud.transform.LookAt(Camera.main.transform);
    }


    void Movement(float horizontal, float vertical)
    {
        Vector3 targetPostion = Vector3.zero;
        targetPostion.x = transform.position.x + (vertical * speed * Time.deltaTime);
        targetPostion.y = transform.position.y;
        targetPostion.z = transform.position.z + (horizontal * -speed * Time.deltaTime);

        Rigidbody body = GetComponent<Rigidbody>();

        body.MovePosition(targetPostion);
    }
}
