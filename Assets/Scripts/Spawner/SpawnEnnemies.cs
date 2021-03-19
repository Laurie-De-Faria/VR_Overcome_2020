using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemies : ASpawner
{
    [SerializeField]
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        // _InitSpawner(10f);
        _InitSpawner(1f); //tmp
    }

    public void SetActive()
    {
        isPressed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == false)
            return;
        _DownTimer();
        if (_doSpawn() == true)
        {
            Spawn();
            _ResetTimer();
            isPressed = false;
        }
    }
}
