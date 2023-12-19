using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public float cooldownTime = 60f;
    public float boostAmount = 1.5f;
    public float boostDuration = 30f;
    public int resourceCost = 10;

    private bool isSkillAvailable = true;

    public void UseSkill()
    {
        if (isSkillAvailable && HasEnoughResources())
        {
            SkillEffect();
            StartCoroutine(Cooldown());
        }
    }

    private void SkillEffect()
    {
        // ���⿡ Ÿ���� ��ų ȿ���� �����ϴ� �ڵ带 �ۼ�

        SpendResources();
    }


    private IEnumerator Cooldown()
    {
        isSkillAvailable = false;
        yield return new WaitForSeconds(cooldownTime);
        isSkillAvailable = true;
    }

    private bool HasEnoughResources()
    {
        // ���⿡ �ڿ��� ������� ���θ� üũ�ϴ� �ڵ带 �ۼ�
        return true;
    }

    private void SpendResources()
    {
        // ���⿡ �ڿ��� �Ҹ��ϴ� �ڵ带 �ۼ�
    }
}
