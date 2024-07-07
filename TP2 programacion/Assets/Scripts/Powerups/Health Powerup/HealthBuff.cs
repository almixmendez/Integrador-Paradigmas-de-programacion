using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Powerup de vida.

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().health += amount;
    }
}
