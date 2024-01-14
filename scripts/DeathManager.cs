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
    public GameObject deathThing1B;


    public GameObject BOB;
    public int T;
    public bool animInit = false;

    public DeathAudio DA;


    // Start is called before the first frame update
    void Start()
    {
        deathThing1.color = new Color(255, 255, 255);
        T = Random.Range(1, 3);
        RandomDeath(T);
    }


    public void RandomDeath(int death)
    {

        if (death == 1)
        {
            deathThing1B.SetActive(true);
            deathThing1.sprite = yousuck;
            deathThing1.transform.localScale = new Vector3(20, 4, 4);
            diff.clip = DA.spy;
            diff.Play();
            animInit = true;
        }

        if (death == 2)
        {
            BOB.SetActive(true);
            deathThing1.sprite = null;
            deathThing1.transform.localScale = new Vector3(20, 4, 4);
            diff.clip = DA.dial1;
            diff.Play();
            animInit = true;

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
        if (diff.isPlaying == false && animInit == true)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadSceneAsync("Tutorial");
            print("revive");

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadSceneAsync("Tutorial");
            print("revive");
        }


    }
}
