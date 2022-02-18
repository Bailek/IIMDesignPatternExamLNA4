using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    // prefab de la potion
    [SerializeField] GameObject itemPrefab;
    public void Touch(int power)
    {
        //Randome 1/3 de faire spawn une potion
        int i = Random.Range(0, 3);
        if(i == 0)
        {
            Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
