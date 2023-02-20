using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public Collider playerCollider;
    public GameObject pause;
    public TextMeshProUGUI myPoints;
    public int pointsNum;
    public GameObject points;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim= GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        pointsNum = 0;
        myPoints.text = "Score : " + pointsNum;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            pointsNum++;
            myPoints.text = "Score : " + pointsNum;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!!!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Invoke("DisableCollider", 1.5f);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            pause.SetActive(true);
            points.SetActive(false);

            //Enwongo sorry abeg, i wanted to restart the level. I hope this works. !
            /*Invoke("RestartLevel", 2.5f);*/
        }
    }
    
    public void DisableCollider()
    {
        playerCollider.enabled = false;
    }

    /*public void RestartLevel()
    {
       
        SceneManager.LoadScene(0);

    }*/
  

}
