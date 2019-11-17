using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Notifications.Android;
using UnityEngine.SceneManagement;


public class MeditationCircle : MonoBehaviour
{

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
