using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Notifications.Android;
using UnityEngine.SceneManagement;


public class MeditationCircle : MonoBehaviour
{

    [SerializeField] TMPro.TMP_Dropdown TMPdrop;
    [SerializeField] TMPro.TMP_Text MeditationQuote;

    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f, angularSpeed = 2f, angle = 90f;

    [SerializeField]
    TMPro.TMP_Text Minutes;

    [SerializeField]
    GameObject FinishPanel;

    private bool play = false;
    private int CoinAmount;
    private bool popup = true;
    private float temptime;

    private int once = 0;
    private int identifier;

    [SerializeField] float timer = 20;
    float posX, posY;
    // Start is called before the first frame update
    void Start()
    {
        CoinAmount = PlayerPrefs.GetInt("CoinKey");
        StartCountdown();


        var c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
        switch (TMPdrop.value)
        {
            case 0:
                timer = 180;
                break;

            case 1:
                timer = 360;
                break;

            case 2:
                timer = 540;
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        var notification = new AndroidNotification();
        notification.Title = "Meditation";
        notification.Text = "You and " + PlayerPrefs.GetString("NameKey") + " finished your meditation congrats!";


        //var identifier = 1;
        if (play == true && timer >= 0)
        {
            posX = rotationCenter.position.x + Mathf.Sin(angle) * rotationRadius;
            posY = rotationCenter.position.y + Mathf.Cos(angle) * rotationRadius;
            transform.position = new Vector2(posX, posY);
            angle = angle + Time.deltaTime * angularSpeed;

            if (angle >= 360f)
                angle = 0f;
            //
          if(timer == 10 || timer == temptime)
            {
                notification.FireTime = System.DateTime.Now.AddSeconds(timer);

                identifier = AndroidNotificationCenter.SendNotification(notification, "channel_id");
                
            }
           
            //
            UpdateTimer();
        }
        else if(play == false)
        {
            AndroidNotificationCenter.CancelNotification(identifier);
           // AndroidNotificationCenter.UpdateScheduledNotification(identifier = )
        }
        else
        {
            Minutes.text = "00:00:000";
            
            //once += 1;
            if (once == 0)
            {
                int RandomQuote = Random.Range(1, 7);

                switch (RandomQuote)
                {
                    case 1:
                        MeditationQuote.text = "The present moment is filled with happiness. If you are attentive you will see it. - Thich Nhat Hanh";
                        break;
                    case 2:
                        MeditationQuote.text = "Success is not final, failure is not fatal: it is the courage to continue that counts. - Winston Churchill";
                        break;
                    case 3:
                        MeditationQuote.text = "What you get by achieving your goals is not as important as what you become by achieving your goals. - Zig Ziglar";
                        break;
                    case 4:
                        MeditationQuote.text = "I cant change the direction of the wind, but i can adjust my sails to always reach my destination. - Jimmy Dean";
                        break;
                    case 5:
                        MeditationQuote.text = "Life is like riding a bicycle. To keep your balance, you must keep moving. - Albert Einstein";
                        break;
                    case 6:
                        MeditationQuote.text = "You are never too old to set another goal or to dream a new dream. - C.S.Lewis";
                        break;
                    case 7:
                        MeditationQuote.text = "";
                        break;
                    case 8:
                        MeditationQuote.text = "";
                        break;
                    case 9:
                        MeditationQuote.text = "";
                        break;
                    case 10:
                        MeditationQuote.text = "";
                        break;
                }

                once += 1;
            }
            

            FinishPanel.SetActive(popup);
         
        }
        

        
       
    }

    void StartCountdown()
    {
     
    }

    void UpdateTimer()
    {
        if(Minutes != null)
        {
            timer -= Time.deltaTime;
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");
            string fraction = ((timer * 100) % 100).ToString("000");
            Minutes.text = "" + minutes + ":" + seconds + ":" + fraction;
        }
    }

    public void Play()
    {
      
       

        play = true;
        if(timer<=0)
        {
            timer = 10;
            popup = true;

           
        }
    }

    public void Pause()
    {
        play = false;
        temptime = timer;
    }

    public void HidePopUp()
    {
        CoinAmount = CoinAmount + 10;
        PlayerPrefs.SetInt("CoinKey", CoinAmount);
        angle = 0f;
        popup = false;
    }

    public void LoadMenu()
    {
        AndroidNotificationCenter.CancelNotification(identifier);
        SceneManager.LoadScene(1);
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CoinKey", CoinAmount);
    }
}
