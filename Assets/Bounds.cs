using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{

    private AudioClip currentClip;
    private List<AudioClip> audioClips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        audioClips.Add(Resources.Load("impreca_porco spiano") as AudioClip);
        audioClips.Add(Resources.Load("impreca_arkanoid") as AudioClip);
        audioClips.Add(Resources.Load("impreca_parco della vittoria") as AudioClip);
        audioClips.Add(Resources.Load("impreca_no vabbe e bugiardo") as AudioClip);
        audioClips.Add(Resources.Load("impreca_no ragazzi io non so") as AudioClip);
        audioClips.Add(Resources.Load("impreca_porca miseria") as AudioClip);
        audioClips.Add(Resources.Load("impreca_archio") as AudioClip);
        audioClips.Add(Resources.Load("impreca_ahia_cazzarola") as AudioClip);
        audioClips.Add(Resources.Load("impreca_orchidea") as AudioClip);
        audioClips.Add(Resources.Load("impreca_urchiala") as AudioClip);
        audioClips.Add(Resources.Load("impreca_archiologo") as AudioClip);
        audioClips.Add(Resources.Load("impreca_maroska_il_palo") as AudioClip);
        audioClips.Add(Resources.Load("impreca_idraulico") as AudioClip);
        audioClips.Add(Resources.Load("impreca_maresciallo") as AudioClip);
        audioClips.Add(Resources.Load("impreca_mariglia") as AudioClip);
        audioClips.Add(Resources.Load("impreca_maresca_al_lido") as AudioClip);
        audioClips.Add(Resources.Load("impreca_cazzarola di un pelo") as AudioClip);
        audioClips.Add(Resources.Load("impreca_mamma mia") as AudioClip);
        audioClips.Add(Resources.Load("impreca_che kaiser") as AudioClip);
        audioClips.Add(Resources.Load("impreca_architetto") as AudioClip);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        var scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.lifes.text = (int.Parse(scoreManager.lifes.text)-1).ToString();
        scoreManager.audioSourceWelcome.Stop();
        scoreManager.audioSourceTalk.Stop();

        currentClip = audioClips[Random.Range(0, audioClips.Count)];
        scoreManager.audioSourceTalk.PlayOneShot(currentClip);
        
        other.GetComponent<Ball>().Respawn();
    }
}
