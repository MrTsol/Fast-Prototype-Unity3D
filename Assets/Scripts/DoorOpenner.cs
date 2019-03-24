using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenner : MonoBehaviour
{
    public Text openDoorText;
    public Text closeDoorText;
    public static bool farmDoor;
    public bool open;
    public bool close;
    public bool inTrigger;
    public float doorOpenAngle = -50f;
    public float doorCloseAngle = 90f;
    public float smooth = 2f;

    void Start ()
    {
        openDoorText.text = "";
        closeDoorText.text = "";
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
         inTrigger = false;
        }
    }

    void Update ()
    {
        if (inTrigger)
        {
            if (close)
            {
                if (Input.GetKeyDown (KeyCode.E))
                {
                    open = true;
                    close = false;
                }
            }
            else
            {
                if (Input.GetKeyDown (KeyCode.E))
                {
                    close = true;
                    open = false;
                }
            }
        }
            if (open)
            {
                Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
            }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            if (open)
            {
                //GUI.Box (new Rect (Screen.width/2 - 100, Screen.height/2 - 12, 200, 24), "Press E to close the door");
                openDoorText.text = "Press E to close the door";
                closeDoorText.text = "";
            }
            else{
                //GUI.Box (new Rect (Screen.width/2 - 100, Screen.height/2 - 12, 200, 24), "Press E to open the door");
                closeDoorText.text = "Press E to open the door";
                openDoorText.text = "";
            }
        }
        else
        {
            closeDoorText.text = "";
            openDoorText.text = "";
        }
    }
}