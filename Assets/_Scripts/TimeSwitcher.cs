using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeSwitcher : MonoBehaviour
{

    private IEnumerator Coroutine;

    void Start()
    {
        Coroutine = Switcher(3f);
        StartCoroutine(Coroutine);
    }

    private IEnumerator Switcher(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }
}
