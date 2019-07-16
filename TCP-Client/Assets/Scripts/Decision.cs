using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decision : MonoBehaviour
{

    static string planetId;
    static string decision;
    static string description;
    static Text text;
    GameObject buttonYes;
    GameObject buttonNo;
    bool isShow;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
        text = GameObject.Find("notice").GetComponent<Text>();
        
        buttonYes = GameObject.Find("Yes");
        buttonYes = GameObject.Find("No");
    
        text.text = "";

        isShow = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void setPlanetId(string str)
    {
        planetId = str;
    }

    public static void setDescription(string str)
    {
        description = str;
    }

    public static void setDecision()
    {
        text.text =  "PlanetID: "
                    + "\r\n"
                    + planetId
                    + "\r\n"
                    + "Description: "
                    + "\r\n"
                    + description;
        Notify.notify();
        Notification.setNotiDecision();
    }

    public void onYes()
    {
        Notify.cancelNotify();
        gameObject.SetActive(false);
        text.text = "";
        Chat.submitVote("***decision-answer\r\n"
                        + "pId:"
                        + planetId
                        + "\r\n"
                        + "plId:"
                        + Chat.getPlayerID()
                        + "\r\n"
                        + "v:"
                        + "true" );
        isShow = false;
        StopWatch.addTime();
    }

    public void onNo()
    {
        Notify.cancelNotify();
        gameObject.SetActive(false);
        text.text = "";
        Chat.submitVote("***decision-answer\r\n"
                        + "pId:"
                        + planetId
                        + "\r\n"
                        + "plId:"
                        + Chat.getPlayerID()
                        + "\r\n"
                        + "v:"
                        + "false");
        isShow = false;
        StopWatch.addTime();
    }

    public void onShow()
    {
        if (isShow)
        {
            gameObject.SetActive(false);
            isShow = false;
        }
        else 
        {
            gameObject.SetActive(true);
            isShow = true;
        }
    }

}
