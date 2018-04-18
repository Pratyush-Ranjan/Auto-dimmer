using System.Collections;
using UnityEngine;


public class restart : MonoBehaviour
{

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }
}