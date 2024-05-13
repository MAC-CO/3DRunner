using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    Vector3 startPosition;
    public static GameObject player;
    public static GameObject currentPlatform;
    bool canTurn = false;

    //public static AudioSource[] sfx;

    public GameObject Magic;
    public Transform MagicStartPosition;
    Rigidbody MagicRB;

    public static bool isDead = false;
    int livesLeft;
    public Texture AliveIcon;
    public Texture DeadIcon;
    public RawImage[] icons;

    public GameObject GameOverPanel;
    public Text highScore;

    bool falling = false;

    public float JumpForce;

    public Parametro Parametro;

    void StopJump()
    {
        anim.SetBool("IsJumping", false);
    }
    void StopMagic()
    {
        anim.SetBool("IsMagic", false);
    }

    void CastMagic()
    {
        Magic.transform.position = MagicStartPosition.position;
        Magic.SetActive(true);
        MagicRB.AddForce(this.transform.forward * 5000);
        Invoke("KillMagic", 1);
    }

    void PlayMagicSound()
    {
    //    sfx[7].Play();
        Parametro.SonidoFireBall();
    }

    void KillMagic()
    {
        Magic.SetActive(false);
    }

    // void Footstep1()
    // {
    //     //sfx[4].Play();
    // }
    //
    // void Footstep2()
    // {
    //     //sfx[3].play();
    // }


    void RestartGame()
    {
        SceneManager.LoadScene("ScrollingWorld", LoadSceneMode.Single);
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((falling || other.gameObject.tag == "Fire" || other.gameObject.tag == "Wall") && !isDead)
        {

            if (falling)
            {
                anim.SetTrigger("IsFalling");
            }
            else
            {
                anim.SetTrigger("IsDead");
            }
            isDead = true;
            //sfx[6].Play();
            livesLeft--;
            PlayerPrefs.SetInt("Lives", livesLeft);

            if (livesLeft > 0)
            {
                Invoke("RestartGame", 2);
            }
            else
            {
                icons[0].texture = DeadIcon;
                GameOverPanel.SetActive(true);

                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));

                if (PlayerPrefs.HasKey("highscore"))
                {
                    int HS = PlayerPrefs.GetInt("highscore");

                    if (HS < PlayerPrefs.GetInt("Score"))
                    {
                        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                    }
                    else
                    {
                        PlayerPrefs.SetInt("highscore", HS);
                        //PlayerPrefs.GetInt("score")
                    }
                }
            }
        }
        else
        {
            currentPlatform = other.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider && GenerateWorld.lastPlatform.tag != "PlatformT")
        {
            GenerateWorld.RunDummy();
        }

        if (other is SphereCollider)
        {
            canTurn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
        {
            canTurn = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        MagicRB = Magic.GetComponent<Rigidbody>();

        //sfx = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();

        startPosition = player.transform.position;
        GenerateWorld.RunDummy();

        if (PlayerPrefs.HasKey("highscore"))
        {

            highScore.text = "High Score: " + PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highScore.text = "High Score: 0";
        }

        isDead = false;
        livesLeft = PlayerPrefs.GetInt("Lives");

        for (int i = 0; i < icons.Length; i++)
        {
            if (i >= livesLeft)
            {
                icons[i].texture = DeadIcon;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isDead) return;

        if (currentPlatform != null)
        {
            if (this.transform.position.y < currentPlatform.transform.position.y - 5)
            {
                falling = true;
                OnCollisionEnter(null);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * JumpForce);
            Parametro.SonidoJump();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            anim.SetBool("IsMagic", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateWorld.dummy.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if (GenerateWorld.lastPlatform.tag != "PlatformT")
            {
                GenerateWorld.RunDummy();
            }

            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            GenerateWorld.dummy.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if (GenerateWorld.lastPlatform.tag != "PlatformT")
            {
                GenerateWorld.RunDummy();
            }

            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
    }
}
