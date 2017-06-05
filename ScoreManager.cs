using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public float HealthStart = .7f;
//    public float MonsterHealthUnit = .04f;
    public float HealthDecayPerSecond = .03f;
    public float HealthGain = .1f;


    public bool EndSceneOnDie = true;

	public Camera camera;

	private Text scoreText;
	private Text lassoScoreText;
	private Text multiplierText;
	private Text multiplierExcla;
	private Text multiplierX;
	private Text LassoScoreTxtPts;
	private RectTransform LassoScoreText;
	private RectTransform LassoScorePts;
	private RectTransform MultiplierText;
	private RectTransform MultiplierExcla;
	private RectTransform MultiplierX;
	private RectTransform Pts;
	private RectTransform scoreNum;
	private Image scoreBarImage;
	private Text userHighScore;
	//private Text globalHighScore;

    private int points;

	private bool multiplierCheck = false;

//    private GameController gameController;
    private int MonstersDestroyedCount = 0;

    private float currentHealth;
   
    private float lastTimeHealthSet;
	private float lastTimeMultiplierSet = -1;

	private Animator animeMult;
	private Animator animeMultX;
	private Animator animeMultExcla;

	private Animator animePts;
	private Animator animePtsTxt;

	private int scoreS = 0;

    public HudController hudController;

    private float doublePointsUntil = -1;

