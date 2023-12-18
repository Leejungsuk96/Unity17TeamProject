using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerStatHandler : MonoBehaviour
{

    [SerializeField] private TowerStats baseStats;
    public TowerStats CurrentStats { get; private set; }
    public List<TowerStats> statsModifiers = new List<TowerStats>();

    private void Awake()
    {
        UpdateTowerStats();
    }

    private void UpdateTowerStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStats = new TowerStats { attackSO = attackSO };
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;


    }

    private void UpdateStats(Func<float, float, float> operation, TowerStats newModifier)
    {
        CurrentStats.maxHealth = (int)operation(CurrentStats.maxHealth, newModifier.maxHealth);
        CurrentStats.speed = operation(CurrentStats.speed, newModifier.speed);

        if (CurrentStats.attackSO == null || newModifier.attackSO == null)
            return;

        UpdateAttackStats(operation, CurrentStats.attackSO, newModifier.attackSO);

        if (CurrentStats.attackSO.GetType() != newModifier.attackSO.GetType())
        {
            return;
        }

        switch (CurrentStats.attackSO)
        {
            case RangedAttackData _:
                ApplyRangedStats(operation, newModifier);
                break;
        }
    }

    private void UpdateAttackStats(Func<float, float, float> operation, AttackSO currentAttack, AttackSO newAttack)
    {
        if (currentAttack == null || newAttack == null)
        {
            return;
        }

        currentAttack.delay = operation(currentAttack.delay, newAttack.delay);
        currentAttack.power = operation(currentAttack.power, newAttack.power);
        currentAttack.size = operation(currentAttack.size, newAttack.size);
        currentAttack.speed = operation(currentAttack.speed, newAttack.speed);
    }

    private void ApplyRangedStats(Func<float, float, float> operation, TowerStats newModifier)
    {
        RangedAttackData currentRangedAttacks = (RangedAttackData)CurrentStats.attackSO;

        if (!(newModifier.attackSO is RangedAttackData))
        {
            return;
        }

        RangedAttackData rangedAttacksModifier = (RangedAttackData)newModifier.attackSO;
        currentRangedAttacks.multipleProjectilesAngel =
            operation(currentRangedAttacks.multipleProjectilesAngel, rangedAttacksModifier.multipleProjectilesAngel);
        currentRangedAttacks.spread = operation(currentRangedAttacks.spread, rangedAttacksModifier.spread);
        currentRangedAttacks.duration = operation(currentRangedAttacks.duration, rangedAttacksModifier.duration);
        currentRangedAttacks.numberofProjectilesPerShot = Mathf.CeilToInt(operation(currentRangedAttacks.numberofProjectilesPerShot,
            rangedAttacksModifier.numberofProjectilesPerShot));
        currentRangedAttacks.projectileColor = UpdateColor(operation, currentRangedAttacks.projectileColor, rangedAttacksModifier.projectileColor);
    }

    private Color UpdateColor(Func<float, float, float> operation, Color currentColor, Color newColor)
    {
        return new Color(
            operation(currentColor.r, newColor.r),
            operation(currentColor.g, newColor.g),
            operation(currentColor.b, newColor.b),
            operation(currentColor.a, newColor.a));
    }

    private void LimitStats(ref float stat, float minVal)
    {
        stat = Mathf.Max(stat, minVal);
    }

    private void LimitAllStats()
    {
        if (CurrentStats == null || CurrentStats.attackSO == null)
        {
            return;
        }
    }
}
