using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public float speed = 1f; 
    private GameObject thePaddle;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.imgGameOver.enabled = false;
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (scoreManager.gameStopped){
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0){
                scoreManager.gameStopped = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2 (0.5f,1.0f) * speed;
            } else {
                var thePaddle = GameObject.Find("Paddle");
                transform.position = new Vector3(thePaddle.transform.position.x, thePaddle.transform.position.y+(thePaddle.transform.lossyScale.y*2), 0);
            }
        }

        if (scoreManager.gameEnded){
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0){
                scoreManager.level.text = "1";
                FindObjectOfType<BrickManager>().ResetLevel();
                scoreManager.gameEnded = false;


                var lifeManager = FindObjectOfType<ScoreManager>().lifes;
                lifeManager.text = "3";

                scoreManager.theScore.text = "0";

                FindObjectOfType<ScoreManager>().imgGameOver.enabled = false;
                Respawn();
            }
        }

    }

    public void Respawn() {
        scoreManager.gameStopped = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

        var lifeManager = scoreManager.lifes;
        if (int.Parse(lifeManager.text)==-1){
            
            scoreManager.gameEnded = true;
            scoreManager.gameStopped = false;

            transform.position = new Vector3(0f, 0f, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

            lifeManager.text = "0";
            scoreManager.imgGameOver.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        // Hit the Racket?
        if (col.gameObject.name == "Paddle") {
            // Calculate hit Factor
            float x=hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        } else if( col.gameObject.name == "wall_left" || col.gameObject.name == "wall_right" ) {

            Vector2 direction = new Vector2(0, (float)UnityEngine.Random.Range(-100,100));
            GetComponent<Rigidbody2D>().AddForce(direction * 1f);

        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

}
