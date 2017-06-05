using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class HighScoreScript : MonoBehaviour {

	public List<Text> ScoreList;
	public List<InputField> PlayerInputField;

	public Text LevelText;

	public GameObject OkButton;
	private InputField SelectedInputField;

	private int Spot;
	private int Level;
	void Awake()
	{
	}

	// Use this for initialization
	void Start () {
		// Change TabletImage scale
		Level = SceneTracker.GetCurrentLevel();

		foreach (InputField input in PlayerInputField) {
			input.characterLimit = 10;
		}

		if (SceneTracker.IsItFromGameResult ()) {
			Spot = PlayerPrefsKey.ChangeHighScoreList (Level, PlayerPrefsKey.GetCurrentLevelPoint ());
			InputField[] textArray = PlayerInputField.ToArray ();
			for (int i = 0; i < textArray.Length; i++) {
				InputField input = textArray [i];
				if (i == Spot) {
					SelectedInputField = input;
					input.interactable = true;
					input.Select ();
					input.ActivateInputField ();
				} else
					input.interactable = false;
			}

			OkButton.SetActive (true);
		} else {
			foreach (InputField input in PlayerInputField) {
				input.interactable = false;
			}
		}
		/*if(SceneTracker.getLevelName() == 1)
			SetScoreText(PlayerPrefsKey.GetHighScoreList(SceneTracker.GetCurrentLevelWithName(1)));
		else if (SceneTracker.getLevelName() == 2)
			SetScoreText(PlayerPrefsKey.GetHighScoreList(SceneTracker.GetCurrentLevelWithName(2)));
		else if (SceneTracker.getLevelName() == 3)
			SetScoreText(PlayerPrefsKey.GetHighScoreList(SceneTracker.GetCurrentLevelWithName(3)));
		*/
		SetScoreText(PlayerPrefsKey.GetHighScoreList(SceneTracker.GetCurrentLevelWithName(SceneTracker.getLevelName())));

		
		LevelText.text = SceneTracker.getLevelName();

		Debug.Log ("Updating highscore: " + Level + " " + Spot +" " + name);


	}

	public void gobackAction()
	{
		if (SceneTracker.IsItFromGameResult ()) {
			SceneManager.LoadScene (SceneName.Minimap);
			SceneTracker.setToDefault ();
		} else {
			SceneManager.LoadScene (SceneTracker.sceneName);
			SceneTracker.setToDefault ();
		}

	}

	public void UpdateHighScoreNameList()
	{
		string name = "";
		if (SelectedInputField.text.Length == 0)
			name = "No Name";
		else
			name = SelectedInputField.text;
		
		PlayerPrefsKey.UpdateHighScoreNameList (Level, Spot, name);
		gobackAction ();
	}

	void SetScoreText(int[] score)
	{
		Text[] textArray = ScoreList.ToArray ();

		for (int i = 0; i < score.Length; i++) {
			Text text = textArray [i];
			text.text = score [i].ToString ();
		}
		if (SceneTracker.IsItFromGameResult ()) {
			PlayerPrefsKey.UpdateHighScoreNameList (Level, Spot, "");
		}

		InputField[] InputFieldArray = PlayerInputField.ToArray ();
		string[] LevelNameList = PlayerPrefsKey.GetHighScoreNameList (SceneTracker.GetCurrentLevelWithName(SceneTracker.getLevelName()));
		for (int i = 0; i < InputFieldArray.Length; i++) {
			InputField text = InputFieldArray [i];
			text.text = LevelNameList [i];
		}

//		Player1.placeholder.GetComponent<Text>().text = score.player1;
//		Player2.placeholder.GetComponent<Text>().text = score.player2;
//		Player3.placeholder.GetComponent<Text>().text = score.player3;
//		Player4.placeholder.GetComponent<Text>().text = score.player4;
//		Player5.placeholder.GetComponent<Text>().text = score.player5;
//		Player6.placeholder.GetComponent<Text>().text = score.player6;
//		Player7.placeholder.GetComponent<Text>().text = score.player7;
//		Player8.placeholder.GetComponent<Text>().text = score.player8;
//		Player9.placeholder.GetComponent<Text>().text = score.player9;
//		Player10.placeholder.GetComponent<Text>().text = score.player10;
	}
}
