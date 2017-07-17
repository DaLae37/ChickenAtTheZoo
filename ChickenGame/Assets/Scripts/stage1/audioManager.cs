using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {


	public AudioClip start;
	public AudioClip ground;
	public AudioClip jump;
	public AudioClip dash;
	public AudioClip potal;
	public AudioClip button;
	public AudioClip change;
	public AudioClip lion_s;
	public AudioClip lion_d;
	public AudioClip door;
	public AudioClip stone;

	AudioSource myAudio;


	public float volume;
	public static audioManager instance;

	void Awake(){
		if (audioManager.instance == null)
			audioManager.instance = this;
	}

	void Start(){
		myAudio = GetComponent<AudioSource> ();
	}

	public void StartSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (start);
	}
	public void GroundSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (ground);
	}
	public void JumpSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (jump);
	}
	public void DashSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (dash);
	}
	public void PotalSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (potal);
	}
	public void ButtonSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (button);
	}
	public void Lion_sSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (lion_s);
	}
	public void Lion_dSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (lion_d);
	}
	public void ChangeSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (change);
	}
	public void DoorSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (door);
	}
	public void StoneSound(){
		volume = PlayerPrefs.GetFloat ("eft");
		this.myAudio.volume = volume;
		myAudio.PlayOneShot (stone);
	}
}
