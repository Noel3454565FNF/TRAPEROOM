using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public bool secretdeathAct;
    public int deathNum = 1;
    public Sprite yousuck;
    public AudioClip yousucking;
    public AudioSource diff;
    public SpriteRenderer deathThing1;
    public string T;


    // Start is called before the first frame update
    void Start()
    {
        deathThing1.color = new Color(255, 255, 255);
        print(deathThing1.color.ToString(T));
        SPY();
    }

    public void SPY()
    {
        deathThing1.sprite = yousuck;
        deathThing1.transform.localScale = new Vector3(20, 4, 4);
        diff.clip = yousucking;
        diff.Play();
    }


    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadSceneAsync("Tutorial");
            print("revive");
        }


    }
}
