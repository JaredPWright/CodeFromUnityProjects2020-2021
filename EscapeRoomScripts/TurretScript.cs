using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float turretRange = 3f;
    public float rateOfFire = 3f;
    public Transform barrel;
    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
    private Transform playerTransform;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Stylized Astronaut").GetComponent<Transform>();
        animator = GetComponent<Animator>();

        animator.Play("TurretGunAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerTransform.position, transform.position) <= 3f)
        {
            animator.StopPlayback();
            transform.LookAt(playerTransform, Vector3.up);
            InvokeRepeating("Fire", 0f, rateOfFire);
        }else
        {
            particleSystem1.Stop();
            animator.Play("TurretGunAnimation");
        }
    }

    void Fire()
    {
        RaycastHit hit;
        float hitRate = Random.Range(0f, 100f);

        particleSystem1.Play();

        if(hitRate <= 80f)
        {
            if(Physics.Raycast(barrel.position, transform.forward, out hit, turretRange))
            {
                PlayerHealth.health -= 33;
            }
        }
    }

    IEnumerator SteamHiss()
    {
        particleSystem2.Play();

        yield return new WaitForSeconds(5f);

        particleSystem2.Stop();
    }
}
