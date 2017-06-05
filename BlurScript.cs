using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using System.Collections.Generic;
#if UNITY_IOS
using UnityEngine.iOS;
#endif


public class BlurScript : MonoBehaviour
{

    public bool DebugPowerUps;
	private bool ForcePowerUpPause = true;

    private BlurOptimized blur;

	private float timer;
	private bool isPassed5Second;

	public Text ItemTitleText;
	public Text ItemInfoText;
	public Text ItemDetailText;
	public GameObject ItemImage;
//	private GameObject hintCanvas;

    private GameController gameController;

	private GameObject[] GameStateObject;
	private GameObject[] PauseStateObject;
	private GameObject[] ActivePowerUpStateObject;
	private GameObject[] LockedPowerUpStateObject;
	private GameObject[] SignInStateObject;
	private GameObject SignInTabletImage;
	private GameObject PauseTabletImage;
	private GameObject[] TutorialStateObject;
//	private GameObject[] DeathStateObject;

    private VolumeSliderScript[] volumeSliders;

	public GameObject resumeButton;

	private Vector3 FirstVector;
	private Vector3 FinalVector;

	private bool isPauseObjectUp;
	private bool isPauseObjectDown;
	private bool isSignInObjectUp;
	private bool isSignInObjectDown;

	private Image darken;

	private int showedTut;
    private bool shouldBlur = true;

	public RectTransform animePower;

	private GameObject inGamePause;
	private GameObject inGameResume;
	private GameObject powerUpButton;

	//TODO: Find the better logic after all screens are added

	void Awake()
	{
		FinalVector = new Vector3 (Screen.width / 2 + 50, Screen.height / 2 - 50, 0);
		FirstVector = new Vector3 (Screen.width / 2 + 50, -2000, 0);
//		Debug.Log ("FirstVector : " + FirstVector);
//		Debug.Log ("FinalVector : " + FinalVector);
	}

	// Use this for initialization
	void Start () {


        #if UNITY_IOS
        if (UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad4Gen)
        {
            shouldBlur = false;
        }
        #endif

        volumeSliders = new VolumeSliderScript[2];
        volumeSliders[0] = GameObject.Find("SoundEffects").GetComponent<VolumeSliderScript>();
        volumeSliders[1] = GameObject.Find("Music").GetComponent<VolumeSliderScript>();


		
		blur = GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>();
		timer = 0.0f;
		isPassed5Second = false;


		isPauseObjectUp = false;
		isSignInObjectUp = false;
		isPauseObjectDown = false;
		isSignInObjectDown = false;

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
	
		GameStateObject = GameObject.FindGameObjectsWithTag ("GameStateObject");
		PauseStateObject = GameObject.FindGameObjectsWithTag ("PauseStateObject");
		ActivePowerUpStateObject = GameObject.FindGameObjectsWithTag ("ActivePowerUpStateObject");
		LockedPowerUpStateObject = GameObject.FindGameObjectsWithTag ("LockedPowerUpStateObject");
		SignInStateObject = GameObject.FindGameObjectsWithTag ("SignInStateObject");
		SignInTabletImage = GameObject.FindGameObjectWithTag ("SignInTabletImage");
		PauseTabletImage = GameObject.FindGameObjectWithTag ("PauseTabletImage");
	//	DeathStateObject = GameObject.FindGameObjectsWithTag ("DeathStateImage");
		TutorialStateObject = GameObject.FindGameObjectsWithTag("TutorialStateObject");

		darken = GameObject.Find ("DarkenBlur").GetComponent<Image> ();
		darken.enabled = false;

		inGamePause = GameObject.Find ("PauseButton");
		inGameResume = GameObject.Find ("ResumeButtonPowerUpPause");
		powerUpButton = GameObject.Find ("PowerUpButton");
	//	hintCanvas = GameObject.FindGameObjectWithTag("HintStateObject");
	//	if (hintCanvas != null && !PlayerPrefsKey.isShowHintsOnLevelStart ()) {
	//		hintCanvas.SetActive (false);
	//	}

		GameState ();

		showedTut = PlayerPrefs.GetInt("ShowTutOnLevelStart");
		inGameResume.SetActive (false);


	}
		
	void LateUpdate()
	{
		if (showedTut == 0) {
			StartTutorial ();
			PlayerPrefsKey.SetShowTutorialOnLevelStart (true);
			showedTut = 1;
		}
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefsKey.isShowHintsOnLevelStart ()) {
			timer += Time.deltaTime;

			if (!isPassed5Second && timer > 5.0) {
//				Debug.Log ("Update Time just passed 5 seconds");
				isPassed5Second = true;
		//		hintCanvas.SetActive (false);
			}
		}
			

//        float speed = 10f;
//        float delta = Time.deltaTime;

        // todo use rect transform

