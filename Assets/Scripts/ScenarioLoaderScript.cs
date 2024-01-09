using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioLoaderScript : MonoBehaviour
{
    [System.Serializable]
    public class Scenario
    {
        //Treat allScenes[0] as Main Scene.
        public string[] allScenes;
    }

    public Scenario[] allScenarios;

    public FadeScreen fadeScreenScript;


    public void LoadScenario(int scenarioIndex)
    {

        for(int i = 0; i < allScenarios[scenarioIndex].allScenes.Length; ++i)
        {
            if (i == 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene(allScenarios[scenarioIndex].allScenes[i]);

            else
                UnityEngine.SceneManagement.SceneManager.LoadScene(allScenarios[scenarioIndex].allScenes[i], LoadSceneMode.Additive);
        }
        
        
    }

    public void FadeOutToLoad(int scenarioIndex)
    {
        StartCoroutine(FadeOutToLoadRoutine(scenarioIndex));
    }

    IEnumerator FadeOutToLoadRoutine(int scenarioIndex)
    {
        fadeScreenScript.FadeOut();
        yield return new WaitForSeconds(fadeScreenScript.fadeDuration);

        LoadScenario(scenarioIndex);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
