using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GameMusic : MonoBehaviour
{
    public static GameMusic instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}