using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public int levelSelectSceneNumber;

    public int LevelOneNumber;
    public int LevelTwoNumber;
    public int LevelThreeNumber;
    
    // Start is called before the first frame update
    void OnPlayButtonPressed()
    {
       SceneManager.LoadScene(levelSelectSceneNumber);
    }
    void OnQuitButtonPressed()
    {
        
    }
    public void OnLevelOnePressed()
    {
       SceneManager.LoadScene(LevelOneNumber);

    }
    public void OnLevelTwoPressed()
    {
        SceneManager.LoadScene(LevelTwoNumber);
    }
   
   // public void OnLevelThreePressed()
   // {
    //    SceneManager.LoadScene(LevelThreeNumber);
   /// }
}
