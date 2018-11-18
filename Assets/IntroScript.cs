using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public Text introTxt;
    private float timer = 4;
    private float interval = 5f;
    private float changeSceneInterval = 37;
    public bool changeText;
    public int count = 0;

    void Start()
    {
        introTxt.text = "I en galakse langt langt væk var metal det fedeste folk nogensinde havde hørt.";
    }


    void Update()

    {
        timeout();
    }

    void timeout()
    {
        if (changeSceneInterval <= 0)
        {

        }

        if (timer <= 0)
        {

            switch (count)
            {
                case 0:
                    introTxt.text = "Men pludselig overtog stærkere magter, og metallen var tæt på at uddø.";
                    break;
                case 1:
                    introTxt.text = "I 2048 blev Thorgunn udnævnt til krigsfører for planeten Demonitan.";
                    break;
                case 2:
                    introTxt.text = "Efter kun 666 dages rumrejse havde Thorgunn overbevist hele universet";
                    break;
                case 3:
                    introTxt.text = "Om at elske det tunge toner og hans lange, lyse rockerhår";
                case 4:
                    introTxt.text = "Broniesne, som hader tunge toner og guitarsoloer havde hørt om Thorgunn og hans mission.";
                    break;
                case 5:
                    introTxt.text = "Da Thorgunn ankom til planeten Ponyter, blev han straks angrebet af en hær af Ponies.";
                    break;
                case 6:
                    introTxt.text = "Thorgunn må nu overtage Ponyter, så universet får heavy metal tilbage!!";
                    break;
            }
            count++;
            timer = interval;

        }
        else
        {

            timer -= Time.deltaTime;
            changeSceneInterval -= Time.deltaTime;
            
        }



    }
}