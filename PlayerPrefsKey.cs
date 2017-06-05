using System;
using UnityEngine;
using System.Collections;

public class PlayerPrefsKey
{
	private static string avatar = "Avatar";
	private static string avatarIsBoy = "AvatarIsBoy";
	private static string avatarSlotNumber = "AvatarSlotNumber";
	private static string hasRegistred = "HasRegistred";

	private static string LevelScore = "LevelScore";
	private static string LevelMonster = "LevelMonster";
	private static string MonstersCreated = "MonstersCreated";

	private static string level1HighScore = "Level1HighScore";
	private static string level1HighMonster = "Level1HighMonster";
	private static string level1Star = "Level1Star";

	private static string level2HighScore = "Level2HighScore";
	private static string level2HighMonster = "Level2HighMonster";
	private static string level2Star = "Level2Star";

	private static string level3HighScore = "Level3HighScore";
	private static string level3HighMonster = "Level3HighMonster";
	private static string level3Star = "Level3Star";

	private static string level4HighScore = "Level4HighScore";
	private static string level4HighMonster = "Level4HighMonster";
	private static string level4Star = "Level4Star";

	private static string level5HighScore = "Level5HighScore";
	private static string level5HighMonster = "Level5HighMonster";
	private static string level5Star = "Level5Star";

	private static string FirstName = "FirstName";
	private static string LastName = "LastName";
	private static string Email = "Email";
	//private static string Password = "Password";

	private static string isStethoScopeActivated = "isStethoScopeActivated";
	private static string isGownActivated = "isGownActivated";
	private static string isCrutchesActivated = "isCrutchesActivated";
	private static string isCuffActivated = "isCuffActivated";
	private static string ShowHintsOnLevelStart = "ShowHintsOnLevelStart";
	private static string ShowTutorialOnLevelStart = "ShowTutOnLevelStart";

	private static string Level1HighScoreList = "Level1HighScoreList";
	private static string Level2HighScoreList = "Level2HighScoreList";
	private static string Level3HighScoreList = "Level3HighScoreList";
	private static string Level4HighScoreList = "Level4HighScoreList";
	private static string Level5HighScoreList = "Level5HighScoreList";

	private static string Level1NameList = "Level1NameList";
	private static string Level2NameList = "Level2NameList";
	private static string Level3NameList = "Level3NameList";
	private static string Level4NameList = "Level4NameList";
	private static string Level5NameList = "Level5NameList";

	private static string VolumeLevel = "VolumeLevel";
	private static string SoundEffectsLevel = "SoundEffectsLevel";

	private static bool ResetKey = false;

	public static void Init()
	{
		PlayerPrefsKey.SetInitStringValue (PlayerPrefsKey.avatar);
		PlayerPrefsKey.SetInitIntValueAsTrue (PlayerPrefsKey.avatarIsBoy);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.avatarSlotNumber);

