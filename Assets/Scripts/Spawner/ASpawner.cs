using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpawner : MonoBehaviour
{
    public GameObject obj;
    [SerializeField] private float _timer;
    private float _maxTime;
    private Transform _positionSpawn;

    protected void _InitSpawner(float timer)
    {
        _maxTime = timer;
        _positionSpawn = this.gameObject.transform;
        _ResetTimer();
    }

    protected virtual void Spawn()
    {
        Instantiate(obj, _positionSpawn);
    }

    protected void _ResetTimer()
    {
        _timer = _maxTime;
    }

    protected void _DownTimer()
    {
        _timer -= Time.deltaTime;
    }

    protected bool _doSpawn()
    {
        if (_timer <= 0)
        {
            return true;
        }
        return false;
    }
}
