using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;

public class transition : MonoBehaviour
{
    public GameObject ETransitionBlack;
    public GameObject STransitionBlack;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void StartTran(int x)
    {
        x = x-5;
        StartCoroutine(LoadSceneAfterTransition(x));
    }

    public void HalfTran()
    {
        ETransitionBlack.transform.localScale = new Vector3(1, 1, 1);
        STransitionBlack.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scaleX(STransitionBlack, 18, 0.3f);
    }

    public void EndTran()
    {
        ETransitionBlack.transform.localScale = new Vector3(18, 1, 1);
        STransitionBlack.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scaleX(ETransitionBlack, 1, 0.3f);
    }

    private IEnumerator LoadSceneAfterTransition(int x)
    {
        ETransitionBlack.transform.localScale = new Vector3(1, 1, 1);
        STransitionBlack.transform.localScale = new Vector3(1, 1, 1);
        
        // Start the first transition
        LeanTween.scaleX(STransitionBlack, 18, 0.3f);

        // Wait until the first transition is finished
        yield return new WaitForSeconds(0.3f);

        // Load the scene
        if (x != -1)
        {
            SceneManager.LoadScene(x);
        }

        // Start the second transition
        ETransitionBlack.transform.localScale = new Vector3(18, 1, 1);
        STransitionBlack.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scaleX(ETransitionBlack, 1, 0.3f);

        // Wait until the second transition is finished
        yield return new WaitForSeconds(0.3f);

        // The transition is completed, and the scene has been loaded.
    }
}






