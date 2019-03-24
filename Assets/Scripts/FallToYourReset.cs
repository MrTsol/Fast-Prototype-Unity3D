using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToYourReset : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
           //Application.LoadLevel(Application.loadedLevel);
           UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
