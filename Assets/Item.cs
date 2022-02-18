using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Iitem
{
    [SerializeField] Iitem.TYPE _type;
    public Iitem.TYPE Type { get; private set; }
    private void Start()
    {
        Type = _type;
    }
 }