//    private MonsterCreator monsterCreator;

    private bool died = false;


	// Thomas' sweet score manager with all animations that have to do with points

	void Start () 
	{
        scoreText = GameObject.Find("HighScore").GetComponent<Text>();
		lassoScoreText = GameObject.Find ("lassoScorePoints").GetComponent<Text> ();
		LassoScoreTxtPts = GameObject.Find ("lassoScorePts").GetComponent<Text> ();
		LassoScoreText = GameObject.Find ("lassoScorePoints").GetComponent<RectTransform> ();
		LassoScorePts = GameObject.Find ("lassoScorePts").GetComponent<RectTransform> ();
		Pts = GameObject.Find("Pts").GetComponent<RectTransform>();
		multiplierText = GameObject.Find ("Multiplier").GetComponent<Text> ();
		multiplierX = GameObject.Find ("MultiplierX").GetComponent<Text> ();
		multiplierExcla = GameObject.Find ("MultiplierExcla").GetComponent<Text> ();


		MultiplierText = GameObject.Find ("Multiplier").GetComponent<RectTransform> ();
		MultiplierX = GameObject.Find ("MultiplierX").GetComponent<RectTransform> ();
		MultiplierExcla = GameObject.Find ("MultiplierExcla").GetComponent<RectTransform> ();

		scoreNum = GameObject.Find ("HighScore").GetComponent<RectTransform>();
		scoreBarImage = GameObject.Find("ScoreBarImage").GetComponent<Image>();
		userHighScore = GameObject.Find("YourScoreText").GetComponent<Text>();
//		globalHighScore = GameObject.Find("GlobalScoreText").GetComponent<Text>();
		animeMult = GameObject.Find ("Multiplier").GetComponent<Animator> ();
		animeMultX = GameObject.Find ("MultiplierX").GetComponent<Animator> ();
		animeMultExcla = GameObject.Find ("MultiplierExcla").GetComponent<Animator> ();
		animePts = GameObject.Find ("lassoScorePoints").GetComponent<Animator> ();
		animePtsTxt = GameObject.Find ("lassoScorePts").GetComponent<Animator> ();





		points = 0;
		SetScoreText ();


		userHighScore.text = PlayerPrefsKey.GetLevelHighScore(1).ToString();
	//	globalHighScore.text = PlayerPrefsKey.GetGlobalHighScoreFromLevel(1).ToString();

        currentHealth = HealthStart;

//        SetMonsterAliveCount(0);

		LevelName ();

	}

    void Update()
    {
        currentHealth -= (HealthDecayPerSecond * Time.deltaTime);
        currentHealth = Mathf.Clamp(currentHealth, 0f, 1f);

        SetHealthPercent(currentHealth);

		if (Time.time >= lastTimeMultiplierSet + 2 && multiplierCheck == true) 
		{
		
			multiplierText.text = "";
			multiplierX.text = "";
			multiplierExcla.text = "";
			animeMult.SetInteger ("SetFlash", 0);
			animeMultX.SetInteger ("SetFlash", 0);
			animeMultExcla.SetInteger ("SetFlash", 0);

			multiplierCheck = false;
		}

		if (Time.time >= lastTimeMultiplierSet + 2) 
		{
			lassoScoreText.text = "";
			LassoScoreTxtPts.text = "";
			LassoScorePts.position = new Vector3 (500, 500, 0);
//			animePtsTxt.SetInteger ("SetFlash", 0);
//			animePts.SetInteger ("SetFlash", 0);

		}

    }

    private void SetHealthPercent(float percent)
    {
		if (percent > 0f) {
			RectTransform scoreBarTransform = scoreBarImage.GetComponent<RectTransform> ();
			scoreBarTransform.sizeDelta = new Vector2 (458 * percent, scoreBarTransform.sizeDelta.y);

			UpdateHealthColor (percent);
            hudController.flashHealth (percent);

			
		}
        else if(percent < .1f && EndSceneOnDie) 
		{
			int levelS = SceneTracker.GetCurrentLevelWithName (SceneManager.GetActiveScene ().name);
			PlayerPrefsKey.SetLevelHighScore(levelS, points);
			PlayerPrefsKey.SetLevelHighMonster(levelS, MonstersDestroyedCount);
            if (EndSceneOnDie && !died)
            {
                died = true;
                PlayerPrefsKey.SetLevelHighScore(levelS, points);
                PlayerPrefsKey.SetLevelHighMonster(levelS, MonstersDestroyedCount);

				//FindObjectOfType<BlurScript> ().pauseOnDeath ();
				SceneManager.LoadScene(SceneName.LevelResults);
            }

//            SceneManager.LoadScene(SceneName.BonusSurvey);
		}
    }
	
	public void AddFlingScore(GameObject flingMonster)
	{
	    MonstersDestroyedCount += 1;
        currentHealth += HealthGain;
        if (Time.time < doublePointsUntil)
        {
            points += 2;
        }else
        {
		    points += 1; // todo
        }
		SetScoreText();
	}



	public void AddLassoObjectsScore(GameObject[] monsters)
	{
		int pts = points;
//		Debug.Log ("pts: " + pts);
//		Debug.Log ("Points: " + points);
	    MonstersDestroyedCount += monsters.Length;
        currentHealth += (HealthGain * monsters.Length);
	    points += GetPointsForLassodMonsters(monsters);
//		Debug.Log ("pts: " + pts);
//		Debug.Log ("Points: " + points);
		if (pts != points) {

			animePtsTxt.Play ("FlashinFadeOut", 0, 0f);
			animePts.Play ("FlashinFadeOut", 0, 0f);
		}
	


		SetScoreText();


	}

	void SetScoreText()
	{
		scoreText.alignment = TextAnchor.MiddleCenter;
		scoreText.text = points + "";
		MovePts();
	}
		
	public void SetMultiplierText(int monsterCount)
	{

		multiplierText.alignment = TextAnchor.MiddleCenter;
		if (monsterCount >= 3) 
		{
			//if (this.animeMult.GetCurrentAnimatorStateInfo (0).IsName ("SetFlash")) 
			//{
				
				lastTimeMultiplierSet = Time.time;
				multiplierText.text = monsterCount + "";
				multiplierX.text = "X";
				multiplierExcla.text = "!";
				//animeMult.SetInteger ("SetFlash", 1);
				animeMult.Play ("FlashinFadeOut", 0, 0f);
				//animeMultX.SetInteger ("SetFlash", 1);
				animeMultX.Play ("FlashinFadeOut", 0, 0f);
				//animeMultExcla.SetInteger ("SetFlash", 1);
				animeMultExcla.Play ("FlashinFadeOut", 0, 0f);

				multiplierCheck = true;
			//}
		}
	}
		
    private int GetPointsForLassodMonsters(GameObject[] monsters)
    {
        int score = 0;
        foreach (GameObject monster in monsters)
        {
            MonsterData monsterData = monster.GetComponent<MonsterData>();
            score += monsterData.PointMultiplier;
        }

        if (monsters.Length >= 5)
        {
            score = score*3;
        }else if (monsters.Length >= 3)
        {
            score = score*2;
        }

        if (Time.time < doublePointsUntil)
        {
            score = score*2;
        }


		scoreS = score;
        return score;

    }

    public void ActivateDoublePoints(float duration)
    {
        doublePointsUntil = Time.time + duration;
    }

	void MovePts()
	{
		if (points < 10) {
			Pts.localPosition = new Vector3 (-50, 2, 2);
		} else if (points < 100) {
			scoreNum.localPosition = new Vector3 (0, 2, 2);
			Pts.localPosition = new Vector3 (-16, 2, 2);
		} else if (points < 1000) {
			scoreNum.localPosition = new Vector3 (20, 2, 2);
			Pts.localPosition = new Vector3 (24, 2, 2);
		} else if (points < 10000) {
			scoreNum.localPosition = new Vector3 (38, 2, 2);
			Pts.localPosition = new Vector3 (60, 0, 2);
		} else 
		{
			scoreNum.localPosition = new Vector3 (26, 5, 2);
			Pts.localPosition = new Vector3 (47, 0, 2);
		}
	}

	void UpdateHealthColor(float percent){
		
		if (percent <= .60f && percent > .35f) 
		{
			scoreBarImage.color = new Color32(251, 235, 20, 255);
		}
		else if (percent <= .36f) 
		{
			scoreBarImage.color = new Color32(255, 110, 0, 255);
		} 
		else 
		{
			scoreBarImage.color = new Color32(131, 211, 3, 255);
		}

	}

	public void LevelName(){
		SceneTracker.setLevelName (SceneManager.GetActiveScene ().name);
	}

    public void SetHealth(float healthPercent)
    {
        currentHealth = healthPercent;
    }

	public void SetMultiplierSpot(Vector3 center)
	{
		//Debug.Log ("Setting text position!");
		//Debug.Log ("Setting xyz " + center.x +" "+ center.y +" "+ center.z);

		center = camera.WorldToScreenPoint (center);
	
		//Debug.Log ("Setting xyz after worldtoscreen " + center.x + " " + center.y + " " + center.z);

		MultiplierText.position = new Vector3(center.x, center.y, center.z);
		MultiplierX.position = new Vector3 (center.x - 13, center.y - 20, center.z);
		MultiplierExcla.position = new Vector3 (center.x + 77, center.y - 13, center.z);

	}

	public void SetPointsSpot(Vector3 center)
	{
		center = camera.WorldToScreenPoint (center);

		lassoScoreText.text = scoreS + "";
		LassoScoreTxtPts.text = "pts";
		lastTimeMultiplierSet = Time.time;
		LassoScoreText.position = new Vector3 (center.x, center.y, center.z);
		if (scoreS < 10)
			LassoScorePts.position = new Vector3 (center.x, center.y, center.z);
		else if (scoreS >= 10)
			LassoScorePts.position = new Vector3 (center.x + 40, center.y, center.z);
		else if (scoreS >= 100)
			LassoScorePts.position = new Vector3 (center.x + 100, center.y, center.z);

	}

}
