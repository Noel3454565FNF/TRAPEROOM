using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public bool secretdeathAct;
    public int deathNum = 1;
    public Sprite yousuck;
    public AnimationClip bob;
    public AudioSource diff;
    public SpriteRenderer deathThing1;
    public int T;

    public DeathAudio DA;


    // Start is called before the first frame update
    void Start()
    {
        deathThing1.color = new Color(255, 255, 255);
        T = Random.Range(1, 2);
        RandomDeath(T);
    }


    public void RandomDeath(int death)
    {

        if (death == 1)
        {
            deathThing1.sprite = yousuck;
            deathThing1.transform.localScale = new Vector3(20, 4, 4);
            diff.clip = DA.spy;
            diff.Play();
        }

        if (death == 2)
        {
            deathThing1.sprite = null;
            deathThing1.transform.localScale = new Vector3(20, 4, 4);
            diff.clip = DA.dial1;
            diff.Play();

        }


    }

    public void SPY()
    {
        deathThing1.sprite = yousuck;
        deathThing1.transform.localScale = new Vector3(20, 4, 4);
        diff.clip = DA.spy;
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
