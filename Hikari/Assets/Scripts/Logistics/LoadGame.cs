using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private int GameStart;
    private void Start()
    {
        SceneManager.LoadScene(GameStart);
    }
}
