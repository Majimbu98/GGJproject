using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent: MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); 
        float mouseY = Input.GetAxis("Mouse Y");

        transform.RotateAround(player.position, player.up, mouseX * speed * Time.deltaTime);
        transform.RotateAround(player.position, transform.right, -mouseY * speed * Time.deltaTime);
    }
}
