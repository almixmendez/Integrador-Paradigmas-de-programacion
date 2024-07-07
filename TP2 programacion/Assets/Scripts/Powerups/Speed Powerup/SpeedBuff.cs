using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffect
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().playerSpeed += amount;
        target.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
