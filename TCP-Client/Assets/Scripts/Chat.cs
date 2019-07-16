using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Chat : MonoBehaviour
{
    public string ipadress = "127.0.0.1";
    //public string ipadress = "192.168.31.137";
    //public string ipadress = "131.159.219.215";
    public int port = 7788;

    public InputField input;

    public GameObject chatPanel;

    //public GameObject output;
    public GameObject output;
    private static Socket clientSocket;

    //receivethread 
    Thread t;
    private byte[] data = new byte[65536];

    [SerializeField]
    List<Message> messageList = new List<Message>();
    public int maxMessages = 25;


    private string message = "";
    private string tem = "";

    private static string playerId = "";
    private static float latitude = 48.2650469f;
    private static float longitude = 11.6693806f;

    // Start is called before the first frame update
    void Start()
    {
        //output.text = "";
        OnConnectedToServer();
    }

    // Update is called once per frame
    void Update()
    {

        message = parseMessage(message);

        //DEBUG
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SendMessageToChat("you hit a space !");
        //    Debug.Log("space");
        //}


        if (message != null && message != "")
        {
            SendMessageToChat(message);
            message = "";

        }


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





    private void OnConnectedToServer()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipadress), port));
        //creat a thread to receive接收消息线程

        t = new Thread(ReceiveMessage);
        t.Start();
    }

    private void OnApplicationQuit()
    {
        t.Abort();
    }


    private void ReceiveMessage()
    {

        
        while (true)
        {
            //if (clientSocket.Poll(10, SelectMode.SelectRead))
            //    break;
            //Debug.Log("message received" + message);

            int length = clientSocket.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
            //to parse the message, when it's stats or dicision, it will not show on chatroom but on gameboard
            //message = parseMessage(tem);
            Debug.Log(message);
        }

    }

    new static void SendMessage(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        if (data.Length != 0)
        {
            clientSocket.Send(data);
        }
    }

    public void OnSendButtonClick()
    {
        string value = playerId + ": \n" + input.text;
        SendMessage(value);
        input.text = "";
    }
    private void OnDestroy()
    {
        //clientSocket.Shutdown(SocketShutdown.Both);
        //clientSocket.Close();
    }

    private string parseMessage(string message)
    {
        //message = message.Replace("\r", "");
        //message = message.Replace("\n", "");

        //check stats
        string[] lines = message.Split("\r\n".ToCharArray());

        if (lines[0] == "***planet")
        {
            //Console.WriteLine("***planet");
            parseToStats(message);

            //message will not show in chatroom
            return "";
        }
        else if (lines[0] == "***decision")
        {
            //Console.WriteLine("***decision");
            parseToDesicion(message);
            
            return "";
        }
        else if (lines[0] == "***notification")
        {
            //Debug.Log("here noftification: " + message);
            parseToNotification(message);
            return "";
        }
        else
        {
            //Debug.Log("message:" + message);
            return message;
        }
    }

    private void parseToStats(string message)
    {
        Stats.setOxygen(int.Parse(message.Substring(message.IndexOf("ox:") + 3, message.IndexOf("sl:") - message.IndexOf("ox:") - 3)));
        Stats.setSealvl(int.Parse(message.Substring(message.IndexOf("sl:") + 3, message.IndexOf("tmp:") - message.IndexOf("sl:") - 3)));
        Stats.setTemperature(int.Parse(message.Substring(message.IndexOf("tmp:") + 4, message.IndexOf("sul:") - message.IndexOf("tmp:") - 4)));
        Stats.setSulphur(int.Parse(message.Substring(message.IndexOf("sul:") + 4, message.IndexOf("sug:") - message.IndexOf("sul:") - 4)));
        Stats.setSugar(int.Parse(message.Substring(message.IndexOf("sug:") + 4, message.IndexOf("lp:") - message.IndexOf("sug:") - 4)));
        Stats.setLipids(int.Parse(message.Substring(message.IndexOf("lp:") + 3, message.IndexOf("aa:") - message.IndexOf("lp:") - 3)));
        Stats.setAminoAcids(int.Parse(message.Substring(message.IndexOf("aa:") + 3, message.IndexOf("carbon:") - message.IndexOf("aa:") - 3)));
        Stats.setCarbon(int.Parse(message.Substring(message.IndexOf("carbon:") + 7, message.IndexOf("water:") - message.IndexOf("carbon:") - 7)));
        Stats.setWater(int.Parse(message.Substring(message.IndexOf("water:") + 6, message.IndexOf("sc:") - message.IndexOf("water:") - 6)));
        Stats.setSingleCell(int.Parse(message.Substring(message.IndexOf("sc:") + 3, message.IndexOf("mc:") - message.IndexOf("sc:") - 3)));
        Stats.setMultiCell(int.Parse(message.Substring(message.IndexOf("mc:") + 3, message.IndexOf("ac:") - message.IndexOf("mc:") - 3)));
        Stats.setAdvanced(int.Parse(message.Substring(message.IndexOf("ac:") + 3, message.IndexOf("pc:") - message.IndexOf("ac:") - 3)));
        Stats.setPlant(int.Parse(message.Substring(message.IndexOf("pc:") + 3, message.Length - message.IndexOf("pc:") - 3)));
        //Debug.Log("ready to parse pc:");
    }

    private static void parseToDesicion(string message)
    {
        Decision.setPlanetId(message.Substring(message.IndexOf("pId:") + 4, message.IndexOf("description:") - message.IndexOf("pId:") - 4));
        Decision.setDescription(message.Substring(message.IndexOf("description:") + 12, message.Length - message.IndexOf("description:") - 12));
        Decision.setDecision();
    }

    private static void parseToNotification(string message)
    {
        //Debug.Log(message);
        Notification.setPlanetId(message.Substring(message.IndexOf("pid:") + 4, message.IndexOf("h:") - message.IndexOf("pid:") - 4));
        Notification.setHead(message.Substring(message.IndexOf("h:") + 2, message.IndexOf("b:") - message.IndexOf("h:") - 2));
        Notification.setBody(message.Substring(message.IndexOf("b:") + 2, message.Length - message.IndexOf("b:") - 2));
        Notification.setNotiResult();
        StopWatch.addTime();
    }


    public static void submitDecision(string head)
    {
        
        SendMessage(head);
    }

    public static void submitVote(string vote)
    {
        SendMessage(vote);
    }

    public static void setPlayerID(string name)
    {
        playerId = name;
    }

    public static string getPlayerID()
    {
        return playerId;
    }

    public static void sendLocation()
    {
        SendMessage("***location"
            + "\r\n"
            + "plId:"
            + getPlayerID()
            + "\r\n"
            + "x:"
            + latitude
            + "\r\n"
            + "y:"
            + longitude);
    }

    public static void setLatitude(float la)
    {
        latitude = la;
    }

    public static void setLongitude(float lo)
    {
        longitude = lo;
    }



}
