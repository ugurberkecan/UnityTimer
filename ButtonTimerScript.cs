using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ButtonTimerScript : MonoBehaviour
{
    
    public Button chestButton;
    private ulong lastChestOpen;
    public float msToWait = 14400000;
    public Text chestTimer;
    
    private void Start()
    {
        chestButton = GetComponent<Button>();
        
        lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastButtonOpen"));

        if (!IsChestReady())
        {
            chestButton.interactable = false;
            
        }
    }

    public void Update()
    {
        if (!chestButton.IsInteractable())
        {
            if (IsChestReady())
            {
                chestButton.interactable = true;

                return;
            }
            TimerScript();
        } 
    }

    public void TimerScript()
    {
        ulong diff = ((ulong) DateTime.Now.Ticks - lastChestOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;

        float secondsLeft = (msToWait - m) / 1000;
        
        string r = "";
        //Hours
        r += ((int) secondsLeft / 3600).ToString() + ":";
        secondsLeft -= ((int) secondsLeft / 3600) * 3600;
        //minutes
        r += ((int) secondsLeft / 60).ToString("00") + ":";
        //seconds
        r += (secondsLeft % 60).ToString("00") + "s";

        chestTimer.text = r;
    }
    public void ButtonClick()
    {
        lastChestOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastButtonOpen",lastChestOpen.ToString());
        chestButton.interactable = false;
    }

    private bool IsChestReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        

        float secondsLeft = (msToWait - m) / 1000;

        if (secondsLeft < 0)
        {
            chestTimer.text = "WATCH ADS";
            return true;
        }
        return false;
    }
}
