using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public bool secretdeathAct;
    public int deathNum = 1;
    public SpriteRenderer deathThing1;
    public string T;


    // Start is called before the first frame update
    void Start()
    {
        deathThing1.color = new Color(255, 255, 255);
        print(deathThing1.color.ToString(T));
    }

    // Update is called once per frame
    void Update()
    {



    }
}
