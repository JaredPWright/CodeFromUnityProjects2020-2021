using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool amTripped = false;

    private Animator animator;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerTransform = GameObject.Find("Stylized Astronaut").GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(playerTransform.position, transform.position);

        if((dist <= 3f) && Input.GetKeyDown(KeyCode.E))
        {
            animator.Play("ButtonAnimation");
            amTripped = true;
        }
    }
}
