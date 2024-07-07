using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// De ac� salen los powerups.
public abstract class PowerupEffect : ScriptableObject, IApplyPwrp
{
    [SerializeField] public float amount;

    public abstract void Apply(GameObject target);
}