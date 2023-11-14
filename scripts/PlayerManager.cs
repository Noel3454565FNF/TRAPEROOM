using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int health = 1;
    public GameManager GM;
    public string customM = "normal";
    public bool cooldownDMG = false;
    public bool canDie = true;
    public bool canMove = true;
    public string moveType = "normal";
    public int moveSpeed = 6;
    public int speed = 500;
    public float jumpHight = 100;
    public bool canJump = true;
    private float DirectionX;
    private Rigidbody2D Rigidbody;
    [SerializeField] private float PlayerSpeed;
    [SerializeField] private float jumpForce;
    public Transform transform;
    public Rigidbody2D rgb;



    public GameObject TP_sh;
    public bool canTP = true;
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
                /*                if (Input.GetKey(KeyCode.RightArrow))
                                {
                                    rgb.velocity = new Vector2(moveSpeed + rgb.velocity.x, rgb.position.y);

                                }
                                if (Input.GetKey(KeyCode.LeftArrow))
                                {
                                    rgb.velocity = new Vector2(moveSpeed * rgb.velocity.x, rgb.position.y);

                                }

                */
/*                Vector2 move = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);
                Vector2 newPos = rgb.position + move;
                rgb.MovePosition(newPos);
                if (Input.GetKey(KeyCode.Space) && canJump == true)
                {
                    print("jump");
                    rgb.velocity = Vector2.up * 100;
                    jumpHight += -10;

                }
*/
                if (jumpHight <= 0 && canJump == true)
                {
                    canJump = false;
                }

                DirectionX = Input.GetAxisRaw("Horizontal");

                if (Input.GetKey(KeyCode.Space) && canJump == true)
                {
                    rgb.AddForce(new Vector2(0f, jumpForce));
                    jumpHight += -10;
                }
            }
        }




        if (customM == "normal")
        {
            TP_sh.active = false;
        }
        if (customM == "TP")
        {
            TP_sh.active = true;
            TP_sh.transform.position = new Vector2(rgb.position.x + 4, rgb.position.y);

            if (Input.GetKeyDown(KeyCode.Z) && canTP == true)
            {
                canTP = false;
                StartCoroutine(TPcooldown());
            }
        }
    }


    private void FixedUpdate()
    {
        rgb.velocity = new Vector2(DirectionX * PlayerSpeed, rgb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "red block")
        {
            print("red tuch");
            Damage("normal");
        }

        if (collision.gameObject.tag == "cheese")
        {
            print("cheese");
            transform.position = GM.SPP;
            var temp = GM.curLevel;
            GM.changeLevel(temp);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collid");
        print(collision.gameObject.name);
        if(collision.gameObject.tag == "ground")
        {
            canJump = true;
            jumpHight = 75;
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

    IEnumerator TPcooldown()
    {
        if(canTP == false)
        {
            yield return new WaitForSeconds(1.5f);
            canTP = true;
            StopCoroutine(TPcooldown());
        }
    }

}
