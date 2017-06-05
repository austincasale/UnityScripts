using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpAnimationController : MonoBehaviour {
	
	private AudioSource gownSound;
	private AudioSource cuffSound;
	private AudioSource stethoSound;
	private AudioSource crutchSoundEnd;
	private AudioSource crutchSoundBegin;

	//private Button cuff;
	//private Button stethoscope;
	//private Button gown;
	//private Button crutches;
	private Button powerUpButton;



	private Animator PowerUpAnimationState;

	// This script handles all sound and animation for all 4 powerups

	// Use this for initialization
	void Start () {

		gownSound= GameObject.Find("Gown").GetComponent<AudioSource> ();
		cuffSound = GameObject.Find("Cuff").GetComponent<AudioSource> ();
		stethoSound = GameObject.Find ("Stetho").GetComponent<AudioSource> ();
		crutchSoundBegin = GameObject.Find("CrutchStart").GetComponent<AudioSource> ();
		crutchSoundEnd = GameObject.Find("CrutchEnd").GetComponent<AudioSource> ();

		powerUpButton = GameObject.Find ("PowerUpButton").GetComponent<Button> ();

		PowerUpAnimationState = GameObject.Find("PowerUpAnimation").GetComponent<Animator> ();



	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// Each function handles a different powerups sound and animation

	public void CrutchesActivateAnim()
	{
		crutchSoundBegin.Play ();

		PowerUpAnimationState.SetBool ("Crutches", true);
		powerUpButton.interactable = false;
	}

	public void CrutchesDeactivateAnim()
	{
		crutchSoundEnd.Play ();

		PowerUpAnimationState.SetBool ("Crutches", false);
		powerUpButton.interactable = true;
	}

	public void CuffActivateAnim()
	{
		cuffSound.Play ();
		PowerUpAnimationState.SetBool ("Cuff", true);
		powerUpButton.interactable = false;
	}
	public void CuffDeactivateAnim()
	{

		PowerUpAnimationState.SetBool ("Cuff", false);
		powerUpButton.interactable = true;
	}

	public void StethoscopeActivateAnim()
	{
		stethoSound.Play ();

		PowerUpAnimationState.SetBool ("Stethoscope", true);
		powerUpButton.interactable = false;
	}

	public void StethoscopeDeactivateAnim()
	{

		PowerUpAnimationState.SetBool ("Stethoscope", false);
		powerUpButton.interactable = true;

	}

	public void GownActivateAnim()
	{
		gownSound.Play ();

		PowerUpAnimationState.SetBool ("Gown", true);
		powerUpButton.interactable = false;
	}

	public void GownDeactivateAnim()
	{

		PowerUpAnimationState.SetBool ("Gown", false);
		powerUpButton.interactable = true;

	}

}
