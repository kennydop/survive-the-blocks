using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragMovements : MonoBehaviour
{

    public float speed = 0.5f;
    public float spd = 2.3f;
    private Rigidbody2D rb;
    public GameObject Panel;
    public GameObject scoreText;
    public PauseMenu pausemenu;
    public GameObject PauseButton, PauseButton1;

    void Start()
    {
        PauseButton.SetActive(true);
        PauseButton1.SetActive(true);
        Panel.SetActive(false);
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * speed * Time.fixedDeltaTime*spd, 0, 0);
        }
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