		if (isPauseObjectUp) {
			//Debug.Log ("PauseTabletImage.transform.position : " + PauseTabletImage.transform.position);
//            PauseTabletImage.transform.position = Vector3.Lerp (PauseTabletImage.transform.position, FinalVector, Time.deltaTime * 8f);
            PauseTabletImage.transform.position = Vector3.Lerp (PauseTabletImage.transform.position, FinalVector, 0.5f);
		} 

		if (isPauseObjectDown) {
            PauseTabletImage.transform.position = Vector3.Lerp (PauseTabletImage.transform.position, FirstVector, 0.5f);
		}

		if (isSignInObjectUp) {
			//Debug.Log ("SignInTabletImage.transform.position : " + SignInTabletImage.transform.position);
            SignInTabletImage.transform.position = Vector3.Lerp (SignInTabletImage.transform.position, FinalVector, 0.5f);
		} 

		if (isSignInObjectDown) 
		{
            SignInTabletImage.transform.position = Vector3.Lerp (SignInTabletImage.transform.position, FirstVector, 0.5f);
		}
			
	}


	private void DisplayPowerUp(PowerUp powerUp)
	{
		if (powerUp.itemName == PowerUpInfo.StethoScope) {
			ItemTitleText.text = PowerUpInfo.StethoScope;
			ItemInfoText.text = PowerUpInfo.StethoScopeInfo;
			ItemDetailText.text = PowerUpInfo.StethoScopeDetail;
			ItemImage.GetComponent<Image> ().sprite = Resources.Load<Sprite> (PowerUpInfo.StethoScopeImage);

		} else if (powerUp.itemName == PowerUpInfo.Crutches) {
			ItemTitleText.text = PowerUpInfo.Crutches;
			ItemInfoText.text = PowerUpInfo.CrutchesInfo;
			ItemDetailText.text = PowerUpInfo.CrutchesDetail;
			ItemImage.GetComponent<Image> ().sprite = Resources.Load<Sprite> (PowerUpInfo.CrutchesImage);
		} else if (powerUp.itemName == PowerUpInfo.Cuff) {
			ItemTitleText.text = PowerUpInfo.Cuff;
			ItemInfoText.text = PowerUpInfo.CuffInfo;
			ItemDetailText.text = PowerUpInfo.CuffDetail;
			ItemImage.GetComponent<Image> ().sprite = Resources.Load<Sprite> (PowerUpInfo.CuffImage);
		} else if (powerUp.itemName == PowerUpInfo.Gown) {
			ItemTitleText.text = PowerUpInfo.Gown;
			ItemInfoText.text = PowerUpInfo.GownInfo;
			ItemDetailText.text = PowerUpInfo.GownDetail;
			ItemImage.GetComponent<Image> ().sprite = Resources.Load<Sprite> (PowerUpInfo.GownImage);
		}
		PlayerPrefsKey.ActivatedPowerUp (powerUp);
	}
		
	public void PauseState()
	{
        blur.enabled = true && shouldBlur;
		darken.enabled = true;		
		animePower.position = new Vector3 (0, 0, -100);	// move animation off screen for 
		gameController.PauseGame ();					// pause menu, can't just deactivate, will cancel animation

		if (!isPauseObjectUp) {
			isPauseObjectUp = true;
			isPauseObjectDown = false;

		}

		isSignInObjectUp = false;

		for (int i = 0; i < GameStateObject.Length; i++) {
			GameObject obj = GameStateObject [i];
			obj.SetActive (false);
		}

	//	hintCanvas.SetActive (false);

		for (int i = 0; i < PauseStateObject.Length; i++) {
			GameObject obj = PauseStateObject [i];
			obj.SetActive (true);
		}

		resumeButton.SetActive (true);

        EnableSliders();
	}

    public void BlurUI()
    {
        blur.enabled = true && shouldBlur;
        darken.enabled = true;
    }

    public void UnblurUI()
    {
        blur.enabled = false;
        darken.enabled = false;
    }

	public void GameState()
	{

		animePower.parent.localPosition = new Vector3 (-88, 88, 0);	// move animation back over button

		blur.enabled = false;
		darken.enabled = false;
		
		gameController.UnPauseGame ();

		if (isPauseObjectUp) {
			isPauseObjectUp = false;
			isPauseObjectDown = true;
		}

		if (isSignInObjectUp) {
			isSignInObjectUp = false;
			isSignInObjectDown = true;

		}


		for (int i = 0; i < GameStateObject.Length; i++) {
			GameObject obj = GameStateObject [i];
			obj.SetActive (true);
		}

		for (int i = 0; i < PauseStateObject.Length; i++) {
			GameObject obj = PauseStateObject [i];
			obj.SetActive (false);
		}

		resumeButton.SetActive (false);


		for (int i = 0; i < SignInStateObject.Length; i++) {
			GameObject obj = SignInStateObject [i];
			obj.SetActive (false);
		}

		for (int i = 0; i < ActivePowerUpStateObject.Length; i++) {
			GameObject obj = ActivePowerUpStateObject [i];
			obj.SetActive (false);
		}

		for (int i = 0; i < LockedPowerUpStateObject.Length; i++) {
			GameObject obj = LockedPowerUpStateObject [i];
			obj.SetActive (false);
		}
		for (int i = 0; i < TutorialStateObject.Length; i++) {
			GameObject obj = TutorialStateObject [i];
			obj.SetActive (false);
		}

		inGameResume.SetActive(false);

        DisableSliders();


	}
		

	public void ActivePowerUpState(PowerUp powerUp)
	{
		if ((PlayerPrefsKey.isUserRegisterd () || DebugPowerUps) && ((powerUp.itemName == PowerUpInfo.StethoScope) || (powerUp.itemName == PowerUpInfo.Crutches) || 
			(powerUp.itemName == PowerUpInfo.Gown) || (powerUp.itemName == PowerUpInfo.Cuff)))
		{			
			if (!PlayerPrefsKey.IsPowerUpActivated(powerUp) || ForcePowerUpPause) {

				DisplayPowerUp (powerUp);
				gameController.PauseGame ();

                blur.enabled = true && shouldBlur;
				darken.enabled = true;

				isPauseObjectUp = false;
				isSignInObjectUp = false;

				for (int i = 0; i < GameStateObject.Length; i++) {
					GameObject obj = GameStateObject[i];
					obj.SetActive (false);
				}

//				hintCanvas.SetActive (false);



				for (int i = 0; i < ActivePowerUpStateObject.Length; i++) {
					GameObject obj = ActivePowerUpStateObject[i];
					obj.SetActive (true);
				}


			}
			powerUp.PowerUpUsed();
		} 
		else 
		{
			LockedPowerUpState();
		}
		inGameResume.SetActive(false);

	}

	public void LockedPowerUpState()
	{
        blur.enabled = true && shouldBlur;
		darken.enabled = true;
		gameController.PauseGame ();

		isPauseObjectUp = false;
		isSignInObjectUp = false;

		for (int i = 0; i < GameStateObject.Length; i++) {
			GameObject obj = GameStateObject [i];
			obj.SetActive (false);
		}
	//	hintCanvas.SetActive (false);


		for (int i = 0; i < SignInStateObject.Length; i++) {
			GameObject obj = SignInStateObject [i];
			obj.SetActive (false);
		}



		for (int i = 0; i < LockedPowerUpStateObject.Length; i++) {
			GameObject obj = LockedPowerUpStateObject [i];
			obj.SetActive (true);
		}
		inGameResume.SetActive(false);


	}

	public void SignInState()
	{
        blur.enabled = true && shouldBlur;
		darken.enabled = true;
		if (!isSignInObjectUp) {
			isSignInObjectUp = true;
			isSignInObjectDown = false;

		}

		isPauseObjectUp = false;


		for (int i = 0; i < SignInStateObject.Length; i++) {
			GameObject obj = SignInStateObject [i];
			obj.SetActive (true);
		}
			

		for (int i = 0; i < LockedPowerUpStateObject.Length; i++) {
			GameObject obj = LockedPowerUpStateObject [i];
			obj.SetActive (false);
		}
		inGameResume.SetActive(false);


	}

