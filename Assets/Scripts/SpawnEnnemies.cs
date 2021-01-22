using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemies : MonoBehaviour
{
    public GameObject ennemi;
    [SerializeField] private float timer;
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == false)
            return;
        timer -= Time.deltaTime;
    }
}
