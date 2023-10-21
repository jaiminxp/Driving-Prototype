using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float turnSpeed;
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera secondaryCamera;
    [SerializeField] KeyCode switchKey;

    private float horizontalInput;
    private float forwardInput;
    public string inputID;

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            secondaryCamera.enabled = !secondaryCamera.enabled;
        }
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // move the vehicle
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // turn the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
