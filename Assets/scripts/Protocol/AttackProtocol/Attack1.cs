using UnityEngine;
using System.Collections;

public class Attack1 : MonoBehaviour,AttackProtocol {

    public int ID_SKILL_ATTACK { get; set; }
    public void Attack(GameObject my, GameObject enemy)
    {
        StartCoroutine(handle_move_enemy(my, enemy));
    }

    public  IEnumerator handle_move_enemy(GameObject my, GameObject enemy)
    {
        
        TweenPosition.Begin(my.gameObject, 0.1f, enemy.transform.localPosition);
        yield return new WaitForSeconds(0.2f);

        my.gameObject.GetComponent<Animator>().SetTrigger("Attack_1");

        GameObject _skill = ControlsSkill.It.get_skill();
        _skill.SetActive(true);
        _skill.transform.parent = enemy.transform;
        _skill.transform.localPosition = new Vector3(0, 1);
        if(enemy.GetComponent<Charater>()._thuoctinh.chaDirection==1)
        {
            _skill.transform.localScale = new Vector3(-1, 1);
        }
        _skill.GetComponent<Animator>().runtimeAnimatorController = ControlsSkill.It.lstAnimationSkill[3];

        
        yield return new WaitForSeconds(0.3f);
        enemy.GetComponent<Animator>().SetTrigger("Hurt");
        yield return new WaitForSeconds(1.2f);
        TweenPosition.Begin(my.gameObject, 0.1f, my.gameObject.GetComponent<Charater>()._myPos);

    }

    public void isAttack()
    {

    }
	// Use this for initialization
	
}
