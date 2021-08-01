using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions; //Reference for Physics Interaction Class
public class MouseLook : MonoBehaviour
{
    public Transform playerBody; //FPS controller
    public float mouseSensitivity = 100f; //For Sensitivity control
    public float ShootingRange = 100f; //Range of gun

    Camera PlayerCam;// You can set this to public if you want
    void Start()
    {
        PlayerCam = gameObject.GetComponent<Camera>();//Get the camera attached
        Cursor.lockState = CursorLockMode.Locked; //To hide the cursor when running Unity. Press ESP to show the cursor
    }

    private void FixedUpdate()
    {
        CameraRotation();
        FireTheGun();
    }
    void Update()
    {
        
    }

    void FireTheGun()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 _hitpoint = PlayerCam.transform.forward;
            RaycastHit _hits = RayCastDraw.RayBullet(PlayerCam.transform.position, _hitpoint, ShootingRange);
            if (_hits.collider == null) //Check if enemy object detected if null return it
            {
                return;
            }
            if (_hits.transform.root.tag == "Enemy")
            {
                Debug.Log("You hit the object");
                //You put your function here if you hit the enemy
            }
        }
    }
    
    float xRotation = 0f;
    void CameraRotation()
    {
        //Get the mouse direction
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //Get the mouse direction
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // This is to limit the rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
