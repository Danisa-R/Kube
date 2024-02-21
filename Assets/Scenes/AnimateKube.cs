using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateKube : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public float friendDetectionRadius = 3f;

    private void Update()
    {
        // Move kube forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotate kube left and right based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        // Check for nearby friend kubes
        Collider[] colliders = Physics.OverlapSphere(transform.position, friendDetectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("FriendKube"))
            {
                // Interact with the friend kube
                InteractWithFriendKube(collider.gameObject);
            }
        }
    }

    private void InteractWithFriendKube(GameObject friendKube)
    {
        Debug.Log("Found a friend kube!");
        
        // TODO: you could make the friend kube follow the kube, join a group, etc.
    }
}
