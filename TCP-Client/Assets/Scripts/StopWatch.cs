using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopWatch : MonoBehaviour
{
    GameObject SceneManager;
    SceneLoader sceneLoader;
    public static float totaltime1 = 360;//倒计时总时间
    private float intervaletime = 1;
    public Text countdown1text;//倒计时

    //public float totaltime2 = 360;
    //public Text countdown2text;

    // Use this for initialization
    void Start()
    {
        SceneManager = GameObject.Find("SceneManager");
        sceneLoader = SceneManager.GetComponent<SceneLoader>();

        countdown1text.text = string.Format("{0:D2}:{1:D2}",(int)totaltime1 / 60, (int)totaltime1 % 60);
        //countdown2text.text = string.Format("{0:D2}:{1:D2}", (int)totaltime2 / 60, (int)totaltime1 % 60);
        StartCoroutine(Count_down());
    }
    private IEnumerator Count_down()
    {//协程方法实现倒计时
        while (totaltime1 > 0)
        {
            yield return new WaitForSeconds(1.0f);
            totaltime1--;
            countdown1text.text = string.Format("{0:D2}:{1:D2}",
          (int)totaltime1 / 60, (int)totaltime1 % 60);
        }
        if(totaltime1 <= 0)
        {
            sceneLoader.onload(2);
        }


    }
    // Update is called once per frame
    //void Update()
    //{//更新方法实现倒计时
    //    if (totaltime2 > 0)
    //    {
    //        intervaletime -= Time.deltaTime;
    //        if (intervaletime <= 0)
    //        {
    //            intervaletime += 1;
    //            totaltime2--;
    //            countdown2text.text = string.Format("{0:D2}:{1:D2}",
    //            (int)totaltime2 / 60, (int)totaltime1 % 60);

    //        }
    //    }

    //}

    public static void addTime()
    {
        totaltime1 += 15;
    }
}
