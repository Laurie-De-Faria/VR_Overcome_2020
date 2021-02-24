using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : AEntity
{
    protected GameObject player;
    [SerializeField] protected bool _followPlayer;
    private Rigidbody _rgbody;
    private float _speed;

    public AEnemy(float life, float defence, float speed, bool followPlayer) : base(life, defence)
    {
        _speed = speed;
        _followPlayer = followPlayer;
    }

    protected void Start()
    {
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

    protected void _FollowPlayer()
    {
        Debug.Log("Look at Player!");
        this.gameObject.transform.LookAt(player.transform);
    }
}
