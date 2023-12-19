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
        // 여기에 타워의 스킬 효과를 적용하는 코드를 작성

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
        // 여기에 자원이 충분한지 여부를 체크하는 코드를 작성
        return true;
    }

    private void SpendResources()
    {
        // 여기에 자원을 소모하는 코드를 작성
    }
}
