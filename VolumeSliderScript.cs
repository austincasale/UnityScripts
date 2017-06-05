using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class VolumeSliderScript : MonoBehaviour {

	public List<GameObject> buttons;

	public Slider MusicVolumeSlider;

    Sprite soundbarBlue;
    Sprite soundbarNavy; 

    public bool SlidersActiveDefault = false;
    public bool SlidersActive { get; set;}

	// Use this for initialization
	void Start () {
        soundbarBlue = Resources.Load<Sprite>("ui/assets_soundbar-blue");
        soundbarNavy = Resources.Load<Sprite> ("ui/assets_soundbar-navy");

        SlidersActive = SlidersActiveDefault;
	}

	// Update is called once per frame
	void Update () {
        if (SlidersActive)
        {
            ChangeVolumnLevel();
        }
	}

    public void SetActive(){
        SlidersActive = true;
    }

    public void SetInactive(){
        SlidersActive = false;
    }

	public void ChangeVolumnLevel()
	{
        foreach (GameObject btn in buttons) {
            btn.GetComponent<Image>().sprite = soundbarBlue;
        }

		int counter = 12;
		float lastVal = 0;
		float thirTeenth = 0.07692307692f;

		for (float l = 1f; l > 0; l = l - thirTeenth)
		{
			lastVal = l + thirTeenth;
			if (MusicVolumeSlider.value <= lastVal && MusicVolumeSlider.value >= l) 
			{
				UpdateButtons (counter);
			}
			counter--;
		}

	}

	public void UpdateButtons(int x)
	{
		for (int i = 0; i <= x; i++) {
			GameObject button = buttons [i];
            button.GetComponent<Image>().sprite = soundbarNavy;
		}

	}

}
