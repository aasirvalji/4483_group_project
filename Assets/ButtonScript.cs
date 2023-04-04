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
    public static void SetScore(){
        string score = " ";
         using (StreamReader reader = new StreamReader("Assets/score.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int.TryParse(line, out startTime);
                }
            }
    }

}
