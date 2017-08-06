using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("Sound Tracks")]
    public AudioSource Beach;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource Atlantis;                 //Drag a reference to the audio source which will play the music.
    public AudioSource Cutscene;                 //Drag a reference to the audio source which will play the music.
    public AudioSource Menu;                 //Drag a reference to the audio source which will play the music.

    [Header("Sound Effects")]
    public AudioSource soundFX;             //Drag a reference to the audio source which will play the sound effects.

    public float minPitch;
    public float maxPitch;

    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             

    //Scene Detection
    private int CurrentLevel;


    private void Update()
    {

    }

    void Awake()
    {
        OnLevelWasLoaded();
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }


    
    public void PlaySingle(AudioClip clip, bool pitchChange)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        soundFX.clip = clip;
        if(pitchChange == true)
        {
            float soundPitch = Random.Range(minPitch, maxPitch);
            soundFX.pitch = soundPitch;
        }
        //Play the clip.
        soundFX.Play();
    }

    public void PlaySinglePitch(AudioClip clip, float pitchChange)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        soundFX.clip = clip;
        float soundPitch = pitchChange;
        soundFX.pitch = soundPitch;

        //Play the clip.
        soundFX.Play();
    }

    public void OnLevelWasLoaded()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        if (CurrentLevel >= 0 && CurrentLevel <= 1)
        {
            if (!Menu.isPlaying)
            {
                Menu.Play();              //Play this sound
            }
                Beach.Stop();
                Atlantis.Stop();
                Cutscene.Stop();
        }

        if (CurrentLevel == 2)
        {
            if (!Cutscene.isPlaying)
            {
                Cutscene.Play();              //Play this sound
            }
            Beach.Stop();
            Atlantis.Stop();
            Menu.Stop();
        }

        if (CurrentLevel == 23)
        {
            if (!Cutscene.isPlaying)
            {
                Cutscene.Play();              //Play this sound
            }
            Beach.Stop();
            Atlantis.Stop();
            Menu.Stop();
        }

        if (CurrentLevel >= 3 && CurrentLevel <= 12)
        {
            if (!Beach.isPlaying)
            {
                Beach.Play();              //Play this sound
            }

            Menu.Stop();
            Cutscene.Stop();
            Atlantis.Stop();
        }

        if (CurrentLevel >= 13 && CurrentLevel <= 22)
        {
            if (!Atlantis.isPlaying)
            {
                Atlantis.Play();              //Play this sound
            }

            Menu.Stop();
            Cutscene.Stop();
            Beach.Stop();
        }
    }
}