using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public abstract class AEntity : MonoBehaviour
{
    [SerializeField] protected VisualEffectAsset bloodParticules;
    [SerializeField] protected HealthBar _healthBar;
    [SerializeField] protected float defence;
    [SerializeField] protected float life;
    private VisualEffect _bloodParticules;

    protected virtual void Start()
    {
        _bloodParticules = new VisualEffect();
        //_bloodParticules.visualEffectAsset = bloodParticules;
        if (_healthBar != null)
        {
            _healthBar.SetMaxHealthBar(life);
        }
    }

    public void DownLife(float attack)
    {
        Debug.Log("hurt");
        if (attack > defence)
            life -= (attack - defence);
        if (life <= 0)
            DestroyEntity();
        if (_healthBar)
        {
            _healthBar.SetHealthBar(life);
        }
        Bleed();
    }

    public float getLife()
    {
        return (life);
    }

    private void DestroyEntity()
    {
        Debug.Log("Entity die");
        Destroy(this.gameObject);
    }

    private void Bleed()
    {
        if (bloodParticules)
        {
            //_bloodParticules.Play();
        }
    }
}
