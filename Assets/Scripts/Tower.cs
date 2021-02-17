using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _speedUp;
    [SerializeField] private float _speedRotation;

    private bool _towerUp = false;
    private bool _changeHeight = false;
    private Vector3 _targetPosition;

    public event UnityAction TowerUp;


    public void Init(float size, float step)
    {
        float positionY = size * step + step / 2f;
        transform.position = new Vector3(transform.position.x,- positionY, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!_towerUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + _speedUp * Time.fixedDeltaTime, transform.position.z);
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + _speedUp * Time.fixedDeltaTime, 0));
            if (transform.position.y >= 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.y);
                _towerUp = true;
                TowerUp?.Invoke();
            }
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + _speedRotation * Time.fixedDeltaTime, 0));

        if (_changeHeight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - _speedUp * Time.fixedDeltaTime, transform.position.z);
            Debug.Log(_targetPosition.y + " " + transform.position.y);
            if (_targetPosition.y + transform.position.y <= 0)
            {
                _changeHeight = false;
                Debug.Log("target false");
            }
        }
    }

    public void OnChangeHeight(Platform platform)
    {
        _changeHeight = true;
        _targetPosition = platform.transform.position;
        Debug.Log("target true");
    }
}
