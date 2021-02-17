using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _pointShoot;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _timeRecharge;

    private float timeShoot;

    private void OnEnable()
    {
        _playerInput.Touch += OnShootBullet;
    }

    private void OnDisable()
    {
        _playerInput.Touch -= OnShootBullet;
    }

    private void OnShootBullet()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _pointShoot.position, Quaternion.identity);
        timeShoot = _timeRecharge;
    }

    private bool CanShoot()
    {
        if (timeShoot != 0) return false;
        return true;
    }

    private void Update()
    {
        if (timeShoot > 0)
        {
            timeShoot -= Time.deltaTime;
            if (timeShoot <= 0)
            {
                timeShoot = 0;
            }
        }
    }
}
