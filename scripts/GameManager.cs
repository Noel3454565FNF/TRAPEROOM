using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public int curLevel = 1;
    public string[] levelList;
    public GameObject[] levelpref;
    public Transform playerT;
    public Vector3 SPP;

    // Start is called before the first frame update
    void Start()
    {
        print(-1 <= 0);   
    }


    public void changeLevel(int level)
    {

        if (levelList.Length < level || levelList.Length <= 0)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadSceneAsync("Death");
        }
        
            GameObject.Destroy(GameObject.Find(levelList[curLevel]));
            GameObject.Instantiate(levelpref[level]);
            curLevel = level;
            playerT.position = SPP;
            print("room changed");
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
