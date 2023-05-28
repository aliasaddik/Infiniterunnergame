using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement ;

public class death_menu : MonoBehaviour
{
    public TMP_Text textscore;
    public AudioSource Static;
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
    public void ToggleEndMenu(int score)
    {
        Static.Play();
        playingbuttons.SetActive(false);
        gameObject.SetActive(true);


        textscore.text +=score;
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
}
