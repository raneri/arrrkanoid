using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public AudioSource audioSourceEffectBrick;
    private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        _clip = Resources.Load("brickdestroy") as AudioClip;
        audioSourceEffectBrick = GameObject.Find("AudioSource").GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        Destroy(gameObject);
        FindObjectOfType<BrickManager>().RemoveBrick(this);
        
        audioSourceEffectBrick.PlayOneShot(_clip);

        var scoreManager = FindObjectOfType<ScoreManager>().theScore;

        scoreManager.text = (int.Parse(scoreManager.text)+10).ToString();
    }
}
