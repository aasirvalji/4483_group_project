using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HelpSceneScript : MonoBehaviour
{
    public void LoadScene ()
    {
        SceneManager.LoadScene("StartScene");
    }
}
