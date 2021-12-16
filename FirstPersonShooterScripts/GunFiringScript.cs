using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunFiringScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] prefabs;

    public float bulletForceMultiplier = 750f;
    public float casingForceMultiplier = 5f;

    public TextMeshProUGUI fireModeText;

    public ParticleSystem[] firingParticles;

    //public AudioSource boom;

    private bool tapFire = true;
    private bool fullAuto = false;

    private bool firingFullAuto = false;
    private bool tapFiring = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            tapFire = !tapFire;
            fullAuto = !fullAuto;

            if(tapFire)
            {
                fireModeText.text = "Fire Mode:\nTap Fire";
            }else
            {
                fireModeText.text = "Fire Mode:\nFull Auto";
            }

        }

        if(Input.GetButtonDown("Fire1") && tapFire)
        {
            Invoke("TapFiringMechanism", 0f);
            //boom.Play();
            //tapFiring = true;
        }

        if(Input.GetButtonDown("Fire1") && fullAuto)
        {
            //boom.Play();
            //firingFullAuto = true;
            InvokeRepeating("ShootyShooty", 0f, .25f);
        }

        if(Input.GetButtonUp("Fire1") /*&& firingFullAuto*/)
        {
            //firingFullAuto = false;
            CancelInvoke();
        }
    }

    void TapFiringMechanism()
    {
        firingParticles[0].Play();
        firingParticles[1].Play();
        TimerAndBulletCounter bulletCounter = GameObject.Find("ChapterMaster").GetComponent<TimerAndBulletCounter>();
        bulletCounter.boltsFired++;
        GameObject tempBullet;
        Rigidbody tempBulletRB;

        tempBullet = Instantiate(prefabs[0]);
        tempBulletRB = tempBullet.GetComponentInChildren<Rigidbody>();

        tempBullet.gameObject.transform.position = spawnPoints[0].position;
        tempBulletRB.AddForce(-transform.forward * bulletForceMultiplier, ForceMode.Force);

        GameObject tempCasing;
        Rigidbody tempCasingRB;

        tempCasing = Instantiate(prefabs[1]);
        tempCasingRB = tempCasing.GetComponentInChildren<Rigidbody>();

        tempCasing.gameObject.transform.position = spawnPoints[1].position;
        tempCasingRB.AddForce(Vector3.right * casingForceMultiplier, ForceMode.Force);
    }

    void ShootyShooty()
    {
        firingParticles[0].Play();
        firingParticles[1].Play();
        TimerAndBulletCounter bulletCounter = GameObject.Find("ChapterMaster").GetComponent<TimerAndBulletCounter>();
        bulletCounter.boltsFired++;
        
        GameObject tempBullet;
        Rigidbody tempBulletRB;

        tempBullet = Instantiate(prefabs[0]);
        tempBulletRB = tempBullet.GetComponentInChildren<Rigidbody>();

        tempBullet.gameObject.transform.position = spawnPoints[0].position;
        tempBulletRB.AddForce(-transform.forward * bulletForceMultiplier, ForceMode.Force);

        GameObject tempCasing;
        Rigidbody tempCasingRB;

        tempCasing = Instantiate(prefabs[1]);
        tempCasingRB = tempCasing.GetComponentInChildren<Rigidbody>();

        tempCasing.gameObject.transform.position = spawnPoints[1].position;
        tempCasingRB.AddForce(Vector3.right * casingForceMultiplier, ForceMode.Force);

    }
}
