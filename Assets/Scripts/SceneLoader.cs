using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //load scene additively
        /*SceneManager.LoadScene("UI", LoadSceneMode.Additive);*/ //TEMP CODE, for access to UI scene objects

        //load UI scene in the background - prep scene for use
        StartCoroutine(LoadSceneAsync("UI")); //calling enumerator

    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Debug.Log("Scene Loaded!");
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}
}
