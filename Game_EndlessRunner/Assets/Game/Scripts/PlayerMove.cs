using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController _charController;

    public GameObject leftController;
    public GameObject rightController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
     
        float deltaX = Input.GetAxis("Horizontal") * speed;
         float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        // ***********************
        Debug.Log("leftController rotation: " + leftController.transform.rotation.x);
        Debug.Log("rightController rotation: " + rightController.transform.rotation.x);
        var lx = leftController.transform.rotation.x;
        var rx = (rightController.transform.rotation.x *-1);
        // 
        // ***********************
        Debug.Log("horizontal=" + Input.GetAxis("Horizontal"));
        transform.Translate(rx * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(lx * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
}
