using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class premSpazio : MonoBehaviour
{

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0){
            Debug.Log("Loading screen...");
            GetComponent<Text>().text = "Attendi...";
            StartCoroutine(loadScreen());
        }

       timer = timer + Time.deltaTime;
       if(timer >= 0.5)
       {
               GetComponent<Text>().enabled = true;
       }
       if(timer >= 1)
       {
               GetComponent<Text>().enabled = false;
               timer = 0;
       }

    }

    IEnumerator loadScreen()
    {
            var loading = SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
            yield return loading;

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
            SceneManager.UnloadSceneAsync("TitleScene");
    }
}
