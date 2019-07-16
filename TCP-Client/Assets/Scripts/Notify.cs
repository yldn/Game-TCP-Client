using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notify : MonoBehaviour
{
    static Text text;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Notify").GetComponent<Button>();
        text = GameObject.Find("notify").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void notify()
    {
        text.text = "New Decision!";
        text.color = Color.red;
    }

    public static void cancelNotify()
    {
        text.text = "No Decision";
        text.color = Color.white;
    }
}
