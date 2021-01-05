using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _moveDiraction;

    private void Start()
    {
        _moveDiraction = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDiraction * _speed * Time.deltaTime);
    }
}
