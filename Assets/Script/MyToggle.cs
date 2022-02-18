using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyToggle : MonoBehaviour, ITouchable
{
    // Je veux ouvrir un évènement pour les designers pour qu'ils puissent set la couleur du sprite eux même
    [SerializeField] UnityEvent _onToggleOn;
    [SerializeField] UnityEvent _onToggleOff;
    [SerializeField] GateToggle gateToggle;

    public bool IsActive { get; private set; }

    private void Awake()
    {
        IsActive = false;
    }

    public void Touch(int power)
    {
        IsActive = !IsActive;

        if (IsActive)
        {
            // applique le material choisi dans l'editeur 
            _onToggleOn.Invoke();
        }
        else
        {
            _onToggleOff.Invoke();
        }
        //methode dans Gate toggle
        gateToggle.checkOpenGate();
    }
}
