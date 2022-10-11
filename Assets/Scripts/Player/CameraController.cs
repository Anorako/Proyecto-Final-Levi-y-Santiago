using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform objetoASeguir;
    [SerializeField]
    private float velocidadCamara = 120;
    [SerializeField]
    private float sensibilidad = 150;

    private float mouseX;
    private float mouseY;
    private float rotY = 0;
    private float rotX = 0;

    private void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * sensibilidad * Time.deltaTime;
        rotX -= mouseY * sensibilidad * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -60, 60);
        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetoASeguir.position, velocidadCamara * Time.deltaTime);
    }
}
