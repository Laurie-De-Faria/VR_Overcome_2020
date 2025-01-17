﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AWeapon : MonoBehaviour
{
    private float durability;
    private float powerAttack;
    private float powerDefence;

    public AWeapon(float durability, float attack, float defence)
    {
        this.durability = durability;
        powerAttack = attack;
        powerDefence = defence;
    }

    protected void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<AEntity>() != null)
        {
            DoAttack(col.gameObject.GetComponent<AEntity>());
        }
        else if (col.gameObject.GetComponent<AWeapon>() != null)
        {
            DoDefence(col.gameObject.GetComponent<AWeapon>());
        }
        else
        {
            SetDurability(durability - 0.1f);
        }
    }

    private void DoAttack(AEntity entity)
    {
        entity.DownLife(powerAttack);
        SetDurability(durability - 0.5f);
    }

    private void DoDefence(AWeapon weapon)
    {
        float attack = weapon.GetAttack();

        if (attack > powerDefence)
        {
            SetDurability(durability - (attack - powerDefence));
        }
    }

    public float GetDurability()
    {
        return durability;
    }

    private void SetDurability(float value)
    {
        durability = value;
        if (durability <= 0)
            DestroyWeapon();
    }

    private float GetAttack()
    {
        return powerAttack;
    }

    private void DestroyWeapon()
    {
        Destroy(this.gameObject);
    }
}
