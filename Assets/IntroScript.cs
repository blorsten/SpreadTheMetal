using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public Text introTxt;
    private float timer = 4;
    private float interval = 4f;
    private float changeSceneInterval = 37;
    public bool changeText;
    public int count = 0;

    void Start()
    {
        introTxt.text = "I en galakse langt langt vaek var metal det fedeste folk nogensinde havde hoert.";
    }


    void Update()

    {
        timeout();
    }

    void timeout()
    {
        if (changeSceneInterval <= 0)
        {
            SceneManager.LoadScene("InGame");
        }

        if (timer <= 0)
        {

            switch (count)
            {
                case 0:
                    introTxt.text = "Men pludselig overtog staerkere broniesne, og metallen var ved at uddoe.";
                    break;
                case 1:
                    introTxt.text = "I 2048 blev Thorgunn udnaevnt til krigsfoerer for planeten Demonitan.";
                    break;
                case 2:
                    introTxt.text = "Efter kun 666 dages rumrejse havde Thorgunn overbevist hele universet";
                    break;
                case 3:
                    introTxt.text = "Om at elske det tunge toner og hans lange, lyse rockerhår";
                    break;
                case 4:
                    introTxt.text = "Men My Little Ponies havde hørt om Thorgunns mission.";
                    break;
                case 5:
                    introTxt.text = "Han kom med fred men blev angrebet, og nu";
                    break;
                case 6:
                    introTxt.text = "Maa Thorgunn besejre Bronie og Poniesne,";
                    break;
                case 7:
                    introTxt.text = "så universet faar heavy metal TILBAGE!!";
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