using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierRotate : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + _speed * Time.fixedDeltaTime, 0));
    }
}
