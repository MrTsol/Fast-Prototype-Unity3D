using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepInFarm : MonoBehaviour
{
    private NavMeshAgent mAgent;
    private Animator mAnimator;

    public float wonderTime;

    public float movementSpeed;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    private bool IsNavMeshMoving
    {
        get
        { 
            return mAgent.velocity.magnitude > 0.1f;
        }
    }

    void Update()
    {
        mAnimator.SetBool("walk", true);

        if (PauseMenu.GameIsPaused == false)
        {
            if (wonderTime > 0)
            {
                transform.Translate(Vector3.forward * movementSpeed);
                wonderTime -= Time.deltaTime;
            }
            else
            {
                wonderTime = Random.Range(1.0f, 2.0f);
                Wonder();
            }
        }
    }
    void Wonder()
    {
        transform.eulerAngles = new Vector3 (0, Random.Range (0, 360), 0);
    }
}
