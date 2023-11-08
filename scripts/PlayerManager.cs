using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int health = 1;
    public bool cooldownDMG = false;
    public bool canDie = false;
    public bool canMove = true;
    public string moveType = "normal";
    public Transform transform;
    public Rigidbody2D rgb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        if(canMove == true)
        {
            if (moveType == "normal")
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    rgb.velocity = Vector2.right * 4;

                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rgb.velocity = Vector2.left * 4;

                }
            }
        }
    }

    public void Damage(string type)
    {
        if(type == "normal" && health > 0 && cooldownDMG == false)
        {
            cooldownDMG = true;
            health += -1;
            StartCoroutine(coolDownDMG());

        }
        if(health <= 0 && canDie == true)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadSceneAsync("Death");
            print("ded");
        }


    }

    IEnumerator coolDownDMG()
    {
        if(cooldownDMG == true)
        {
            yield return new WaitForSeconds(1);
            cooldownDMG = false;
            StopCoroutine(coolDownDMG());
        }
    }

}
