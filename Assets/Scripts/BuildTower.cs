using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private Platform[] _platformTemplate;

    private int _sizeTower = 10;
    private float _rotation = 30f;
    private float step => 0.3f;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        float startY = 0;
        int n = 1;
        int k = 0;
        for (int i = 0; i < _sizeTower; i++)
        {
            var platform = Instantiate(_platformTemplate[k], GetPosition(ref startY), Quaternion.identity, _tower.transform);
            platform.TouchBullet += _tower.OnChangeHeight;

            Increment(ref k, ref n);
        }
        _tower.Init(_sizeTower, step);
    }

    private void Increment(ref int k, ref int n)
    {
        k += n;
        if (k >= _platformTemplate.Length)
        {
            k = _platformTemplate.Length;
            n = -1;
            k += n;
            k += n;
        }
        else if (k < 0)
        {
            k = 0;
            n = 1;
            k += n;
        }
    }

    private Vector3 GetPosition(ref float posY)
    {
        posY += step;
        return new Vector3(0, posY, 0);
    }

}