		PlayerPrefsKey.SetInitStringValue (PlayerPrefsKey.FirstName);
		PlayerPrefsKey.SetInitStringValue (PlayerPrefsKey.LastName);
		PlayerPrefsKey.SetInitStringValue (PlayerPrefsKey.Email);
		//PlayerPrefsKey.SetInitStringValue (PlayerPrefsKey.Password);

		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.LevelScore);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.LevelMonster);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.MonstersCreated);

		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level1HighScore);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level1HighMonster);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level1Star);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level2HighScore);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level2HighMonster);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level2Star);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level3HighScore);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level3HighMonster);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level3Star);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level4HighScore);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level4HighMonster);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level4Star);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level5HighScore);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level5HighMonster);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.level5Star);
	
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.isGownActivated);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.isCrutchesActivated);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.isCuffActivated);
		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.isStethoScopeActivated);

		PlayerPrefsKey.SetInitIntValue (PlayerPrefsKey.hasRegistred);

		PlayerPrefsKey.SetInitIntValueAsTrue (PlayerPrefsKey.ShowHintsOnLevelStart);
		PlayerPrefsKey.SetInitIntValueAsFalse (PlayerPrefsKey.ShowTutorialOnLevelStart);

		PlayerPrefsKey.SetInitLevelHighScoreList (PlayerPrefsKey.Level1HighScoreList);
		PlayerPrefsKey.SetInitLevelHighScoreList (PlayerPrefsKey.Level2HighScoreList);
		PlayerPrefsKey.SetInitLevelHighScoreList (PlayerPrefsKey.Level3HighScoreList);
		PlayerPrefsKey.SetInitLevelHighScoreList (PlayerPrefsKey.Level4HighScoreList);
		PlayerPrefsKey.SetInitLevelHighScoreList (PlayerPrefsKey.Level5HighScoreList);

		PlayerPrefsKey.SetInitLevelNameList (PlayerPrefsKey.Level1NameList);
		PlayerPrefsKey.SetInitLevelNameList (PlayerPrefsKey.Level2NameList);
		PlayerPrefsKey.SetInitLevelNameList (PlayerPrefsKey.Level3NameList);
		PlayerPrefsKey.SetInitLevelNameList (PlayerPrefsKey.Level4NameList);
		PlayerPrefsKey.SetInitLevelNameList (PlayerPrefsKey.Level5NameList);

		PlayerPrefsKey.SetInitFloatValue (PlayerPrefsKey.VolumeLevel); // volume set
		PlayerPrefsKey.SetInitFloatValue(PlayerPrefsKey.SoundEffectsLevel);


		PlayerPrefs.Save ();
	}

	public static void SetInitLevelHighScoreList(string key)
	{
		if (!PlayerPrefs.HasKey (key) || ResetKey) {
			int[] results = new int[] {10,9,8,7,6,5,4,3,2,1};
			PlayerPrefsX.SetIntArray (key, results);
		}
	}

	public static void SetInitLevelNameList(string key)
	{
		if (!PlayerPrefs.HasKey (key) || ResetKey) {
			string[] results = new string[] {"Kat","Daniel","Mark","Austin","Aleks","Scott","Nathan","Kyle","Chris","Thomas"};
			PlayerPrefsX.SetStringArray (key, results);
		}
	}

	private static void SetInitStringValue(string key)
	{
		if (!PlayerPrefs.HasKey (key) || ResetKey)
			PlayerPrefs.SetString (key, "");
	}

	private static void SetInitIntValueAsTrue(string key)
	{
		if (!PlayerPrefs.HasKey (key) || ResetKey)
			PlayerPrefs.SetInt (key, 1);
	}

	private static void SetInitIntValueAsFalse(string key)
	{
		if (!PlayerPrefs.HasKey (key) || ResetKey)
			PlayerPrefs.SetInt (key, 0);
	}


	private static void SetInitIntValue(string key)
	{
		if (!PlayerPrefs.HasKey (key) || ResetKey)
			PlayerPrefs.SetInt (key, 0);
	}

	private static void SetInitFloatValue(string key)	// volume
	{
		if (!PlayerPrefs.HasKey (key) || ResetKey)
			PlayerPrefs.SetFloat (key, 1f);
	}

	public static int GetLevelStar(int level)
	{
		int highScore = -1;

		if (level == 1) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level1Star);
		} else if (level == 2) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level2Star);
		} else if (level == 3) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level3Star);
		} else if (level == 4) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level4Star);
		} else if (level == 5) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level5Star);
		}

		return highScore;
	}

	public static int GetLevelMonster(int level)
	{
		int highScore = -1;

		if (level == 1) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level1HighMonster);
		} else if (level == 2) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level2HighMonster);
		} else if (level == 3) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level3HighMonster);
		} else if (level == 4) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level4HighMonster);
		} else if (level == 5) {
			highScore = PlayerPrefs.GetInt (PlayerPrefsKey.level5HighMonster);
		}

		return highScore;
	}


	public static int GetLevelHighScore(int level)
	{
		int star = -1;

		if (level == 1) {
			star = PlayerPrefs.GetInt (PlayerPrefsKey.level1HighScore);
		} else if (level == 2) {
			star = PlayerPrefs.GetInt (PlayerPrefsKey.level2HighScore);
		} else if (level == 3) {
			star = PlayerPrefs.GetInt (PlayerPrefsKey.level3HighScore);
		} else if (level == 4) {
			star = PlayerPrefs.GetInt (PlayerPrefsKey.level4HighScore);
		} else if (level == 5) {
			star = PlayerPrefs.GetInt (PlayerPrefsKey.level5HighScore);
		}

		return star;
	}



	public static void userRegistred(string FirstName, string LastName, string Email, string Password)
	{
		PlayerPrefs.SetInt (PlayerPrefsKey.hasRegistred, 1);
		PlayerPrefs.SetString (PlayerPrefsKey.FirstName, FirstName);
		PlayerPrefs.SetString (PlayerPrefsKey.LastName, LastName);
		PlayerPrefs.SetString (PlayerPrefsKey.Email, Email);
		//PlayerPrefs.SetString (PlayerPrefsKey.Password, Password);

		PlayerPrefs.Save ();
	}

	public static string GetFirstName()
	{
		return PlayerPrefs.GetString (PlayerPrefsKey.FirstName);
	}

	public static string GetLastName()
	{
		return PlayerPrefs.GetString (PlayerPrefsKey.LastName);
	}

	public static string GetEmail()
	{
		return PlayerPrefs.GetString (PlayerPrefsKey.Email);
	}

	public static string GetPassword()
	{
		return "none";
	//	return PlayerPrefs.GetString (PlayerPrefsKey.Password);
	}
		

	public static bool IsPowerUpActivated(PowerUp powerUp)
	{
		bool value = false;
		if (powerUp.itemName == PowerUpInfo.StethoScope) {
			value = PlayerPrefs.GetInt(PlayerPrefsKey.isStethoScopeActivated) == 1 ? true : false;
		} else if (powerUp.itemName == PowerUpInfo.Crutches) {
			value = PlayerPrefs.GetInt(PlayerPrefsKey.isCrutchesActivated) == 1 ? true : false;
		} else if (powerUp.itemName == PowerUpInfo.Cuff) {
			value = PlayerPrefs.GetInt(PlayerPrefsKey.isCuffActivated) == 1 ? true : false;
		} else if (powerUp.itemName == PowerUpInfo.Gown) {
			value = PlayerPrefs.GetInt(PlayerPrefsKey.isGownActivated) == 1 ? true : false;
		}

		return value;

	}

	public static void ActivatedPowerUp(PowerUp powerUp)
	{
		if (powerUp.itemName == PowerUpInfo.StethoScope) {
			PlayerPrefs.SetInt(PlayerPrefsKey.isStethoScopeActivated ,1);
		} else if (powerUp.itemName == PowerUpInfo.Crutches) {
			PlayerPrefs.SetInt(PlayerPrefsKey.isCrutchesActivated ,1);
		} else if (powerUp.itemName == PowerUpInfo.Cuff) {
			PlayerPrefs.SetInt(PlayerPrefsKey.isCuffActivated ,1);
		} else if (powerUp.itemName == PowerUpInfo.Gown) {
			PlayerPrefs.SetInt(PlayerPrefsKey.isGownActivated ,1);
		}
		PlayerPrefs.Save ();
	}
		
