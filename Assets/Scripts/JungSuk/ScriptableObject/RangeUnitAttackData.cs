using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "UnitController/Attacks/BasicRange", order = 0)]
public class RangeUnitAttackData : AttackSO
{
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberofProjectilesPershot;
    public float multipleProjectilesAngel;
    public Color projectileColor;
}
