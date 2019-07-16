using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{

    //Text output;
    static string planetId;
    static string head;
    static string body;
    static string message = "";


    public GameObject chatPanel;
    //public string output;
    public GameObject output;

    [SerializeField]
    List<Message> messageList = new List<Message>();
    public int maxMessages = 25;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (message != null && message != "")
        {
            SendMessageToChat(message);
            message = "";
        }


        //DEBUG
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SendMessageToChat("you hit a space !");
        //    Debug.Log("space");
        //}


    }



    private void SendMessageToChat(string message)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = message;

        GameObject newText = Instantiate(output, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);

    }


    /// <summary>
    /// This is a Message class to store mesage obj and text 
    /// </summary>
    [System.Serializable]
    public class Message
    {
        public string text;
        public Text textObject;
    }
    



    public static void setPlanetId(string str)
    {
        planetId = str;

    }

    public static void setHead(string str)
    {
        head = str;

    }

    public static void setBody(string str)
    {
        body = str;

    }
    public static void setNotiResult()
    {
        //Debug.Log(planetId);
        //Debug.Log(head);
        //Debug.Log(body);
        message = planetId + head + body;
        message = message.Replace("pId:", "");
        message = message.Replace("plId:", "");
        message = message.Replace("\r", "");
        message = message.Replace("\n", "");
        //message = message.Replace("h:", "");
        //message = message.Replace("b:", "");
    }

    public static void setNotiDecision()
    {
        message = "You have a new Decision to vote.";
    }
}
