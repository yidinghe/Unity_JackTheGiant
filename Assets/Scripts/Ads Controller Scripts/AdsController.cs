using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsController : MonoBehaviour
{

	public static AdsController instance;

	private BannerView bannerView;
	private InterstitialAd interstitial;

	// Use this for initialization
	void Awake ()
	{
		#if UNITY_ANDROID
		string appId = "ca-app-pub-5571888412783286~5037354901";
		#elif UNITY_IPHONE
		string appId = "ca-app-pub-5571888412783286~5037354901";
		#else
		string appId = "unexpected_platform";
		#endif

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize (appId);

		MakeSingleton ();
	}

	void Start ()
	{
		RequestBanner ();
		RequestInterstitial ();
	}

	void MakeSingleton ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	// Returns an ad request with custom ad targeting.
	private AdRequest CreateAdRequest ()
	{
		return new AdRequest.Builder ()
		.AddTestDevice (AdRequest.TestDeviceSimulator)
		.AddTestDevice ("0123456789ABCDEF0123456789ABCDEF")
		.AddKeyword ("game")
		.SetGender (Gender.Male)
		.SetBirthday (new DateTime (1985, 1, 1))
		.TagForChildDirectedTreatment (false)
		.AddExtra ("color_bg", "9B30FF")
		.Build ();
	}

	private void RequestBanner ()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-5571888412783286/1456971030";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-5571888412783286/1456971030";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Clean up banner ad before creating a new one.
		if (this.bannerView != null) {
			this.bannerView.Destroy ();
		}

		// Create a 320x50 banner at the top of the screen.
		this.bannerView = new BannerView (adUnitId, AdSize.SmartBanner, AdPosition.Top);

		RegisterBannerDelegate ();

		// Load a banner ad.
		this.bannerView.LoadAd (this.CreateAdRequest ());
	}

	private void RequestInterstitial ()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-5571888412783286/3921205041";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-5571888412783286/3921205041";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Clean up interstitial ad before creating a new one.
		if (this.interstitial != null) {
			this.interstitial.Destroy ();
		}

		// Create an interstitial.
		this.interstitial = new InterstitialAd (adUnitId);

		RegisterInterstitialDelegate ();

		// Load an interstitial ad.
		this.interstitial.LoadAd (this.CreateAdRequest ());
	}

	public void ShowBanner ()
	{
		bannerView.Show ();
	}

	public void ShowInterstitial ()
	{
		if (interstitial.IsLoaded ()) {
			interstitial.Show ();
		} else if(interstitial == null){
			RequestInterstitial ();
		}
	}

	void RegisterBannerDelegate ()
	{
		// Register for ad events.
		this.bannerView.OnAdLoaded += this.HandleAdLoaded;
		this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
		this.bannerView.OnAdOpening += this.HandleAdOpened;
		this.bannerView.OnAdClosed += this.HandleAdClosed;
		this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

	}

	void UnregisterBannerDelegate ()
	{
		this.bannerView.OnAdLoaded -= this.HandleAdLoaded;
		this.bannerView.OnAdFailedToLoad -= this.HandleAdFailedToLoad;
		this.bannerView.OnAdOpening -= this.HandleAdOpened;
		this.bannerView.OnAdClosed -= this.HandleAdClosed;
		this.bannerView.OnAdLeavingApplication -= this.HandleAdLeftApplication;
	}

	void RegisterInterstitialDelegate ()
	{
		// Register for ad events.
		this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
		this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
		this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
		this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
		this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
	}

	void UnregisterInterstitialDelegate ()
	{
		this.interstitial.OnAdLoaded -= this.HandleInterstitialLoaded;
		this.interstitial.OnAdFailedToLoad -= this.HandleInterstitialFailedToLoad;
		this.interstitial.OnAdOpening -= this.HandleInterstitialOpened;
		this.interstitial.OnAdClosed -= this.HandleInterstitialClosed;
		this.interstitial.OnAdLeavingApplication -= this.HandleInterstitialLeftApplication;
	}


	public void HandleAdLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdLoaded event received");
	}

	public void HandleAdFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		UnregisterBannerDelegate ();
		RequestBanner ();
		MonoBehaviour.print ("HandleFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleAdOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdOpened event received");
	}

	public void HandleAdClosed (object sender, EventArgs args)
	{
		UnregisterBannerDelegate ();
		RequestBanner ();
		MonoBehaviour.print ("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdLeftApplication event received");
	}


	public void HandleInterstitialLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialLoaded event received");
	}

	public void HandleInterstitialFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		UnregisterInterstitialDelegate ();
		RequestInterstitial ();
		MonoBehaviour.print (
			"HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}

	public void HandleInterstitialOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialOpened event received");
	}

	public void HandleInterstitialClosed (object sender, EventArgs args)
	{
		UnregisterInterstitialDelegate ();
		RequestInterstitial ();
		MonoBehaviour.print ("HandleInterstitialClosed event received");
	}

	public void HandleInterstitialLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialLeftApplication event received");
	}

}
