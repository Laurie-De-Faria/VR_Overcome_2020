using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEntity : MonoBehaviour
{
    private float life;
    private readonly float defence;

    public AEntity(float life, float defence)
    {
        this.life = life;
        this.defence = defence;
    }

    public void DownLife(float attack)
    {
        Debug.Log("hurt");
        if (attack > defence)
            life -= (attack - defence);
        if (life <= 0)
            DestroyEntity();
    }

    private void DestroyEntity()
    {
        Debug.Log("Entity die");
    }
}
