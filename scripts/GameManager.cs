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
    public bool canChange = true;
    public GameObject Spawner;

    // Start is called before the first frame update
    void Start()
    {
        print(-1 <= 0);   
    }


    public void changeLevel(int level)
    {

        /*        if (levelList.Length < level || levelList.Length <= 0)
                {
                    SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                    SceneManager.LoadSceneAsync("Death");
                }
        */
        if (canChange == true)
        {
            canChange = false;
            //GameObject.Destroy(GameObject.Find(levelList[curLevel]));
            GameObject.Instantiate(levelpref[level]);
            curLevel = level;
            Spawner = GameObject.Find("spwaner");
            playerT.position = new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, 0);
            print(level);
            if (level == 4)
            {
                playerT.position = new Vector3(-3.90886593f, 3.83999991f, 0);
            }
            print(playerT.position);
            print(Spawner.transform.position);
            StartCoroutine(Reload());
        }

    }

    IEnumerator Reload()
    {
        if (canChange == false)
        {
            yield return new WaitForSeconds(0.1f);
            canChange = true;
            StopCoroutine(Reload());
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
