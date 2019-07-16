using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    //these three can by dicisions changed stats will showed with slider 
    Slider sOxygen;
    Slider sTemperature;
    Slider sSealvl;
    
    //for sync of planet material 
    static GameObject planet;
    static Shader planetShade;
    static Renderer rend;


    
    Text oxygen;
    Text temperature;
    Text sealvl;

    Text sugar;
    Text sulphur;
    Text lipids;
    Text aminoAcids;
    Text carbon;
    Text water;
    Text singleCell;
    Text multiCell;
    Text advanced;
    Text plant;

    static int ox = 0;
    static int tmp = 0;
    static int sl = 0;
    static int oldsl = 0;
    static int sug = 0;
    static int sul = 0;
    static int lp = 0;
    static int aa = 0;
    static int cb = 0;
    static int wat = 0;
    static int sc = 0;
    static int mc = 0;
    static int ac = 0;
    static int pc = 0;


    // Start is called before the first frame update
    void Start()
    {

        planet = GameObject.Find("Sphere");
        planetShade = Shader.Find("SGT Planet.shader");
        rend = planet.GetComponent<Renderer>();

        //sOxygen = GameObject.Find("Canvas/sOxygen").GetComponent<Slider>();
        //sTemperature = GameObject.Find("Canvas/sTemperature").GetComponent<Slider>();
        //sSealvl = GameObject.Find("Canvas/sSealvl").GetComponent<Slider>();


        oxygen = GameObject.Find("Canvas/Oxygen").GetComponent<Text>();
        temperature = GameObject.Find("Canvas/Temperature").GetComponent<Text>();
        sealvl = GameObject.Find("Canvas/Sealvl").GetComponent<Text>();

        sugar = GameObject.Find("Canvas/Sugar").GetComponent<Text>();
        sulphur = GameObject.Find("Canvas/Sulphur").GetComponent<Text>();
        lipids = GameObject.Find("Canvas/Lipids").GetComponent<Text>();
        aminoAcids = GameObject.Find("Canvas/AminoAcids").GetComponent<Text>();
        carbon = GameObject.Find("Canvas/Carbon").GetComponent<Text>();
        water = GameObject.Find("Canvas/Water").GetComponent<Text>();

        singleCell = GameObject.Find("Canvas/Singlecell").GetComponent<Text>();
        multiCell = GameObject.Find("Canvas/Multicell").GetComponent<Text>();
        advanced = GameObject.Find("Canvas/Advanced").GetComponent<Text>();
        plant = GameObject.Find("Canvas/Plant").GetComponent<Text>();

        //init all to 0 
        sulphur.text = "Sulphur: " + sul;
        sugar.text = "Sugar: " + sug;
        lipids.text = "Lipids: " + lp;
        aminoAcids.text = "Aminoacids: " + aa;
        carbon.text = "Carbon: " + cb; 
        water.text = "Water: " + wat;
        singleCell.text = "Singlecell: " + sc;
        multiCell.text = "Multicell: " + mc; 
        advanced.text = "Advanced: " + ac;
        plant.text = "Plant: " + pc;

        oxygen.text = "Oxygen: " +  ox;
        temperature.text = "Temperature: " + tmp;
        sealvl.text = "Sealvl: " + sl;
    }

    // Update is called once per frame
    void Update()
    {
        
        sulphur.text = "Sulphur: " + sul;
        sugar.text = "Sugar: " + sug;
        lipids.text = "Lipids: " + lp;
        aminoAcids.text = "Aminoacids: " + aa;
        carbon.text = "Carbon: " + cb;
        water.text = "Water: " + wat;
        singleCell.text = "Singlecell: " + sc;
        multiCell.text = "Multicell: " + mc;
        advanced.text = "Advanced: " + ac;
        plant.text = "Plant: " + pc;

        oxygen.text = "Oxygen: " + ox;
        temperature.text = "Temperature: " + tmp;

        sealvl.text = "Sealvl: " + sl;

        float min = (oldsl < sl ? oldsl :sl);
        float max = (oldsl < sl ? sl : oldsl);
        float t = 0;
        float temp =(float) (Mathf.Lerp(min, max, t)/ 500.0f );

        onChangeSeaLvl(temp);
        //Debug.Log("Sealvl:"+planet.GetComponent<Renderer>().material.GetFloat("_WaterLevel"));
        

    }


    /// <summary>
    /// change shaders value 
    /// </summary>
    static void onChangeSeaLvl(float i)
    {
        //Debug.Log("sealvl: " + i  );
        planet.GetComponent<Renderer>().material.SetFloat("_WaterLevel", i);

        //rend.material.shader = planetShade;


    }




    public static void setOxygen(int str)
    {
        ox = str;
    }
    public static void setSealvl(int str)
    {
        oldsl = sl;
        sl = str;
    }
    public static void setTemperature(int str)
    {
        tmp = str;
    }
    public static void setSulphur(int str)
    {
        sul = str;
    }
    public static void setSugar(int str)
    {
        sug = str;
    }
    public static void setLipids(int str)
    {
        lp = str;
    }
    public static void setAminoAcids(int str)
    {
        aa = str;
    }
    public static void setCarbon(int str)
    {
        cb = str;
    }
    public static void setWater(int str)
    {
        wat = str;
    }
    public static void setSingleCell(int str)
    {
        sc = str;
    }
    public static void setMultiCell(int str)
    {
        mc = str;
    }
    public static void setAdvanced(int str)
    {
        ac = str;
    }
    public static void setPlant(int str)
    {
        pc = str;
    }
}
   
