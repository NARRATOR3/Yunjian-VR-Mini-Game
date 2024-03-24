using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GetHandEnterOBJ : MonoBehaviour
{
    public XRPokeInteractor xRPokeInteractor;
    public List<XRBaseInteractable> xRBases=new List<XRBaseInteractable>();
    private void OnEnable()
    {
     
       Debug.LogWarning(xRPokeInteractor.targetsForSelection);
    }
    public void XRObj(XRBaseInteractable cur)
    {
        xRPokeInteractor.startingSelectedInteractable = cur;
    }
}
