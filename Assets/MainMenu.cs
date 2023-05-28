using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Toggle toggle;
    public GameObject optionsmenu;
    public GameObject credits;
    public GameObject howto;
    public AudioSource Static;
    // Start is called before the first frame update
    void Start()
    {
        optionsmenu.gameObject.SetActive(false);
        howto.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        Static.Play();
        if (AudioListener.volume == 1)
        {
            toggle.isOn= true;
        }
        else
        {
            toggle.isOn = false;
        }
        
         

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void start()
    {
        Static.Stop();
        SceneManager.LoadScene("SampleScene");

    }
    public void MuteAllSound()
    {
        if (toggle.isOn)
        {
            AudioListener.volume = 1;
        }
        else
        {

            AudioListener.volume = 0;
        }
    }

    
    public void quitTheApp()
    {
        Application.Quit();
    }
    public void openoptionsview()
    {
        optionsmenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void goback()
    {
        optionsmenu.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
    public void creditsview()
    {
        optionsmenu.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }
    public void howtoview()
    {
        optionsmenu.gameObject.SetActive(false);
        howto.gameObject.SetActive(true);
    }
    public void gobackfromcredits()
    {
        credits.gameObject.SetActive(false);
        optionsmenu.gameObject.SetActive(true);
    }
    public void gobackfromhowto()
    {
        howto.gameObject.SetActive(false);
        optionsmenu.gameObject.SetActive(true);
    }
}