using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HudController : MonoBehaviour {

	public GameObject avatarImage;
	private GameController gameController;
	private Animator anime;
	private Animator healthBar;

	private AudioSource source;

	// Handles health flashing mechanic and monster pop up animation + sound on Player health HUD
	// as well as Eek sound, replay, and quit action.


	void Start () {
		
        avatarImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/" + PlayerPrefsKey.GetUserAvatar());

        gameController = FindObjectOfType<GameController>();

        anime = GameObject.Find("animationImage").GetComponent<Animator> ();
        healthBar = GameObject.Find("ScoreBarImage").GetComponent<Animator> ();

	}
        
	
	void Update () {
		
		if (anime.GetCurrentAnimatorStateInfo (0).IsName ("fretta_hud"))
		{
			anime.SetInteger ("AnimationState", 5);
		} 
		else if (anime.GetCurrentAnimatorStateInfo (0).IsName ("ooz_hud"))
		{
			anime.SetInteger ("AnimationState", 5);
		} 
		else if (anime.GetCurrentAnimatorStateInfo (0).IsName ("tizzy_hud")) 
		{
			anime.SetInteger ("AnimationState", 5);
		} 
		else if (anime.GetCurrentAnimatorStateInfo (0).IsName ("jitters_hud")) 
		{
			anime.SetInteger ("AnimationState", 5);
		}
			

	}

    public void PauseGame()
    {

    }

	public void ReplayAction()
	{
        
        SceneManager.LoadScene (SceneTracker.GetChosenLevel());

	}

	public void QuitAction()
	{


		gameController.UnPauseGame();
		SceneManager.LoadScene (SceneName.Minimap);
	}

	public void UpdateAnimation(string monsterName)
	{
		AudioSource source;

		if (monsterName == "Fretta") 
		{
			source = GameObject.Find ("FourFrettas").GetComponent<AudioSource> ();
			anime.Play("fretta_hud", 0, 0f);
			source.Play();
		}
		else if (monsterName == "Tizzy")
		{
			source = GameObject.Find ("FourTizzies").GetComponent<AudioSource> ();
			anime.Play("tizzy_hud", 0, 0f);
			source.Play();
		} 
		else if (monsterName == "Ooz")
		{
			source = GameObject.Find ("FourOozes").GetComponent<AudioSource> ();
			anime.Play("ooz_hud", 0, 0f);
			source.Play();
		}
		else if (monsterName == "Jitters") 
		{
			source = GameObject.Find ("FourJitters").GetComponent<AudioSource> ();
			anime.Play("jitters_hud", 0, 0f);
			source.Play();
		}
	}


	public void flashHealth(float percent)
	{
        if (healthBar.isInitialized)
        {
            if (percent <= .25f)
            {
                healthBar.SetInteger("FlashState", 1);
            }
            else
            {
                healthBar.SetInteger("FlashState", 0);
            }
        }
	}

	public void EekCaughtSound()
	{
		AudioSource source = GameObject.Find ("EekCaught").GetComponent<AudioSource>();
					source.Play ();

	}


}
