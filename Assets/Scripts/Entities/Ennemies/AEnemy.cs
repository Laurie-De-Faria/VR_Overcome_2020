using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : AEntity
{
    protected GameObject player;
    [SerializeField] protected bool _followPlayer;
    private Rigidbody _rgbody;
    [SerializeField] protected float _speed;

    protected override void Start()
    {
        base.Start();
        _rgbody = this.gameObject.GetComponent<Rigidbody>();
        _InitPlayer();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (_followPlayer)
            _FollowPlayer();
    }

    private void _InitPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
    }

    protected virtual void _FollowPlayer()
    {
        int minDist = 10;

        Debug.Log("Look at Player!");
        this.gameObject.transform.LookAt(player.transform);

        // Test
        if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }
}
