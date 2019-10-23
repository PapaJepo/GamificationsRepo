using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile.Android;
using EasyMobile;
using System;

public class LocalNotification : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Notifications.Init();
    }

    NotificationContent PrepareNotifactionContent()
    {
        NotificationContent content = new NotificationContent();
        content.title = "Test Notification";
        content.subtitle = "Subtitle";
        content.body = "Test Content";

        content.smallIcon = "";
        content.largeIcon = "";

        return content;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   public void ScheduleLocalNotification()
    {
        NotificationContent content = PrepareNotifactionContent();

       // string localtime = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"); ;

        DateTime triggerDate = new DateTime(2019, 10, 23, 11, 0, 0);

        Notifications.ScheduleLocalNotification(triggerDate, content);

        Debug.Log("Notifaction rdy");
    }
}
