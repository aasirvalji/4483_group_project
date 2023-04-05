using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public static void GoMainScreen(){
        SceneManager.LoadScene("StartScene");
    }
    public static void RestartGame(){
        SceneManager.LoadScene("Level1");
    }

}
