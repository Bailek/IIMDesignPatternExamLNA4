using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] BulletPooling _bulletPooling;

    public void FireBullet(int power)
    {
        bool HaveBullet = false;
        Bullet TMPBullet = null;

        if (_bulletPooling.bullets.Count > 0)
        {

            foreach (Bullet bullet in _bulletPooling.bullets)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    TMPBullet = bullet;
                    HaveBullet = true;
                    break;
                }
                if(bullet == _bulletPooling.bullets[_bulletPooling.bullets.Count-1])
                {
                    HaveBullet = false;
                }
            }
        }


        if (HaveBullet)
        {
            TMPBullet.transform.position = _spawnPoint.position;
            TMPBullet.Init(_spawnPoint.TransformDirection(Vector3.right), power);
            TMPBullet.gameObject.SetActive(true);
        }
        else
        {
            var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
            .Init(_spawnPoint.TransformDirection(Vector3.right), power);

            _bulletPooling.AddBullet(b);
        }
        
        
    }

}
