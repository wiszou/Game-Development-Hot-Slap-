using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler_3P : MonoBehaviour
{
   public void OnClickPlay()
    {
        SceneManager.LoadScene("Bracket1_3P");
    }
      public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
}   
