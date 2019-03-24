using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sheep : MonoBehaviour
{
    private NavMeshAgent mAgent;

    private Animator mAnimator;

    public GameObject Player;

    public float wonderTime;

    public float movementSpeed;

    Vector3 destination;

    void Start()
    {
        mAgent = GetComponent<NavMeshAgent>();

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
        float squaredDist = (transform.position - Player.transform.position).sqrMagnitude;

        if (PauseMenu.GameIsPaused == false)
        {
            if (wonderTime > 0)
            {
                transform.Translate(Vector3.forward * movementSpeed);
                wonderTime -= Time.deltaTime;
            }
            else
            {
                wonderTime = Random.Range(1.0f, 5.0f);
                Wonder();
            }
        }

        mAgent.destination = Player.transform.position;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Player = GameObject.FindGameObjectWithTag("Player");
        }

        if (other.CompareTag("Farm"))
        {
            Destroy(this.gameObject);
        }
    }
    void Wonder()
    {
        transform.eulerAngles = new Vector3 (0, Random.Range (0, 360), 0);
    }
}
