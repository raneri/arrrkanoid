using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float speed = 5f;

    private float input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        input = Input.GetAxisRaw("Horizontal");

        if (Input.touchCount > 0)
        {
             var touch = Input.GetTouch(0);

             if (touch.position.x < Screen.width/2){
                 input = -1;
             }
             else if (touch.position.x > Screen.width/2){
                 input = 1;
             }
        }
        
    }

    private void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * input * speed;
    }
}
