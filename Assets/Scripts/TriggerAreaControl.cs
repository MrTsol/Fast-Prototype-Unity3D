using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerAreaControl : MonoBehaviour
{
    GameObject[] Sheeps;
    int count = 60;
    public static bool disabled = false;
    public GameObject objectToDisable;

    public Text countText;
    public Text winText;

    float timer = 10.0f;
    void Start()
    {
        SetCoutText ();
        winText.text = "";
    }

    void Update()
    {
        GameObject[] Sheeps;
        Sheeps = GameObject.FindGameObjectsWithTag("Sheep");

        if(Sheeps.Length == 0 )
        {
            if (disabled)
            {
                objectToDisable.SetActive (false);
            }
            else
            {
                objectToDisable.SetActive (true);
            }

            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                timer = 0;
                SceneManager.LoadScene("iSheepYouNot");
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        
        if (other.CompareTag("Sheep"))
        {
            count--;
            SetCoutText ();
        }
    }

    void SetCoutText ()
    {
        countText.text = "   Sheeps: " + count.ToString ();
        if (count == 0)
        {
            winText.text = "Congratulations! You have collected all the sheeps! The game will restart in 10 seconds!";
        }
    }
}
