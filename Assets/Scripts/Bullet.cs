using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody bulletTransform;
    private Vector2 direction;
    float force = 5.0f;

    private void Start()
    {
        mainCamera = Camera.main;
        bulletTransform = GetComponent<Rigidbody>();
        direction = Input.mousePosition - mainCamera.WorldToScreenPoint(transform.position);
    }

    private void FixedUpdate()
    {
        bulletTransform.AddForce(direction.normalized * force);
    }
}
