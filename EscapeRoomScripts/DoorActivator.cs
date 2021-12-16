using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public enum DoorType{RedDoor, BlueDoor, GreenDoor};

    public DoorType doorType; 
    private Animator animator;

    private ButtonScript myButton;

    void Start()
    {
        animator = GetComponent<Animator>();

        switch(doorType)
        {
            case DoorType.RedDoor :
                myButton = GameObject.Find("RedButton").GetComponent<ButtonScript>();
                break;
            case DoorType.BlueDoor :
                myButton = GameObject.Find("BlueButton").GetComponent<ButtonScript>();
                break;
            default :
                myButton = GameObject.Find("GreenButton").GetComponent<ButtonScript>();
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && myButton.amTripped)
        {
            animator.Play("DoorOpeningAnimation");
        }
    }
}
