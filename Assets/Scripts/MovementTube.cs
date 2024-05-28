using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTube : MonoBehaviour
{
    private Rigidbody _compRigidBody;
    float speed = -5f;
    private void Awake()
    {
        _compRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _compRigidBody.velocity = new Vector3(speed, _compRigidBody.velocity.y, _compRigidBody.velocity.z);

    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Muro"))
        {
            Destroy(gameObject);

        }
    }
}
