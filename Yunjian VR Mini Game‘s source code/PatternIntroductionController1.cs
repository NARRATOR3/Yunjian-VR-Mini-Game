using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternIntroductionController : MonoBehaviour
{
    // UI GameObject to show/hide.
    public GameObject patternIntroductionUI;

    // Function to show the UI element. This can be called by XR Simple Interactable's event.
    public void ShowPatternIntroduction()
    {
        if (patternIntroductionUI != null)
        {
            patternIntroductionUI.SetActive(true);
        }
    }

    // Function to hide the UI element. This can be called by XR Simple Interactable's event.
    public void HidePatternIntroduction()
    {
        if (patternIntroductionUI != null)
        {
            patternIntroductionUI.SetActive(false);
        }
    }
}