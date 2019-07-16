using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBut : MonoBehaviour
{
    private Button exit;

    // Start is called before the first frame update
    void Start()
    {
        exit = GetComponent<Button>();
        exit.onClick.AddListener(QuitGame);
    }
    
    void QuitGame()
    {
        Application.Quit();
    }
}
