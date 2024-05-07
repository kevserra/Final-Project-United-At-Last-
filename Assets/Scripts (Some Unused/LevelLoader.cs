using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadSlider;

    public void LoadMainLevel(int sceneIndex)
    {
        StartCoroutine(loadingAsync(sceneIndex));     
    }

    private IEnumerator loadingAsync(int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            loadSlider.value = progress;
            yield return null;
        }
    }
}
