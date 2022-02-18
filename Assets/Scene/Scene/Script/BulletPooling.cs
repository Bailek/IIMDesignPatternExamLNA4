using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] int PreloadBullet;
    public List<Bullet> bullets { get; private set; }

    //initialisation de X bullet avant dans tirer pour que la list ne soit pas null
    void Awake()
    {
        bullets = new List<Bullet>();

        for(int i = 0; i < PreloadBullet; i++)
        {
            Bullet b = Instantiate(_bulletPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            bullets.Add(b);
            b.gameObject.SetActive(false);
        }

    }

    //methode que rjoute les bullet qui sont tire en plus de celle de la list
    public void AddBullet(Bullet bullet)
    {
        bullets.Add(bullet);
    }


}
