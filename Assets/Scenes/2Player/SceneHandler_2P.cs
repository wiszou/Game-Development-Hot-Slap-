using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler_2P : MonoBehaviour
{
   public void OnClickPlay()
    {
        SceneManager.LoadScene("GameScene");
    }
      public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
}
