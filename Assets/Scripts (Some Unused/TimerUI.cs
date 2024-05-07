using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{

    private LevelManager levelManager;

    Image timerFilling;
    float timeRemaining;
    float delayTimeRemaining;

    public float maxTime = 10f;
    public float delayTime;
    public GameObject timerLossTxt;
    public bool delayOver = false;
    //public int mainLevel;
    //public string reloadLevel;
    
    void Start()
    {
        timerLossTxt.SetActive(false);
        timerFilling = GetComponent<Image>();
        timeRemaining = maxTime; 
        delayTimeRemaining = delayTime;
    }
    private void timesUpLevelRestart()
    {
        
    }

    void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            timerFilling.fillAmount = timeRemaining / maxTime;
            return;
        } 

        if(!delayOver) 
        {
               delayOver = true;
               timerLossTxt.SetActive(true);
               StartCoroutine(RestartSceneRoutine()); 
        }
    }

    private IEnumerator RestartSceneRoutine() 
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(delayTime);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
