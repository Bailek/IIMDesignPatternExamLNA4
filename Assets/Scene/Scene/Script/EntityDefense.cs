using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDefense : MonoBehaviour
{
    [SerializeField] Health _health;

    // method active mode defense
    public void Defense(bool onDef)
    {
        _health.OnDef = onDef;
    }

}
