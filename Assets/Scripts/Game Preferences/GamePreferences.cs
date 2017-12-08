using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{

	private static string EasyDifficulty = "EasyDifficulty";
	private static string MediumDifficulty = "MediumDifficulty";
	private static string HardDifficulty = "HardDifficulty";

	private static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	private static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
	private static string HardDifficultyHighScore = "HardDifficultyHighScore";

	private static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	private static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
	private static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

	private static string IsMusicOn = "IsMusicOn";

	private static string IsGameInit = "IsGameInit";

	public static void SetEasyDifficultyState (int state)
	{
		PlayerPrefs.SetInt (EasyDifficulty, state);
	}

	public static int GetEasyDifficultyState ()
	{
		return PlayerPrefs.GetInt (EasyDifficulty);
	}

	public static void SetMediumDifficultyState (int state)
	{
		PlayerPrefs.SetInt (MediumDifficulty, state);
	}

	public static int GetMediumDifficultyState ()
	{
		return PlayerPrefs.GetInt (MediumDifficulty);
	}

	public static void SetHardDifficultyState (int state)
	{
		PlayerPrefs.SetInt (HardDifficulty, state);
	}

	public static int GetHardDifficultyState ()
	{
		return PlayerPrefs.GetInt (HardDifficulty);
	}

	public static void SetEasyDifficultyHighScore (int highScore)
	{
		PlayerPrefs.SetInt (EasyDifficultyHighScore, highScore);
	}

	public static int GetEasyDifficultyHighScore ()
	{
		return PlayerPrefs.GetInt (EasyDifficultyHighScore);
	}

	public static void SetMediumDifficultyHighScore (int highScore)
	{
		PlayerPrefs.SetInt (MediumDifficultyHighScore, highScore);
	}

	public static int GetMediumDifficultyHighScore ()
	{
		return PlayerPrefs.GetInt (MediumDifficultyHighScore);
	}

	public static void SetHardDifficultyHighScore (int highScore)
	{
		PlayerPrefs.SetInt (HardDifficultyHighScore, highScore);
	}

	public static int GetHardDifficultyHighScore ()
	{
		return PlayerPrefs.GetInt (HardDifficultyHighScore);
	}

	public static void SetEasyDifficultyCoinScore (int highScore)
	{
		PlayerPrefs.SetInt (EasyDifficultyCoinScore, highScore);
	}

	public static int GetEasyDifficultyCoinScore ()
	{
		return PlayerPrefs.GetInt (EasyDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScore (int highScore)
	{
		PlayerPrefs.SetInt (MediumDifficultyCoinScore, highScore);
	}

	public static int GetMediumDifficultyCoinScore ()
	{
		return PlayerPrefs.GetInt (MediumDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScore (int highScore)
	{
		PlayerPrefs.SetInt (HardDifficultyCoinScore, highScore);
	}

	public static int GetHardDifficultyCoinScore ()
	{
		return PlayerPrefs.GetInt (HardDifficultyCoinScore);
	}

	public static void SetMusicState (int state)
	{
		PlayerPrefs.SetInt (IsMusicOn, state);
	}

	public static int GetMusicState ()
	{
		return PlayerPrefs.GetInt (IsMusicOn);
	}

	public static bool IsGameInited(){
		return PlayerPrefs.HasKey (IsGameInit);
	}

	public static void SetGameInit(){
		PlayerPrefs.SetInt (IsGameInit, 1);
	}
}
