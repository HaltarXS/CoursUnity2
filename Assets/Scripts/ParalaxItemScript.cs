using UnityEngine;
using System.Collections;

public class ParalaxItemScript : MonoBehaviour {

    public float rangeNextSound = 3f;
    public AudioClip[] sounds;

    private float nextSound = 0;
    private AudioSource audioPlayer;
	void Start () {
        audioPlayer = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        if (nextSound < 0)
        {
            audioPlayer.clip = sounds[Random.Range(0, sounds.Length)];
            audioPlayer.volume = 0.6f;
            audioPlayer.Play();
            nextSound = rangeNextSound;
        }
        else
        {
            nextSound -= Time.deltaTime;
        }
        
        Vector3 posPixel = Camera.main.WorldToScreenPoint(transform.position);
        if (posPixel.x <= -Screen.width / 2)
        {
            Destroy(gameObject);
        }     
	}
}
