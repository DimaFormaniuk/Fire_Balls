using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    public event UnityAction<Platform> TouchBullet;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            TouchBullet?.Invoke(this);
        }
    }
}
