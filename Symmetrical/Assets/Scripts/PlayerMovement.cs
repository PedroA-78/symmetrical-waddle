using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform body;
    public Camera camera;
    public int speed = 15, sensibility = 100;
    float moveX, moveZ, mouseX;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
       moveX = Input.GetAxis("Horizontal");
       moveZ = Input.GetAxis("Vertical");

       mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;

       body.Rotate(Vector3.up * mouseX);

       Vector3 move = transform.right * moveX + transform.forward * moveZ;

       controller.Move(move * speed * Time.deltaTime);



        // Ray ray = camera.ScreenPointToRay(new Vector3((camera.pixelWidth - 1) / 2, (camera.pixelHeight - 1) / 2));
        // Debug.DrawRay(ray.origin, ray.direction * (int) 5f, Color.yellow); 

    }
}
