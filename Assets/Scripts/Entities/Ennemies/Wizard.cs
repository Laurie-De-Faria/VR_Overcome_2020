using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : AEnemy
{
    //Animation
    private Animator _animator;
    private float _timer;

    //SpellCast
    [SerializeField] private GameObject _spellObj;

    protected override void Start()
    {
        base.Start();
        _animator = this.GetComponent<Animator>();
        _timer = 5.0f;
    }
    protected override void _FollowPlayer()
    {
        int minDist = 10;
        float cooldown = 5;
        float animationTime = 2;

        Debug.Log("Look at Player!");
        this.gameObject.transform.LookAt(player.transform);

        // Test
        if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
            _animator.SetBool("Run", true);
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
        else
        {
            _animator.SetBool("Run", false);
            if (_timer >= cooldown)
            {
                _animator.SetTrigger("CastSpell");
                Invoke("CastSpell", animationTime);
                _timer = 0;
            }
        }
        _timer += 1 * Time.deltaTime;
    }

    private void CastSpell()
    {
        float projectilSpeed = 2.0f;

        Vector3 startPosition = this.transform.position;

        startPosition.y += 1.5f;

        GameObject projectileObj = Instantiate(_spellObj, startPosition, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (player.transform.position - startPosition).normalized * projectilSpeed;
    }
}