//	private static void ShowHint(bool showHint)
//	{

//	}

	public static bool isUserRegisterd()
	{
		bool value = PlayerPrefs.GetInt(PlayerPrefsKey.hasRegistred) == 1 ? true : false;
		return value;
	}

	public static void UserRegisterd()
	{
		PlayerPrefs.SetInt (PlayerPrefsKey.hasRegistred, 1);
		PlayerPrefs.Save ();
	}

	public static void SetShowHintsOnLevelStart(bool show)
	{
		int value = show == true ? 1 : 0;
		PlayerPrefs.SetInt (PlayerPrefsKey.ShowHintsOnLevelStart, value);
		PlayerPrefs.Save ();
	}

	public static bool isShowHintsOnLevelStart()
	{
		bool value = PlayerPrefs.GetInt(PlayerPrefsKey.ShowHintsOnLevelStart) == 1 ? true : false;
		return value;
	}

	public static void SetShowTutorialOnLevelStart(bool show)
	{
		int value = show == true ? 1 : 0;
		PlayerPrefs.SetInt (PlayerPrefsKey.ShowTutorialOnLevelStart, value);
		PlayerPrefs.Save ();
		
	}

	public static string GetUserAvatar()
	{
		return PlayerPrefs.GetString (PlayerPrefsKey.avatar);
	}

	public static void SetUserAvatar(string avatar)
	{
		PlayerPrefs.SetString (PlayerPrefsKey.avatar, avatar);
		PlayerPrefs.Save ();
	}

	public static void SetAvatarBoy(bool avatar)
	{
		int value = avatar == true ? 1 : 0;
		PlayerPrefs.SetInt (PlayerPrefsKey.avatarIsBoy, value);
		PlayerPrefs.Save ();
	}

	public static bool CheckIfBoyAvatar()
	{
		bool value = PlayerPrefs.GetInt(PlayerPrefsKey.avatarIsBoy) == 1 ? true : false;
		return value;
	}

	public static void SetAvatarSlotNumber(int num)
	{
		PlayerPrefs.SetInt(PlayerPrefsKey.avatarSlotNumber, num);
		PlayerPrefs.Save ();
		Debug.Log("Setting avatar slot to: " + num);
	}

	public static int GetAvatarSlotNumber()
	{
		return PlayerPrefs.GetInt(PlayerPrefsKey.avatarSlotNumber);
	}
	public static void SetLevelStar(int level, int star)
	{
		int value = GetLevelStar (level);
		if (star > value)
		{
			if (level == 1) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level1Star, star);
			} else if (level == 2) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level2Star, star);
			} else if (level == 3) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level3Star, star);
			} else if (level == 4) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level4Star, star);
			} else if (level == 5) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level5Star, star);
			}
			PlayerPrefs.Save ();
		}
	}

	public static void SetLevelHighScore(int level, int score)
	{
		PlayerPrefs.SetInt (PlayerPrefsKey.LevelScore, score);

		int value = GetLevelHighScore (level);
		if (score > value) {
			if (level == 1) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level1HighScore, score);
			} else if (level == 2) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level2HighScore, score);
			} else if (level == 3) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level3HighScore, score);
			} else if (level == 4) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level4HighScore, score);
			} else if (level == 5) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level5HighScore, score);
			}
		}
		PlayerPrefs.Save ();

	}

	public static void SetLevelHighMonster(int level, int monster)
	{
		PlayerPrefs.SetInt (PlayerPrefsKey.LevelMonster, monster);

		int value = GetLevelMonster (level);
		if (monster > value) {
			if (level == 1) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level1HighMonster, monster);
			} else if (level == 2) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level2HighMonster, monster);
			} else if (level == 3) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level3HighMonster, monster);
			} else if (level == 4) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level4HighMonster, monster);
			} else if (level == 5) {
				PlayerPrefs.SetInt (PlayerPrefsKey.level5HighMonster, monster);
			}
		}
		PlayerPrefs.Save ();

	}

	public static void SetMonstersCreated(int monstersCreated)
	{
		PlayerPrefs.SetInt (PlayerPrefsKey.MonstersCreated, monstersCreated);
	}

	public static int GetCurrentLevelPoint()
	{
		return PlayerPrefs.GetInt (PlayerPrefsKey.LevelScore);
	}

	public static int GetMonstersCreated()
	{
		return PlayerPrefs.GetInt (PlayerPrefsKey.MonstersCreated);
	}

	public static int GetCurrentLevelMonster()
	{
		return PlayerPrefs.GetInt (PlayerPrefsKey.LevelMonster);
	}

	public static int GetGlobalHighScoreFromLevel(int level)
	{
		int[] results;
		results = GetHighScoreList (level);

		return results[0];
	}

	public static bool AmIinTheTop10List(int level, int mypoint)
	{
		int[] results;
		results = GetHighScoreList (level);
		return mypoint > results[9];
	}

	public static int[] GetHighScoreList(int level)
	{
		string key = PlayerPrefsKey.Level1HighScoreList;
		if (level == 2) {
			key = PlayerPrefsKey.Level1HighScoreList;
		} else if (level == 1) {
			key = PlayerPrefsKey.Level2HighScoreList;
		} else if (level == 3) {
			key = PlayerPrefsKey.Level3HighScoreList;
		} else if (level == 4) {
			key = PlayerPrefsKey.Level4HighScoreList;
		} else if (level == 5) {
			key = PlayerPrefsKey.Level5HighScoreList;
		}
		return PlayerPrefsX.GetIntArray (key);
	}

	public static string[] GetHighScoreNameList(int level)
	{
		string key = PlayerPrefsKey.Level1NameList;
		if (level == 1) {
			key = PlayerPrefsKey.Level1NameList;
		} else if (level == 2) {
			key = PlayerPrefsKey.Level2NameList;
		} else if (level == 3) {
			key = PlayerPrefsKey.Level3NameList;
		} else if (level == 4) {
			key = PlayerPrefsKey.Level4NameList;
		} else if (level == 5) {
			key = PlayerPrefsKey.Level5NameList;
		}
		return PlayerPrefsX.GetStringArray(key);
	}

	public static void UpdateHighScoreNameList (int level, int spot, string Name)
	{
		string[] results;
		string[] newArray = new string[] {"","","","","","","","","",""};
		string key = PlayerPrefsKey.Level1NameList;
		if (level == 1) {
			key = PlayerPrefsKey.Level1NameList;
		} else if (level == 2) {
			key = PlayerPrefsKey.Level2NameList;
		} else if (level == 3) {
			key = PlayerPrefsKey.Level3NameList;
		} else if (level == 4) {
			key = PlayerPrefsKey.Level4NameList;
		} else if (level == 5) {
			key = PlayerPrefsKey.Level5NameList;
		}

		results = PlayerPrefsX.GetStringArray(key);

		for (int i = 0; i < results.Length; i++) {
			newArray[i] = results[i];
		}
		newArray [spot] = Name;

		for (int i = spot+1; i < results.Length; i++) {
			newArray [i] = results [i - 1];
		}

		PlayerPrefsX.SetStringArray(key, newArray);
		PlayerPrefs.Save();	
	}
		
	public static int ChangeHighScoreList(int level, int point)
	{
		int[] results;
		int[] newArray = new int[] {10,9,8,7,6,5,4,3,2,1};

		string key = PlayerPrefsKey.Level1HighScoreList;
		if (level == 2) {
			key = PlayerPrefsKey.Level1HighScoreList;
		} else if (level == 1) {
			key = PlayerPrefsKey.Level2HighScoreList;
		} else if (level == 3) {
			key = PlayerPrefsKey.Level3HighScoreList;
		} else if (level == 4) {
			key = PlayerPrefsKey.Level4HighScoreList;
		} else if (level == 5) {
			key = PlayerPrefsKey.Level5HighScoreList;
		}
		results =  PlayerPrefsX.GetIntArray (key);


		int spot = -1;
		for (int i = 0; i < results.Length; i++) {
			int value = results [i];
			Debug.Log ("value : " + value + " : " + i);

			if (point > value) {
				spot = i+1;
				newArray [i] = point;
				break;
			}
			newArray [i] = value;
		}

		if (spot > -1) 
		{
			for (int i = spot; i < results.Length; i++) {
				newArray [i] = results [i - 1];


			}

			PlayerPrefsX.SetIntArray (key, newArray);
			PlayerPrefs.Save();			
		}

		return spot - 1;
	}

	public void SignOut()
	{
		PlayerPrefs.SetInt ("HasRegistred", 0);
		PlayerPrefs.Save ();
	}
}
