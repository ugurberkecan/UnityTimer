﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

public class testreward : MonoBehaviour
{

    private RewardBasedVideoAd rewardBasedVideo;
    

    public Button buttonS;
    public void Start()
    {


        
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.

        this.RequestRewardBasedVideo();

    }

   

    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "";
#elif UNITY_IPHONE
            string adUnitId = "";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void Show()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            Debug.Log("okey work");
        }
        else
        {
            RequestRewardBasedVideo();
            
            Debug.Log("not okey");
        }
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
    

      //  GameObject.FindWithTag("WatchAds").GetComponent<ButtonScript>().ButtonClick();
    }

  
}
