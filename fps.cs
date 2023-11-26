using UnityEngine;

public class DoorOpenFPS : MonoBehaviour
{
    public float interactDistance = 2f;
    public float smooth = 2.0f; // Adjust the speed of the door opening/closing
    private Quaternion doorOpen;
    private Quaternion doorClosed;

    void Start()
    {
        // Define the initial rotations
        doorClosed = transform.rotation;
        doorOpen = Quaternion.Euler(0, -90, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    ToggleDoor();
                }
            }
        }

        // Interpolate the door rotation over time
        transform.rotation = Quaternion.Lerp(transform.rotation, doorOpen, Time.deltaTime * smooth);
    }

    void ToggleDoor()
    {
        if (transform.rotation.eulerAngles.y < 45f)
        {
            doorOpen = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            doorOpen = Quaternion.Euler(0, -90, 0);
        }
    }
}
