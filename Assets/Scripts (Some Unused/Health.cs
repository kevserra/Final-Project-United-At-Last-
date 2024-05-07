using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IDamagable
{
    private LevelManager levelManager;

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float delayTime = 3f;
    [SerializeField] private GameObject[] heartsUI;

    public GameObject deathLossTxt;

    void Start()
    {
        deathLossTxt.SetActive(false);
        currentHealth = maxHealth;
    }

    public void TakeDamage(float dmgAmount)
    {
        currentHealth -= dmgAmount;

        if(currentHealth > -1)
        {
            heartsUI[(int)currentHealth].SetActive(false);
        } 
        else if(currentHealth <= 0) 
        {
            deathLossTxt.SetActive(true);
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
