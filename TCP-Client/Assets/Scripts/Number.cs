using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    //Text input;
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnSendButtonClick()
    {
        //for test
        //Decision.setDecision("123");
        string value = input.text;
        value = "***decision\r\n"
            + "Captain suggest to change "
            + DropDown.getHead() 
            + " by "
            + value;
        Chat.submitDecision(value);
        input.text = "";
        
    }

}
