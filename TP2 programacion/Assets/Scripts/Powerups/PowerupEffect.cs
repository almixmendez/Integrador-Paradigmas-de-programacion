using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// De acá salen los powerups, y se aplican en el objeto.
public abstract class PowerupEffect : ScriptableObject, IApplyPwrp
{
    [SerializeField] public float amount;

    public abstract void Apply(GameObject target);
}