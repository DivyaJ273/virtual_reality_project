using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public GameObject DoorButton;
    public GameObject Door;
    public float smooth = 2.0f; // Adjust the speed of the door opening/closing

    private Quaternion doorOpen;
    private Quaternion doorClosed;

    void Start() {
        Door = GameObject.Find("Object001");
        DoorButton = GameObject.Find("DoorButton");
        DoorButton.SetActive(false);

        // Define the initial rotations
        doorClosed = Door.transform.rotation;
        doorOpen = Quaternion.Euler(0, -90, 0);
    }

    void OnTriggerEnter(Collider cube) {
        if (cube.tag == "DoorButton") {
            DoorButton.SetActive(true);
            Debug.Log("Button activated");
        }
    }

    void OnTriggerExit(Collider cube) {
        if (cube.tag == "DoorButton") {
            DoorButton.SetActive(false);
            Debug.Log("Button deactivated");
        }
    }

    void Update() {
        // Interpolate the door rotation over time
        Door.transform.rotation = Quaternion.Lerp(Door.transform.rotation, DoorButton.activeSelf ? doorOpen : doorClosed, Time.deltaTime * smooth);
    }
}
