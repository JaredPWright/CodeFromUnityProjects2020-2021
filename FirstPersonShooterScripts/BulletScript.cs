using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public enum TypeOfBullet{Casing, Bullet};

    public TypeOfBullet bulletType;

    public AudioClip blep;
    
    private IEnumerator decay;

    private AudioSource clip;
    private AudioSource clip2;


    void Start()
    {
        clip = GetComponent<AudioSource>();
        clip2 = GameObject.Find("Wright-PatternBolter").GetComponent<AudioSource>();

        if(bulletType == TypeOfBullet.Bullet)
        {
            clip2.PlayOneShot(blep, .7f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(bulletType == TypeOfBullet.Bullet)
        {
            decay = Decay(.25f);
            StartCoroutine(decay);
        }else if(bulletType == TypeOfBullet.Casing)
        {
            decay = Decay(5f);
            StartCoroutine(decay);
        }
    }

    private IEnumerator Decay(float decayDelay)
    {
        if(bulletType == TypeOfBullet.Casing)
        {
            clip.Play();
        }
        yield return new WaitForSeconds(decayDelay);
        
        Destroy(this.gameObject);
    }
}
