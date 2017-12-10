using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{

	[SerializeField]
	private GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start ()
	{
		SetTheDifficulty ();
	}

	void SetDifficultyUI (string difficulty)
	{
		switch (difficulty) {
		case "easy":
			easySign.SetActive (true);
			mediumSign.SetActive (false);
			hardSign.SetActive (false);
			break;

		case "medium":
			easySign.SetActive (false);
			mediumSign.SetActive (true);
			hardSign.SetActive (false);
			break;

		case "hard":
			easySign.SetActive (false);
			mediumSign.SetActive (false);
			hardSign.SetActive (true);
			break;

		}
	}

	void SetTheDifficulty ()
	{
		
		if (GamePreferences.GetEasyDifficultyState () == 1) {
			SetDifficultyUI ("easy");
		}

		if (GamePreferences.GetMediumDifficultyState () == 1) {
			SetDifficultyUI ("medium");
		}

		if (GamePreferences.GetHardDifficultyState () == 1) {
			SetDifficultyUI ("hard");
		}
	}

	public void EasyDifficulty ()
	{
		GamePreferences.SetEasyDifficultyState (1);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (0);
		SetDifficultyUI ("easy");
	}

	public void MediumDifficulty ()
	{
		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (1);
		GamePreferences.SetHardDifficultyState (0);
		SetDifficultyUI ("medium");
	}

	public void HardDifficulty ()
	{
		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (1);
		SetDifficultyUI ("hard");
	}

	public void GoBackToMainMenu ()
	{
		SceneFader.instance.LoadLevel ("MainMenu");
	}

}
