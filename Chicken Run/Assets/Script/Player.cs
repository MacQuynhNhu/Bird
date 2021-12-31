using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    GameController gco;
    Rigidbody2D rig;
    public AudioSource Aus;
    public AudioClip JumpSound;
    public AudioClip DieSound;
    float yPos;
    public float JumpForce;
    Obstacle obstacle;
    bool isIncreased;
    // Start is called before the first frame update
    void Start()
    {
        Aus.Play();
        rig = GetComponent<Rigidbody2D>();
        yPos = transform.position.y;
        obstacle = FindObjectOfType<Obstacle>();
        gco = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJump = Input.GetKeyDown(KeyCode.Space);
        if(isJump && transform.position.y < yPos)
        {
            rig.AddForce(new Vector2(0,1f)* JumpForce);
            if (Aus && JumpSound) Aus.PlayOneShot(JumpSound);
        }
        
         
        
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle")) {
            if (Aus && DieSound) Aus.PlayOneShot(DieSound);
            gco.IsGameover = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("increaseScore")) gco.IncreaseScore();
    }
}
