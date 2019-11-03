using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Slider LoadSlider;

    AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync(3);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            LoadSlider.value = async.progress;
            if(async.progress == 0.9f)
            {
                LoadSlider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
