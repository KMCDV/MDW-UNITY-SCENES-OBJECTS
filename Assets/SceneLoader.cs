using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        for (int i = 0; i < 2500; i++)
        {
            yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }
}
