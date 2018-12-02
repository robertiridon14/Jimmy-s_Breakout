using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Transform doorRotation;
    private bool canOpenDoor;

    [SerializeField] private GameObject doorBody;
    [SerializeField] private KeyCode doorCode;
    [SerializeField] private float PushPower;

    public void Awake()
    {
        canOpenDoor = false;
    }
	
	void Update () {

        checkForCollision();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            canOpenDoor = true;
            Debug.Log(canOpenDoor);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            canOpenDoor = false;
            Debug.Log(canOpenDoor);
        }
    }

    private void checkForCollision()
    {
        if (canOpenDoor)
        {
            if (Input.GetKeyDown(doorCode))
            {
                doorBody.transform.Rotate(Vector3.up * PushPower);
            }
            ///animatie quick time event Jimmy deschide usa cu greu
            ///reparat bug!
        }
    }
}
