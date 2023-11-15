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
    public GameObject BS;



    public GameObject TP_sh;
    public bool canTP = true;
    public string TPdir = "nop";
    // Start is called before the first frame update
    void Start()
    {
        BS.active = false;
        BS.transform.localScale = new Vector3(Screen.height, Screen.width, 0);
        BS.transform.localPosition = new Vector3(0, 0, -2);

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
            changeMecha("normal");
        }
        if (customM == "TP")
        {
            if (DirectionX > 0)
            {
                TP_sh.transform.position = new Vector2(rgb.position.x + 4, rgb.position.y);
                TPdir = "right";
            }
            if (DirectionX < 0)
            {
                TP_sh.transform.position = new Vector2(rgb.position.x - 4, rgb.position.y);
                TPdir = "left";
            }
            if (DirectionX == 0)
            {
                TP_sh.transform.position = new Vector2(rgb.position.x, rgb.position.y);
                TPdir = "nop";
            }

            if (Input.GetKeyDown(KeyCode.Z) && canTP == true)
            {
                canTP = false;
                StartCoroutine(TPcooldown());
            }
        }
    }


    public void changeMecha(string type)
    {
        if (type == "normal")
        {
            TP_sh.active = false;
            customM = type;
        }

        if (type == "TP")
        {
            TP_sh.active = true;
            customM = type;
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
            var temp = GM.curLevel + 1;
            GM.changeLevel(temp);
        }

        if (collision.gameObject.tag == "rebound-platform")
        {
            rgb.AddForce(new Vector2(0f, 400));
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
            BS.active = true;
            rgb.position = TP_sh.transform.position;
            TP_sh.active = false;
            yield return new WaitForSeconds(0.1f);
            BS.active = false;
            yield return new WaitForSeconds(4f);
            canTP = true;
            TP_sh.active = true;
            StopCoroutine(TPcooldown());
        }
    }

}
