using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetected : MonoBehaviour
{
    // list des keys ramasser
    List<Item> Keys = new List<Item>();
    [SerializeField] Health health;

    // On trigger enter dans les item permet d'effectuer les condition si dessous
    private void OnTriggerEnter2D(Collider2D other)
    {
        // si c'est un item
        if(other.TryGetComponent(out Item item))
        {
            // si on touche un Item type potion
            if (item.Type == Iitem.TYPE.POTION)
            { 
                health.GainHealth();
            }

            // si on touche un Item type Key
            if (item.Type == Iitem.TYPE.KEY)
            {
                Keys.Add(item);
            }
            Destroy(item.transform.parent.gameObject);
        }
        // si c'est une porte
        if (other.CompareTag("Gate"))
        {
            int i = -1;
            // si on as au moin une clef dans notre liste
            foreach(Item key in Keys)
            {
                i++;
                if (key.Type == Iitem.TYPE.KEY)
                {
                    break;
                }
                
            }
            // si on as une key
            if (i >= 0)
            {
                Destroy(other.transform.parent.gameObject);
                Keys.RemoveAt(i);
            }
        }
    }

}
