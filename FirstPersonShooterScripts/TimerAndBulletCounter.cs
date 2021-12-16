using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerAndBulletCounter : MonoBehaviour
{
    public float timer = 0f;
    public int boltsFired = 0;

    public int dummiesKilled = 0;

    public TextMeshProUGUI[] textFields;

    public bool winCondition = false;

    private bool dummiesShot;
    public bool DummiesShot
    {
        get{return dummiesShot;}
        set{
            if(dummiesKilled < 1)
            {
                dummiesShot = value; 
            }
        }
    }

    void Start()
    {
        textFields[2].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dummiesShot && !winCondition)
        {
            Invoke("Timer", 0f);
            textFields[0].text = "Time: " + timer.ToString();
        }

        textFields[1].text = "Bolts Fired: " + boltsFired.ToString();

        if(dummiesKilled == 5)
        {
            winCondition = true;
        }

        if(winCondition)
        {
            Debug.Log("In Win Condition");
            if(timer <= 15f)
            {
                textFields[2].text = "You Win\nBolts Fired: " + boltsFired.ToString() + "\nTime: " + timer.ToString() + "\nClick Left Mouse Button\nto Play Again";
            }else
            {
                textFields[2].text = "You Lose\nClick Left Mouse Button\nto Play again";                
            }
            textFields[2].enabled = true;
        }

        if(winCondition && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void Timer()
    {
        timer += Time.deltaTime;
    }
}
