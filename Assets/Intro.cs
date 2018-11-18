using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Text introTxt;
    private float timer = 4;
    private float interval = 7f;
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
        if (timer <= 0)
        {

            switch (count)
            {
                case 0:
                    introTxt.text = "Men pludselig overtog stærkere magter, og metallen var tæt på at uddø.";
                    break;
                case 1:
                    introTxt.text = "Thorgunn, søn af Svenn “Headbanger”, blev d. 18 november år 2418 udnævnt til krigsfører for planeten Demonitan.";
                    break;
                case 2:
                    introTxt.text = "Den vigtigste opgave som krigsfører er at sprede budskabet om heavy metal til resten af universet.";
                    break;
                case 3:
                    introTxt.text = "Efter kun 666 dages rumrejse havde Thorgunn overbevist hele universet om at elske det tunge toner og hans lange, lyse rockerhår";
                    break;
                case 4:
                    introTxt.text = "men Kong Bronymand, som hader tunge toner og guitarsoloer havde hørt om Thorgunn og hans mission.";
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

        } else {

            timer -= Time.deltaTime;
        }

    }
        }