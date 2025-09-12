using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Event : MonoBehaviour
{
    [Header("Assign the door GameObject to rotate")]
    public Transform door;
    public Vector3 openRotation = new Vector3(0, 90, 0); // Door open rotation (Y axis)
    public Vector3 closedRotation = new Vector3(0, 0, 0); // Door closed rotation
    public float openCloseSpeed = 2f;

    private bool isOpen = false;
    private bool playerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen; // Toggle door state
        }

        if (door != null)
        {
            Quaternion targetRotation = Quaternion.Euler(isOpen ? openRotation : closedRotation);
            door.rotation = Quaternion.Lerp(door.rotation, targetRotation, Time.deltaTime * openCloseSpeed);
        }
    }
}