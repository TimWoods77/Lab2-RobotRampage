using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // 1 
    public void StartGame()
    {
        SceneManager.LoadScene("Battle");// loads battle scene
    }
    
    // 2 
    public void Quit()
    {
        Application.Quit();// exits the app unless your using it on unity
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
