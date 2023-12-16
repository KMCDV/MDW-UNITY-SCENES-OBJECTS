using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NiestacjoSceneLoader : MonoBehaviour
{
    public static event EventHandler GameFullyLoaded;
    public List<int> buildIndexesToLoad = new List<int>();

    public Image loadingProgressImage;

    private float fakeProgress = 0;

    private void Start()
    {
        StartCoroutine(LoadScenesCoroutine());
    }

    private IEnumerator LoadScenesCoroutine()
    {
        List<AsyncOperation> asyncOperations = new List<AsyncOperation>();

        for (int i = 0; i < buildIndexesToLoad.Count; i++)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(buildIndexesToLoad[i], LoadSceneMode.Additive);
            loadSceneAsync.allowSceneActivation = false;
            asyncOperations.Add(loadSceneAsync);
        }

        while (EverySceneOperationDone() == false || fakeProgress < 10)
        {
            yield return null;
            fakeProgress += Time.deltaTime;
            loadingProgressImage.fillAmount = (asyncOperations[0].progress + asyncOperations[1].progress + fakeProgress) / 12f;
        }
        
        foreach (AsyncOperation asyncOperation in asyncOperations)
        {
            asyncOperation.allowSceneActivation = true;
        }
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene(), UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        yield return new WaitForEndOfFrame();
        yield return null;
        GameFullyLoaded?.Invoke(this, EventArgs.Empty);

        bool EverySceneOperationDone()
        {
            foreach (AsyncOperation asyncOperation in asyncOperations)
            {
                if (asyncOperation.progress < .9f)
                    return false;
            }
            return true;
        }
    }
    
}
