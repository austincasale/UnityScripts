using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelResultsScript : MonoBehaviour {

	public Image StarImage1;
	public Image StarImage2;
	public Image StarImage3;

	public Text PointText;
	public Text UnMonstersText;
	public Text BestPointText;
	public Text BestUnMonstersText;

	private int level;
	private string sceneName;

//	private int monstersCreated;
	private int monstersCaught;


	private Animator anime;
	private Animator anime2;

	void Awake()
	{

	}

	// Use this for initialization
	void Start () {

		anime = GameObject.Find ("ReplayCircle").GetComponent<Animator> ();
		anime2 = GameObject.Find ("OkCheck").GetComponent<Animator> ();

		// set level
		if (SceneTracker.levelName == SceneName.ExamRoom) 
		{
			level = 2;
		} 
		else if (SceneTracker.levelName == SceneName.Lobby)
		{
			level = 3;
		} 
		else if (SceneTracker.levelName == SceneName.XRay)
		{
			level = 1;
		}	

//		monstersCreated = PlayerPrefsKey.GetMonstersCreated();
		monstersCaught = PlayerPrefsKey.GetCurrentLevelMonster();


		PointText.text = PlayerPrefsKey.GetCurrentLevelPoint ().ToString ();
		BestPointText.text = PlayerPrefsKey.GetLevelHighScore (level).ToString();
		UnMonstersText.text = monstersCaught.ToString();
		BestUnMonstersText.text = PlayerPrefsKey.GetLevelMonster (level).ToString();




		if (PlayerPrefsKey.GetCurrentLevelPoint() < 100) { // 0 stars
			if (PlayerPrefsKey.GetLevelStar (level) != 1 || PlayerPrefsKey.GetLevelStar (level) != 2 || PlayerPrefsKey.GetLevelStar (level) != 3)
				PlayerPrefsKey.SetLevelStar (level, 0);
			StarImage1.sprite = Resources.Load<Sprite> ("ui/assets_star-empty");
			StarImage2.sprite = Resources.Load<Sprite> ("ui/assets_star-empty");
			StarImage3.sprite = Resources.Load<Sprite> ("ui/assets_star-empty");

		} else if (PlayerPrefsKey.GetCurrentLevelPoint() >= 100 && PlayerPrefsKey.GetCurrentLevelPoint() < 200) { // 1 star
			if (PlayerPrefsKey.GetLevelStar (level) < 1)
				PlayerPrefsKey.SetLevelStar (level, 1);
			StarImage1.sprite = Resources.Load<Sprite> ("ui/assets_star-filled");
			StarImage2.sprite = Resources.Load<Sprite> ("ui/assets_star-empty");
			StarImage3.sprite = Resources.Load<Sprite> ("ui/assets_star-empty");

		} else if (PlayerPrefsKey.GetCurrentLevelPoint() >= 200 && PlayerPrefsKey.GetCurrentLevelPoint() < 300) { // 2 stars
			if (PlayerPrefsKey.GetLevelStar (level) < 2)
				PlayerPrefsKey.SetLevelStar (level, 2);
			StarImage1.sprite = Resources.Load<Sprite> ("ui/assets_star-filled");
			StarImage2.sprite = Resources.Load<Sprite> ("ui/assets_star-filled");
			StarImage3.sprite = Resources.Load<Sprite> ("ui/assets_star-empty");
		} else if (PlayerPrefsKey.GetCurrentLevelPoint() >= 300) { // 3 stars
			if (PlayerPrefsKey.GetLevelStar (level) < 3)
				PlayerPrefsKey.SetLevelStar (level, 3);
			StarImage1.sprite = Resources.Load<Sprite> ("ui/assets_star-filled");
			StarImage2.sprite = Resources.Load<Sprite> ("ui/assets_star-filled");
			StarImage3.sprite = Resources.Load<Sprite> ("ui/assets_star-filled");

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReplayAction()
	{
		anime.SetInteger ("Clicked", 1);

		StartCoroutine (HoldUp ());

		SceneTracker.setToDefault ();
        SceneManager.LoadScene(SceneTracker.GetChosenLevel());
	}

	public void OKAction()
	{
		anime2.SetInteger ("Clicked", 1);
		StartCoroutine (HoldUp ());

	
		if (PlayerPrefsKey.AmIinTheTop10List (1, PlayerPrefsKey.GetCurrentLevelPoint ())) {
			SceneTracker.SetFromGameResult (true);
			SceneManager.LoadScene(SceneName.HighScore);

		} else {
			SceneTracker.setToDefault();
			SceneManager.LoadScene(SceneName.Minimap);
		}

	}

	IEnumerator HoldUp()
	{
		yield return new WaitForSeconds (1.5f);
	}

}
