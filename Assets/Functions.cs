using UnityEngine;
using System.Collections;

public class Functions : MonoBehaviour
{
    public void OnAutodimmerToggle()
    {
        StaticSettings.AutoDimmer = !StaticSettings.AutoDimmer;
    }
}