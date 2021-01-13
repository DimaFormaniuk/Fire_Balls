using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFinishLevel : MonoBehaviour
{
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.SizeUpdate += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.SizeUpdate -= OnSizeUpdated;
    }

    private void OnSizeUpdated(int size)
    {
        if (size == 0)
        {
            Debug.Log("This level finish");
        }
    }
}
