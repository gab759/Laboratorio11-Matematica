using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    public float jumpForce = 5f;
    public float fallRotationSpeed = 2f;
    public float distance = 3f;
    public float correctionForce = 4f;
    public Transform cameraTransform;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0, _rigidBody.velocity.z); 
            _rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        float angle = Mathf.Clamp(_rigidBody.velocity.y * fallRotationSpeed, -90f, 45f);
        transform.rotation = Quaternion.Euler(angle, -90, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Debug.Log("Si colisiono");
            Vector3 position = transform.position + Vector3.left * distance;
            transform.position = position;

            Vector3 verticalCorrection = Vector3.down * correctionForce;
            _rigidBody.AddForce(verticalCorrection, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            Debug.Log("Game Over");
        }
    }
}
