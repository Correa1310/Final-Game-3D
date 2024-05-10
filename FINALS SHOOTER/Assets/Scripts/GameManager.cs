using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
      // public TextMeshProUGUI targetText;
    public int winScene;
    public int loseScene;
    private int _targetAmount;
    //private Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        //_timer = GameObject.Find("GameManager").GetComponent<Timer>();
        Cursor.lockState = CursorLockMode.Locked;
        int floatingTarget = GameObject.FindGameObjectsWithTag("TargetFloating").Length;
        int standingTarget = GameObject.FindGameObjectsWithTag("TargetStanding").Length;
        _targetAmount = floatingTarget + standingTarget;
        //targetText.text = "Targets: " + _targetAmount.ToString();
    }

    void Update()
    {
       // if(_timer.GetTimeRemaining() <= 0)
        {
            //SceneManager.LoadScene(loseScene);
        }
    }

    public void UpdateTargetAmount()
    {
        _targetAmount -= 1;
        //targetText.text = "Targets: " + _targetAmount.ToString();

        if(_targetAmount <= 0)
        {
            //stop the timer
          //  GameObject.Find("GameManager").GetComponent<Timer>().EndGameTimer();

            //Send player to the win scene
            //SceneManager.LoadScene(winScene);
        }
    }
}
