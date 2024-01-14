using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damn : MonoBehaviour
{
    public GameObject cheese;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     while (true)
        {
            GameManager.Instantiate(cheese);
        }
        
    }
}
