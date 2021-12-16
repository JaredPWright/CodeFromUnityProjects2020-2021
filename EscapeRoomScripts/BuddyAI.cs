using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyAI : MonoBehaviour
{
    public Transform player;
    public float stepDistance = 1f;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        
        transform.LookAt(player, Vector3.up);

        if(dist > 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, stepDistance * Time.deltaTime);
            animator.Play("Run");
        }else
        {
            animator.Play("Idle");
        }
    }
}
