using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour {


    public static string ExamRoomMusic = "ExamRoomMusic";
    public static string MenuClick = "MenuClick";
	public static string MenuTheme = "MenuTheme";
	public static string LobbyMusic = "LobbyMusic";
	public static string MiniMapMenuTheme = "MinimapMenuTheme";
	public static string XrayMusic = "XrayMusic";

    private Dictionary<string, AudioSource> audioSources;

	public static AudioPlayer Instance = null;

	void OnEnable () {

			audioSources = new Dictionary<string, AudioSource> ();

			for (int i = 0; i < transform.childCount; i++) {
				AudioSource childSource = transform.GetChild (i).GetComponent<AudioSource> ();
				audioSources.Add (childSource.gameObject.name, childSource);
			}
			
		}
		
	
	void Update () {

	}

    public void Play(string soundKey)
    {
        InnerPlay(false, soundKey);
    }

    public void Loop(string soundKey)
    {
        InnerPlay(true, soundKey);
    }


    private void InnerPlay(bool loop, string soundKey)
    {
		if (audioSources.ContainsKey (soundKey))
		{
			AudioSource source = audioSources [soundKey];

			source.loop = loop;
			source.Play ();
			// set volume level of music about to be played to saved level
			source.volume = PlayerPrefs.GetFloat ("VolumeLevel");
		}
        else
        {
            Debug.LogError("attempted to play sound " + soundKey + ", but it was not a child of the AudioPlayer");
        }
    }

	public AudioSource GetAudioSource(string key)
	{
		return audioSources [key];
	}

	public bool AudioSourceExists(string key)
	{
		return audioSources.ContainsKey (key);
	}


}
