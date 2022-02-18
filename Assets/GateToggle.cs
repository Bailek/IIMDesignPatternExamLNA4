using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateToggle : MonoBehaviour
{
    //listdes toggle
    [SerializeField] List<MyToggle> myToggles = new List<MyToggle>();

    //methode Launch ScreenShake
    public void checkOpenGate()
    {
        //Shake si tout les toogle sont actif
        if(myToggles[0].IsActive == true && myToggles[1].IsActive == true && myToggles[2].IsActive == true)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
