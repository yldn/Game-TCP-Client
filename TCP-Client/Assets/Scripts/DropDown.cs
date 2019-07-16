using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    Dropdown dpn;
    List<string> options = new List<string>();
    static string head;

    // Start is called before the first frame update
    void Start()
    {
        Dropdown.OptionData data1 = new Dropdown.OptionData();

        data1.text = "Oxygen";

        Dropdown.OptionData data2 = new Dropdown.OptionData();

        data2.text = "Temperature";

        Dropdown.OptionData data3 = new Dropdown.OptionData();

        data3.text = "Sealvl";

        dpn = transform.GetComponent<Dropdown>();

        dpn.options.Add(data1);

        dpn.options.Add(data2);

        dpn.options.Add(data3);

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Drop_select(int n)
    {
        head = dpn.captionText.text;
    }

    public static string getHead()
    {
        return head;
    }
}
