using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paused : MonoBehaviour
{
    public AudioSource Static;
    public moving_the_player mainclass;
    public GameObject playingbuttons;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Togglepaused()
    {
        Static.Play();
        gameObject.SetActive(true);
        playingbuttons.SetActive(false);

 
    }
    public void Restart()
    {
        Static.Stop();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void resume()
    {
        mainclass.playingSound.Play();
        gameObject.SetActive(false);
        playingbuttons.SetActive(true);
        Static.Stop();
        Time.timeScale = 1;

    }
}



 
   

