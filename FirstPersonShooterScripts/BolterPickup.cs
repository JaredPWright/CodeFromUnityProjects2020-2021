using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BolterPickup : MonoBehaviour
{
    public GameObject playersShotgun;
    public AudioSource pickupAudio;
    public AudioClip[] pickupClips;

    public float audioVolume = 5f;

    public TextMeshProUGUI fireModeText;

     // Start is called before the first frame update

    void Start()
    {
        // hide it right away, because we said so
        fireModeText.enabled = false;
        playersShotgun.SetActive(false);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            fireModeText.enabled = true;
            
            pickupAudio.PlayOneShot(pickupClips[0], audioVolume);
            pickupAudio.PlayOneShot(pickupClips[1], audioVolume);
            
            // tell player to unhide it's shotgun
            playersShotgun.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }
}
