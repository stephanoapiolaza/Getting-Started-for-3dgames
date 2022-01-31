using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform player1;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * this.sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * this.sensitivity * Time.deltaTime;
        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(xRotation, -90f, 75f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        this.player1.Rotate(Vector3.up * mouseX);
    }
}
