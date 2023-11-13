using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {
            print(PAPA(4));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            print(PAPA(15));
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            print(PAPA(17));
        }



    }


    public float PAPA(float R)
    {
        var rayon = 2 * 3.14f * R;
        return R;
    }
}
