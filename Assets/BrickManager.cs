using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{


    public int rows;
    public int columns;
    public float spacing;
    public GameObject brickPrefab;

    private List<GameObject> bricks = new List<GameObject>();

    private AudioClip currentClip;

    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResetLevel() {
        foreach (GameObject brick in bricks) {
            Destroy(brick);
        }
        bricks.Clear();

        var scoreManager = FindObjectOfType<ScoreManager>();
        
        if ( int.Parse(scoreManager.level.text) == 5 ){
            scoreManager.level.text = "1";
            var _ball = FindObjectOfType<Ball>();
            _ball.speed++;
        }

        if ( int.Parse(scoreManager.level.text) == 1 ){
            rows=6;

            for (int x=0; x<columns; x++){
                for (int y=0; y<rows; y++){
                    Vector2 spawnPos = (Vector2)transform.position + new Vector2(
                        x * (brickPrefab.transform.localScale.x + spacing),
                        -y * (brickPrefab.transform.localScale.y + (spacing/3))
                        );


                    GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                    bricks.Add(brick);
                }
            }

            var bris = FindObjectsOfType<Brick>();
            for(int i = 0; i < bris.Length; i++){
                bris[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        if ( int.Parse(scoreManager.level.text) == 2 ){
            rows=9;
            var scaler=0;

            for (int x=0; x<columns; x++){
                for (int y=0; y<rows-scaler; y++){
                    Vector2 spawnPos = (Vector2)transform.position + new Vector2(
                        x * (brickPrefab.transform.localScale.x + spacing),
                        -y * (brickPrefab.transform.localScale.y + (spacing/3))
                        );


                    GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                    bricks.Add(brick);
                }
                scaler++;
            }

            var bris = FindObjectsOfType<Brick>();
            for(int i = 0; i < bris.Length; i++){
                bris[i].GetComponent<SpriteRenderer>().color = Color.green;
            }
        }

        if ( int.Parse(scoreManager.level.text) == 3 ){
            rows=10;

            for (int x=0; x<columns; x++){
                for (int y=0; y<rows; y++){
                    if ( y % 2 == 0 ){
                        Vector2 spawnPos = (Vector2)transform.position + new Vector2(
                            x * (brickPrefab.transform.localScale.x + spacing),
                            -y * (brickPrefab.transform.localScale.y + (spacing/3))
                            );


                        GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                        bricks.Add(brick);
                    }
                }
            }

            var bris = FindObjectsOfType<Brick>();
            for(int i = 0; i < bris.Length; i++){
                bris[i].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

        if ( int.Parse(scoreManager.level.text) == 4 ){
            rows=11;

            for (int x=0; x<columns; x++){
                for (int y=0; y<rows; y++){
                    if ( x % 2 == 0 ){
                        Vector2 spawnPos = (Vector2)transform.position + new Vector2(
                            x * (brickPrefab.transform.localScale.x + spacing),
                            -y * (brickPrefab.transform.localScale.y + (spacing/3))
                            );


                        GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                        bricks.Add(brick);
                    }
                }
            }
            var bris = FindObjectsOfType<Brick>();
            for(int i = 0; i < bris.Length; i++){
                bris[i].GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }




    }

    public void RemoveBrick(Brick brick) {
        bricks.Remove(brick.gameObject);
        if ( bricks.Count == 0 ){
            var scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.level.text = (int.Parse(scoreManager.level.text)+1).ToString();

            scoreManager.audioSourceWelcome.Stop();
            scoreManager.audioSourceTalk.Stop();
            currentClip = scoreManager.audioClipsWin[Random.Range(0, scoreManager.audioClipsWin.Count)];
            scoreManager.audioSourceTalk.PlayOneShot(currentClip);

            ResetLevel();
            var _ball = FindObjectOfType<Ball>();
            _ball.Respawn();
        }
    }

}
