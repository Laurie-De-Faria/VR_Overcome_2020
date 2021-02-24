using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public abstract class AEntity : MonoBehaviour
{
    private float life;
    private readonly float defence;

    [SerializeField] private VisualEffectAsset bloodParticules;
    private VisualEffect _bloodParticules;

    public AEntity(float life, float defence)
    {
        this.life = life;
        this.defence = defence;
        _bloodParticules = new VisualEffect();
        _bloodParticules.visualEffectAsset = bloodParticules;
    }

    public void DownLife(float attack)
    {
        Debug.Log("hurt");
        if (attack > defence)
            life -= (attack - defence);
        if (life <= 0)
            DestroyEntity();
        Bleed();
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
