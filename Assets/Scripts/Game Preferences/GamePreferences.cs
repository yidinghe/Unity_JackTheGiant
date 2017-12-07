﻿using System.Collections;
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

	public static void SetEasyDifficultyState (int state)
	{
		PlayerPrefs.SetInt (EasyDifficulty, state);
	}

	public static int getEasyDifficultyState ()
	{
		return PlayerPrefs.GetInt (EasyDifficulty);
	}

	public static void SetMediumDifficultyState (int state)
	{
		PlayerPrefs.SetInt (MediumDifficulty, state);
	}

	public static int getMediumDifficultyState ()
	{
		return PlayerPrefs.GetInt (MediumDifficulty);
	}

	public static void SetHardDifficultyState (int state)
	{
		PlayerPrefs.SetInt (HardDifficulty, state);
	}

	public static int getHardDifficultyState ()
	{
		return PlayerPrefs.GetInt (HardDifficulty);
	}

	public static void SetEasyDifficultyHighScore (int highScore)
	{
		PlayerPrefs.SetInt (EasyDifficultyHighScore, highScore);
	}

	public static int getEasyDifficultyHighScore ()
	{
		return PlayerPrefs.GetInt (EasyDifficultyHighScore);
	}

	public static void SetMediumDifficultyHighScore (int highScore)
	{
		PlayerPrefs.SetInt (MediumDifficultyHighScore, highScore);
	}

	public static int getMediumDifficultyHighScore ()
	{
		return PlayerPrefs.GetInt (MediumDifficultyHighScore);
	}

	public static void SetHardDifficultyHighScore (int highScore)
	{
		PlayerPrefs.SetInt (HardDifficultyHighScore, highScore);
	}

	public static int getHardDifficultyHighScore ()
	{
		return PlayerPrefs.GetInt (HardDifficultyHighScore);
	}

	public static void SetEasyDifficultyCoinScore (int highScore)
	{
		PlayerPrefs.SetInt (EasyDifficultyCoinScore, highScore);
	}

	public static int getEasyDifficultyCoinScore ()
	{
		return PlayerPrefs.GetInt (EasyDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScore (int highScore)
	{
		PlayerPrefs.SetInt (MediumDifficultyCoinScore, highScore);
	}

	public static int getMediumDifficultyCoinScore ()
	{
		return PlayerPrefs.GetInt (MediumDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScore (int highScore)
	{
		PlayerPrefs.SetInt (HardDifficultyCoinScore, highScore);
	}

	public static int getHardDifficultyCoinScore ()
	{
		return PlayerPrefs.GetInt (HardDifficultyCoinScore);
	}

	public static void SetMusicState (int state)
	{
		PlayerPrefs.SetInt (IsMusicOn, state);
	}

	public static int getMusicState ()
	{
		return PlayerPrefs.GetInt (IsMusicOn);
	}
}