/*	public void pauseOnDeath()
	{

		blur.enabled = true;
		darken.enabled = true;
		gameController.PauseGame ();

		for (int i = 0; i < GameStateObject.Length; i++) {
			GameObject obj = GameStateObject [i];
			obj.SetActive (false);
		}
		hintCanvas.SetActive (false);

		for (int i = 0; i < PauseStateObject.Length; i++) {
			GameObject obj = PauseStateObject [i];
			obj.SetActive (false);
		}

		for (int i = 0; i < DeathStateObject.Length; i++) {
			GameObject obj = DeathStateObject [i];
			obj.SetActive (true);
		}




	}
*/

	public void pauseOnPowerUp()
	{
		blur.enabled = true;
		gameController.PauseGame ();

		inGameResume.SetActive (true);
		inGamePause.SetActive (false);
		powerUpButton.SetActive (false);

	}

	public void SetPowerUpTrue()
	{
		powerUpButton.SetActive (true);
		inGameResume.SetActive (false);
	}

	public void StartTutorial()
	{
        blur.enabled = true && shouldBlur;
		darken.enabled = true;
		gameController.PauseGame ();

	

		for (int i = 0; i < TutorialStateObject.Length; i++) {
			GameObject obj = TutorialStateObject [i];
			obj.SetActive (true);
		}

		for (int i = 0; i < GameStateObject.Length; i++) {
			GameObject obj = GameStateObject [i];
			obj.SetActive (false);
		}
	}

    private void EnableSliders()
    {
        foreach (VolumeSliderScript volumeSlider in volumeSliders)
        {
            volumeSlider.SetActive();
        }
    }

    private void DisableSliders()
    {
        foreach (VolumeSliderScript volumeSlider in volumeSliders)
        {
            volumeSlider.SetInactive();
        }
    }

}


