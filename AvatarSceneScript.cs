using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AvatarSceneScript : MonoBehaviour {


	public GameObject AvatarImageButton1;
	public GameObject AvatarImageButton2;
	public GameObject AvatarImageButton3;
	public GameObject AvatarImageButton4;
	public GameObject AvatarImageButton5;
	public GameObject AvatarImageButton6;

	public GameObject AvatarButton1;
	public GameObject AvatarButton2;
	public GameObject AvatarButton3;
	public GameObject AvatarButton4;
	public GameObject AvatarButton5;
	public GameObject AvatarButton6;

	public GameObject BoyButton;
	public GameObject GirlButton;

	List<GameObject> buttons;

	private bool isBoy;
	private string avatarName;



	// Use this for initialization
	void Start ()
	{
		buttons = new List<GameObject>();

		buttons.Add(AvatarButton1);
		buttons.Add(AvatarButton2);
		buttons.Add(AvatarButton3);
		buttons.Add(AvatarButton4);
		buttons.Add(AvatarButton5);
		buttons.Add(AvatarButton6);

		if (PlayerPrefsKey.CheckIfBoyAvatar ()) 
		{
			BoyButtonAction ();
		} 
		else
		{
			GirlButtonAction ();
		}

		for(int i = 0; i < 5; i++)
		{
			if(PlayerPrefsKey.GetAvatarSlotNumber() == 0)
			{
				ChangeButtonState(AvatarButton1);
			}
			else if(PlayerPrefsKey.GetAvatarSlotNumber() == 1)
			{
				ChangeButtonState(AvatarButton2);
			}
			else if(PlayerPrefsKey.GetAvatarSlotNumber() == 2)
			{
				ChangeButtonState(AvatarButton3);
			}
			else if(PlayerPrefsKey.GetAvatarSlotNumber() == 3)
			{
				ChangeButtonState(AvatarButton4);
			}
			else if(PlayerPrefsKey.GetAvatarSlotNumber() == 4)
			{
				ChangeButtonState(AvatarButton5);
			}
			else if(PlayerPrefsKey.GetAvatarSlotNumber() == 5)
			{
				ChangeButtonState(AvatarButton6);
			}
		}

		//TODO: 
		isBoy = true;

		avatarName = PlayerPrefsKey.GetUserAvatar();


		if (avatarName.Length < 5) 
		avatarName = PlayerPrefsKey.GetUserAvatar ();

		if (avatarName.Length > 5) 
		{
			avatarName = PlayerPrefsKey.GetUserAvatar ();
		}
		else
		{
			avatarName = "assets_avatar-boy-1";
		}		


	}

	// Update is called once per frame
	void Update () {

	}

	public void BoyButtonAction()
	{
		BoyButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_check-large");
		GirlButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_check-large-empty");
		isBoy = true;
		PlayerPrefsKey.SetAvatarBoy (true);
		ChangeAvatarImage ();

	}

	public void GirlButtonAction()
	{
		BoyButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_check-large-empty");
		GirlButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_check-large");
		isBoy = false;
		PlayerPrefsKey.SetAvatarBoy (false);
		ChangeAvatarImage ();

	}

	public void AvatarButton1Action()
	{
		ChangeButtonState (AvatarButton1);
		avatarName = AvatarImageButton1.GetComponent<Image>().sprite.name;
		PlayerPrefsKey.SetAvatarSlotNumber (0);
	}

	public void AvatarButton2Action()
	{
		ChangeButtonState (AvatarButton2);
		avatarName = AvatarImageButton2.GetComponent<Image>().sprite.name;
		PlayerPrefsKey.SetAvatarSlotNumber (1);
	}

	public void AvatarButton3Action()
	{
		ChangeButtonState (AvatarButton3);
		avatarName = AvatarImageButton3.GetComponent<Image>().sprite.name;
		PlayerPrefsKey.SetAvatarSlotNumber (2);
	}
	public void AvatarButton4Action()
	{
		ChangeButtonState (AvatarButton4);
		avatarName = AvatarImageButton4.GetComponent<Image>().sprite.name;
		PlayerPrefsKey.SetAvatarSlotNumber (3);
	}
	public void AvatarButton5Action()
	{
		ChangeButtonState (AvatarButton5);
		avatarName = AvatarImageButton5.GetComponent<Image>().sprite.name;
		PlayerPrefsKey.SetAvatarSlotNumber (4);
	}
	public void AvatarButton6Action()
	{
		ChangeButtonState (AvatarButton6);
		avatarName = AvatarImageButton6.GetComponent<Image>().sprite.name;
		PlayerPrefsKey.SetAvatarSlotNumber (5);
	}



	void ChangeButtonState(GameObject button)
	{
		foreach (GameObject btn in buttons) {
			btn.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_check-large-empty");
		}
		button.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_check-large");

	}

	void ChangeAvatarImage()
	{
		if (isBoy)
		{
			AvatarImageButton1.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-boy-1");
			AvatarImageButton2.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-boy-2");
			AvatarImageButton3.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-boy-3");
			AvatarImageButton4.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-boy-4");
			AvatarImageButton5.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-boy-5");
			AvatarImageButton6.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-boy-6");

		} 
		else 
		{
			AvatarImageButton1.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-girl-1");
			AvatarImageButton2.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-girl-2");
			AvatarImageButton3.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-girl-3");
			AvatarImageButton4.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-girl-4");
			AvatarImageButton5.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-girl-5");
			AvatarImageButton6.GetComponent<Image>().sprite = Resources.Load<Sprite>("ui/assets_avatar-girl-6");
		}
	}

	public void FinishAction(bool isFromAvatarScene)
	{
		if (isBoy) {
			avatarName = avatarName.Replace ("girl", "boy");
			PlayerPrefsKey.SetAvatarBoy (true);
		} else {
			avatarName = avatarName.Replace ("boy", "girl");
			PlayerPrefsKey.SetAvatarBoy (false);
		}
		PlayerPrefsKey.SetUserAvatar (avatarName);


        if (isFromAvatarScene)
        {
            SceneManager.LoadScene(SceneTracker.GetChosenLevel());
        }
	}

	public void GoBackAction()
	{
        SceneManager.LoadScene(SceneTracker.sceneName);
	}
}