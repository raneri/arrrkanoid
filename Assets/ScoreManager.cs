using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text theScore;
    public Text lifes;
    public Image imgGameOver;
    public bool gameStopped = true;
    public bool gameEnded = false;
    public Text level;

    public AudioSource audioSourceWelcome;
    public AudioSource audioSourceTalk;
    private AudioClip currentClip;
    private List<AudioClip> audioClips = new List<AudioClip>();
    private List<AudioClip> audioClipsTalk = new List<AudioClip>();
    public List<AudioClip> audioClipsWin = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        
        audioClips.Add(Resources.Load("incipit_eccoloooo") as AudioClip);
        audioClips.Add(Resources.Load("incipit_ueila_ragazzi") as AudioClip);
        audioClips.Add(Resources.Load("incipit_16bit") as AudioClip);
        audioClips.Add(Resources.Load("incipit_bello_salutare") as AudioClip);
        audioClips.Add(Resources.Load("incipit_ben_ve_nuti") as AudioClip);
        audioClips.Add(Resources.Load("incipit_buonasera_msdos") as AudioClip);
        audioClips.Add(Resources.Load("incipit_lag") as AudioClip);
        audioClips.Add(Resources.Load("incipit_non_si_vede_niente") as AudioClip);
        audioClips.Add(Resources.Load("incipit_problemi") as AudioClip);
        audioClips.Add(Resources.Load("incipit_titolone") as AudioClip);


        currentClip = audioClips[Random.Range(0, audioClips.Count)];
        audioSourceWelcome = GameObject.Find("AudioSourceWelcome").GetComponentInChildren<AudioSource>();
        audioSourceWelcome.PlayOneShot(currentClip);

        audioSourceTalk = GameObject.Find("AudioSourceTalk").GetComponentInChildren<AudioSource>();


        audioClipsTalk.Add(Resources.Load("talk_a_distanza_di_anni") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_a_parte_il_cofanetto") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_bisogna_studiarlo") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_carta_igienica") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_che_tristezza") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_complesso") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_doveva_essere_trainante") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_graficamente_si_puo_fare_di_piu") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_il_dump_fritto") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_luglio") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_non_ho_capito_niente") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_non_riesco") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_puo_migliorare") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_si_poteva_fare_di_piu") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_il gioco è talmente incazzoso") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_diamo un voto") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_forse sviluppandolo") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_per essere in basic") as AudioClip);
        audioClipsTalk.Add(Resources.Load("talk_poco impegno") as AudioClip);


        audioClipsWin.Add(Resources.Load("win_e ce labbiamo fatta") as AudioClip);
        audioClipsWin.Add(Resources.Load("win_mitico") as AudioClip);
        audioClipsWin.Add(Resources.Load("win_ce lho fatta") as AudioClip);

    }

    // Update is called once per frame
    void Update()
    {

        if ( !audioSourceWelcome.isPlaying && !audioSourceTalk.isPlaying && (System.DateTime.Now.Second==20 || System.DateTime.Now.Second==40 || System.DateTime.Now.Second==0) ){
            currentClip = audioClipsTalk[Random.Range(0, audioClipsTalk.Count)];
            audioSourceTalk.PlayOneShot(currentClip);
        }
    }
}
