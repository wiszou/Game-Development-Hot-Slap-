using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BGMusic : MonoBehaviour
{
    public static BGMusic bgMusic;
 
    void Awake()
    {
        if (bgMusic == null)
        {
            bgMusic = this;
            DontDestroyOnLoad(bgMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}