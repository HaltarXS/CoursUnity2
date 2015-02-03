using UnityEngine;
using System.Collections;

public class PlayerSoundScript : MonoBehaviour {

    public float rangeNextStep = 0.25f;
    public AudioClip[] stepsSounds;

    public AudioClip[] screamSounds;

    public float rangeNextAmbiant = 15.0f;
    public AudioClip[] ambiantSounds;

    private AudioSource[] audioPlayers;
    private float nextStep;
    private float nextAmbiant;
    private Animator anim;

    void Start()
    {
        audioPlayers = GetComponentsInChildren<AudioSource>();
        nextStep = 0;
        nextAmbiant = 0;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("moving"))
        {
            if (nextStep < 0)
            {
                audioPlayers[1].clip = stepsSounds[Random.Range(0, stepsSounds.Length)];
                audioPlayers[1].volume = 0.2f;
                audioPlayers[1].Play();
                nextStep = rangeNextStep;
            }
            else
            {
                nextStep -= Time.deltaTime;
            }
        }
        else
        {
            nextStep = 0;
        }

        if (nextAmbiant < 0)
        {
            PlayRandomSound(ambiantSounds,0.7f);
            nextAmbiant = rangeNextAmbiant;
        }
        else
        {
            nextAmbiant -= Time.deltaTime;
        }
    }

    void PlayRandomSound(AudioClip[] clips, float volume = 1.0f)
    {
        PlayRandomSound(clips, new Vector2(1.0f,1.0f),volume);
    }

    void PlayRandomSound(AudioClip[] clips, Vector2 pitchRange, float volume = 1.0f)
    {
        if (clips != null)
        {
            foreach (AudioSource audio in audioPlayers)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = clips[Random.Range(0, clips.Length)];
                    audio.pitch = Random.Range(pitchRange.x, pitchRange.y);
                    audio.volume = volume;
                    audio.Play();
                    break;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Paralax"))
        {
        if (Random.Range(0f, 1f) > 0.5f)
        {
           PlayRandomSound(screamSounds, new Vector2(0.8f, 1.1f), 0.5f);
        }
        }
    }
}
