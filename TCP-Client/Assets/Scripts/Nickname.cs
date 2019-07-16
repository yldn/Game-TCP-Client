using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Nickname : MonoBehaviour
{

    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
        //input.text = GameObject.Find("EnterName").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterName()
    {
        Chat.setPlayerID(input.text);
        gameObject.SetActive(false);
        //Chat.sendLocation();
        GPS.sendLocation();
    }
}
