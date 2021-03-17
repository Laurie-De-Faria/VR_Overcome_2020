using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : AEntity
{
    protected GameObject player;
    [SerializeField] protected bool _followPlayer;
    private Rigidbody _rgbody;
    private float _speed;

    //Animation
    private Animator _animator;
    private float _timer;

    public AEnemy(float life, float defence, float speed, bool followPlayer) : base(life, defence)
    {
        _speed = speed;
        _followPlayer = followPlayer;
    }

    protected void Start()
    {
        _rgbody = this.gameObject.GetComponent<Rigidbody>();
        _animator = this.GetComponent<Animator>();
        _timer = 5.0f;
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
        int minDist = 10;
        int cooldown = 5;
        int speed = 4;

        Debug.Log("Look at Player!");
        this.gameObject.transform.LookAt(player.transform);

        // Test
        if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
            _animator.SetBool("Run", true);
            transform.position += transform.forward * speed * Time.deltaTime;
        } else
        {
            _animator.SetBool("Run", false);
            if (_timer >= cooldown)
            {
                _animator.SetTrigger("CastSpell");
                _timer = 0;
            }
        }
        _timer += 1 * Time.deltaTime;
    }
}
