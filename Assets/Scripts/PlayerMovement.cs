using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 25f;
    public float mapWidth = 2f;
    private Rigidbody2D rb;
    public GameObject Panel;
    public GameObject scoreText;
    public PauseMenu pausemenu;
    float dirX;
    float accelStart_x;
    private Vector2 touchPosition;
    private Vector2 direction;
    public GameObject PauseButton, PauseButton1;

    void Start()
    {
        PauseButton.SetActive(true);
        PauseButton1.SetActive(true);
        Panel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        accelStart_x = Input.acceleration.x;
       
    }

    void Update()
    {

        dirX = (Input.acceleration.x - accelStart_x)* speed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2, 2), transform.position.y);

        
    }

    

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, 0f);
    }



    void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().EndGame();
        Panel.SetActive(true);
        scoreText.SetActive(false);
        PauseButton.SetActive(false);
        PauseButton1.SetActive(false);
    }

}