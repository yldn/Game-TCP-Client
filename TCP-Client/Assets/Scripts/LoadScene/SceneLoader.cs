using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{


    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;
    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width,Screen.height), fadeOutTexture);
        
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
    private void OnLevelWasLoaded(int level)
    {
        BeginFade(-1);
    }


    

    public  void onload(int scene)
    {
        StartCoroutine(sceneLoader(scene));
        
    }


   public  IEnumerator sceneLoader(int sceneIndex)
    {
        
        float fadeTime = this.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneIndex);
    }

    //IEnumerator waitForSecond(float sec)
    //{
    //    yield return new WaitForSeconds( sec );
    //}


}
