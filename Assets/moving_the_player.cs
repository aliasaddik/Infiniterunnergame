using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moving_the_player : MonoBehaviour
{
    public float speed;
    int abilityPTS;
    int healthPTS;
    int currscore;
    public GameObject plane;
    public GameObject abilityOrb;
    public GameObject healthOrb;
    public GameObject oneLane;
    public GameObject twoLane;
    public GameObject threeLane;
    public AudioSource playingSound;
    public AudioSource hitSound;
    public AudioSource winsound;
    public death_menu deathMenu;
    public paused paused;
    float timer;
    float timer2;

 
    bool cannotjump = false;
    GameObject pastplane;
    GameObject[] pasthealth;
    GameObject[] pastability;
    GameObject[] pastobs1;
    GameObject[] pastobs2;
    GameObject[] pastobs3;
    Vector3 positionPlayer;
    Vector3 pos;
    Vector3 pos2;
    Vector3 pos3;
    float prevXPos;
    public TMP_Text health;
    public TMP_Text score ;
    public TMP_Text ability;
    public AudioSource Static;
    int rightbutton;
    int leftbutton;


    // Start is called before the first frame update
    void Start()
    {
        rightbutton = 0;
        leftbutton = 0;
        Static.Stop();
        Time.timeScale = 1;
        currscore = 0;
        playingSound.Play();
        timer2 = 100;
        abilityPTS = 10;
        healthPTS = 5;
        positionPlayer = this.gameObject.transform.position;
         
       
        Createobsandpwr(positionPlayer.x);
        
       
    }
    // Update is called once per frame
    void Update()

    {

        if (Input.GetKeyDown(KeyCode.Escape)&& healthPTS>0)
        {
            playingSound.Pause();
            Time.timeScale = 0;
            paused.Togglepaused();

        }
        positionPlayer = this.gameObject.transform.position;
        
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
        
        if(abilityPTS>=5&& Input.GetKeyDown(KeyCode.Q)&& Time.timeScale==1)
        {
            abilityPTS -= 5;
            pastobs1 = GameObject.FindGameObjectsWithTag("obstacle1");
            
            
                foreach (GameObject ob in pastobs1)
                {


                    Destroy(ob);

                }
            pastobs3 = GameObject.FindGameObjectsWithTag("obstacle3");

           
            
                foreach (GameObject ob in pastobs3)
                {


                    Destroy(ob);
                 }

            pastobs2 = GameObject.FindGameObjectsWithTag("obstacle2");
            
                foreach (GameObject ob in pastobs2)
                {


                    Destroy(ob);

                }
 




        }
        
        if (positionPlayer.z > -4 && (Input.GetAxis("Horizontal")>0|| rightbutton==1))
        {
            transform.Translate(new Vector3(0, 0,  -speed*Time.deltaTime));
            

             
        }
        if (positionPlayer.z < 4 && (Input.GetAxisRaw("Horizontal") < 0||leftbutton==1))
        {
            transform.Translate(new Vector3(0, 0,speed*Time.deltaTime));
             


        }
        
        if (Input.GetKeyDown(KeyCode.Space)&& abilityPTS>0&& !cannotjump&& Time.timeScale==1)
        {
           

            transform.Translate(new Vector3(0, 3f, 0));
            abilityPTS -= 1;
            cannotjump = true;
            
            ability.text = "Ability Points: " + abilityPTS;

        }
        

        if (timer < 0)
        {
            
            Vector3 pos = new Vector3(positionPlayer.x+100, 0, 0);
            Instantiate(plane, pos, plane.transform.rotation);
           
            timer = 5;
        }

        if (timer2 < 0)
        {
            timer2 = 100;
            Createobsandpwr(prevXPos);
          
        }

        
        pastplane = GameObject.FindGameObjectsWithTag("playingplane")[0] ;
        if (pastplane.transform.position.x < positionPlayer.x-100)
        {
            Destroy(pastplane);
        }

        pastobs1 = GameObject.FindGameObjectsWithTag("obstacle1");
        
        foreach (GameObject ob in pastobs1) {
           
            if (ob.transform.position.x < positionPlayer.x-10 )
            {
                Destroy(ob);
            }
        }
       
        pastobs2 = GameObject.FindGameObjectsWithTag("obstacle2");
        
        foreach (GameObject ob in pastobs2)
        {
            
            if (ob.transform.position.x < positionPlayer.x-10 )
            {
                Destroy(ob);
            }
        }

        pastobs3 = GameObject.FindGameObjectsWithTag("obstacle3");
        
        foreach (GameObject ob in pastobs3)
        {
            
            if (ob.transform.position.x < positionPlayer.x-10)
            {
                Destroy(ob);
            }
        }

        pasthealth = GameObject.FindGameObjectsWithTag("healthorb");
        foreach (GameObject ob in pasthealth)
        {
          
            if (ob.transform.position.x < positionPlayer.x-10)
            {
                Destroy(ob);
            }
        }

        pastability = GameObject.FindGameObjectsWithTag("abilityorb");
        foreach (GameObject ob in pastability)
        {
           
            if (ob.transform.position.x < positionPlayer.x-10)
            {
                Destroy(ob);
            }
        }
    }
   
    private static float[] gettwo()
    {
        float first = Random.Range(-5, 5);
        float second = Random.Range(-5, 5);
      
        while (second > first - 1 && second < first + 1)
        {
            second = Random.Range(-5, 5);
        }
         
        return new float[] { first, second };

    }
    private static float[] getthree()
        {
        float first = Random.Range(-4, 4);
        float second = Random.Range(-4, 4);
        float third = Random.Range(-4, 4);
         while ( second>first-1.5 && second < first + 1.5)
        {
            second= Random.Range(-4, 4);
        }
        while ( ( third > first - 1.5 && third< first + 1.5)||(third > second- 1.5 && third < second + 1.5))
        {
            third = Random.Range(-4, 4);
        }
        return new float[] { first, second, third };

    }
    private void OnCollisionEnter(Collision collision)
    //this.gameobject dah el object elly 3aleeh el script
    {

        if (collision.gameObject.CompareTag("playingplane"))
        {

            cannotjump = false;
        }
        if (collision.gameObject.CompareTag("obstacle1"))
        {
            hitSound.Play();
            Destroy(collision.gameObject);
           
           healthPTS-=1 ;
            if (healthPTS < 1)
            {
                deathMenu.ToggleEndMenu(currscore);
                Time.timeScale = 0;
                playingSound.Stop();
            }
            health.text = "Health Points: " + healthPTS;
        }
        if (collision.gameObject.CompareTag("obstacle2"))
        {
            hitSound.Play();
            Destroy(collision.gameObject);

            healthPTS -= 2;
            if (healthPTS < 1)
            {
                deathMenu.ToggleEndMenu(currscore);
                Time.timeScale = 0;
                playingSound.Stop();
            }
            health.text = "Health Points: " + healthPTS;

        }
        if (collision.gameObject.CompareTag("obstacle3"))
        {
            hitSound.Play();
            Destroy(collision.gameObject);

            healthPTS -= 3;
            if (healthPTS < 1)
            {
                deathMenu.ToggleEndMenu(currscore);
                Time.timeScale = 0;
                playingSound.Stop();
            }
            health.text = "Health Points: " + healthPTS;
        }
        if (collision.gameObject.CompareTag("healthorb"))

        {
            winsound.Play();
            Destroy(collision.gameObject);

            if (healthPTS < 5) {

                healthPTS += 1;
                health.text = "Health Points: " + healthPTS; }
        }
        if (collision.gameObject.CompareTag("abilityorb"))
        {
            winsound.Play();
            Destroy(collision.gameObject);
            if (abilityPTS < 10)
            {

                abilityPTS += 1;
                ability.text = "Ability Points: " + abilityPTS;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle1"))
        {

            
            
            currscore+=1;
            score.text = "Score: " + currscore;
        }
        if (other.gameObject.CompareTag("obstacle2"))
        {



            currscore += 2;
            score.text = "Score: " + currscore;
        }
        if (other.gameObject.CompareTag("obstacle3"))
        {



            currscore += 3;
            score.text = "Score: " + currscore;
        }
    }
    private  void Createobsandpwr(float startingx)
    {
        prevXPos = startingx;
        for (int i = 0; i < 100; i++)
        {
            float currXPos = Random.Range(3, 10) + prevXPos;
            int option = Random.Range(0, 2);
            switch (option)
            {
                case 0:
                    int orboption = Random.Range(0, 9);


                    switch (orboption) {

                        case 0:
                            pos = new Vector3(currXPos, 0.46f, Random.Range(-4, 4));
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            break;
                        case 1:
                            pos = new Vector3(currXPos, 0.46f, Random.Range(-4, 4));
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            break;

                        case 2:

                            pos = new Vector3(currXPos, 0.46f, gettwo()[0]);
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, gettwo()[1]);
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            break;
                        case 3:

                            pos = new Vector3(currXPos, 0.46f, gettwo()[0]);
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, gettwo()[1]);
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            break;
                        case 4:
                            pos = new Vector3(currXPos, 0.46f, Random.Range(-5, 0));
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, Random.Range(0, 5));
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);

                            break;
                        case 5:
                            pos = new Vector3(currXPos, 0.46f, getthree()[0]);
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, getthree()[1]);
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, getthree()[2]);
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            break;
                        case 6:
                            pos = new Vector3(currXPos, 0.46f, getthree()[0]);
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, getthree()[1]);
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, getthree()[2]);
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            break;

                        case 7:
                            pos = new Vector3(currXPos, 0.46f, getthree()[0]);
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, getthree()[1]);
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, getthree()[2]);
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            break;

                        case 8:
                            pos = new Vector3(currXPos, 0.46f, getthree()[0]);
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, getthree()[1]);
                            Instantiate(abilityOrb, pos, abilityOrb.transform.rotation);
                            pos = new Vector3(currXPos, 0.46f, getthree()[2]);
                            Instantiate(healthOrb, pos, healthOrb.transform.rotation);
                            break; }


                    break;

                case 1:
                    int obsoption = Random.Range(0, 6);
                    switch (obsoption) {
                     case 0:
                    pos = new Vector3(currXPos, 0.53f, 3.3f);
                    Instantiate(oneLane, pos, oneLane.transform.rotation);
                    break;
                     case 1:
                    pos = new Vector3(currXPos, 0.53f, -3.3f);
                    Instantiate(oneLane, pos, oneLane.transform.rotation);
                    break;
                case 2:
                      pos = new Vector3(currXPos, 0.53f, 0);
                    Instantiate(oneLane, pos, oneLane.transform.rotation);
                    break;
                case 3:
                    pos = new Vector3(currXPos, 0.53f, 1.68f);
                    Instantiate(twoLane, pos, twoLane.transform.rotation);
                    break;
                case 4:
                    pos = new Vector3(currXPos, 0.53f, -1.68f);
                    Instantiate(twoLane, pos, twoLane.transform.rotation);
                    break;
                case 5:
                    pos = new Vector3(currXPos, 0.53f, 0);
                    Instantiate(threeLane, pos, threeLane.transform.rotation);
                    break; }
            break;


                

            }
            prevXPos = currXPos;

        }
      
    }


    public void onclickspecial()
    {
        if (abilityPTS >= 5  && Time.timeScale == 1)
        {
            abilityPTS -= 5;
            pastobs1 = GameObject.FindGameObjectsWithTag("obstacle1");


            foreach (GameObject ob in pastobs1)
            {


                Destroy(ob);

            }
            pastobs3 = GameObject.FindGameObjectsWithTag("obstacle3");



            foreach (GameObject ob in pastobs3)
            {


                Destroy(ob);
            }

            pastobs2 = GameObject.FindGameObjectsWithTag("obstacle2");

            foreach (GameObject ob in pastobs2)
            {


                Destroy(ob);

            }





        }

    }
    public void onclickup()
    {
        if (abilityPTS > 0 && !cannotjump && Time.timeScale == 1)
        {


            transform.Translate(new Vector3(0, 3f, 0));
            abilityPTS -= 1;
            cannotjump = true;

            ability.text = "Ability Points: " + abilityPTS;

        }
    }

    public void  onclickpause()
    {
        playingSound.Pause();
        Time.timeScale = 0;
        paused.Togglepaused();
    }

    public void clickedright()
    {
        rightbutton = 1;
    }
    public void clickedleft ()
    {
        leftbutton = 1;
    }
    public void unclickedleft()
    {
        leftbutton = 0;
    }
    public void unclickedright()
    {
        rightbutton = 0;
    }

}
