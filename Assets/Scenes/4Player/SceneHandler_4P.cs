using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler_4P : MonoBehaviour
{
      public void OnClickPlay()
    {
        SceneManager.LoadScene("Bracket1_4P");
    }
      public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
}
