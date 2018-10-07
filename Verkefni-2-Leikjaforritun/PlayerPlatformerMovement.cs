using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerMovement : MonoBehaviour { // script fyrir Player movement og fleira sem tengist player

    public float speed; // float fyrir hraða
    public float jumpForce; // float fyrir kraft stökks
    public Rigidbody2D rb; // notað fyrir rigid body
    public Vector3 respawnPoint; // notað fyrir respawn
    AudioSource Respawn; // hljóð þegar þú deyrð
    AudioSource Jump; // hljóð þegar þú hoppar
    public GameObject blood; // gameObject fyrir blóð

    private SpriteRenderer spriteRenderer; // notað fyrir rotation á sprite eftir átt

    // Use this for initialization
    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();// initializar spriterenderer 
    }

    void Start () {
        respawnPoint = transform.position; // setur respawnpointið á staðinn sem playerinn byrjar á.
        AudioSource[] audio = GetComponents<AudioSource>(); // initializar audioSources
        Respawn = audio[0]; // tengir audio við breytu
        Jump = audio[1]; // tengir audio við breytu
    }


    // Update is called once per frame
    void Update () { 

       if (Input.GetButtonDown("Jump") && rb.velocity.y < .01f && rb.velocity.y > -.01f)// ef þú ýtir á jump takkann og ert ekki að ferðast upp né niður
        {
            Jump.Play(); //spila sound fyrir jump
            rb.AddRelativeForce(new Vector2(0f, jumpForce)); // hoppar með því að adda force
        }
        // notaði frekar harðkóðað movement í stað transform til að character væri ekki að ferðast inn í veggi
       if (Input.GetButtonDown("Right"))//  ýtt er á hægri takkann
        {
            rb.AddForce(Vector2.right * speed);// færist player til hægri
            
        }
        else if (Input.GetButtonUp("Right"))// hætta að yta a hægri takkann
        {
            rb.velocity = Vector2.zero; // stoppar movement
        }

        if (Input.GetButtonDown("Left"))// ýtt er á vinstri takkann
        {
            rb.AddForce(-Vector2.right * speed); // færist player til vinstri
        }
        else if (Input.GetButtonUp("Left")) // hætt er að ýta á vinstri takkann
        {
            rb.velocity = Vector2.zero;// stoppar movement
        }

        Vector2 move = Vector2.zero;// notað fyrir flipsprite
        
        move.x = Input.GetAxis("Horizontal");// tekur inn horizontal (vinstri og hægri movement)
        
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.0f));// ef kall er að fara til hægri þá snýr sprite til hægri, og öfugt
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;// flippar eftir breytingu á direction
        }

        

    }
    void OnTriggerEnter2D(Collider2D other) // ef player fer inn í colliderinn 
    {
        if (other.tag == "deathbox")// sem er merktur sem deathbox
        {
            Instantiate(blood, transform.position, Quaternion.identity); // spilar blóðsplatter particle
            Respawn.Play(); // spilar respawn sound (death sound)
            transform.position = respawnPoint; // setur positionið á playerinum á respawnpoint positionið
        }
    }
}
