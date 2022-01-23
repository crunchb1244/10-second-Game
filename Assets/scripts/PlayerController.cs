using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public BoxCollider2D boxCollider2D;
    private RaycastHit2D hit;
    public bool isGrounded;

    public Transform groundCheck;
    
    public LayerMask groundLayer;

    public AudioSource audioSource;
    public AudioClip beginNoise;
    public AudioClip jumpNoise;

    public TimerController timerController;

    public ParticleSystem particleSystem;

    public Animator anim;



    // Start is called before the first frame update

    void Start()
    {
        audioSource.PlayOneShot(beginNoise, 5);
    }

    void Update()
    {
        GroundCheck();
        if(isGrounded==true)
        {
        anim.SetBool("isJumping", false);
        }
        else
        {
        anim.SetBool("isJumping", true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0) && isGrounded==true)
        {
            rigidbody2D.AddForce(new Vector2(0, 9),
                ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpNoise, 6);


        }
    }

    public void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.5f,groundLayer);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        particleSystem.Play();

        timerController.hasLost = true;

        Destroy(gameObject);
    
    }
}
