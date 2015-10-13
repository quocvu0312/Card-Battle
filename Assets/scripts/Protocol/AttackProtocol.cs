using UnityEngine;
using System.Collections;

public interface AttackProtocol {

   int ID_SKILL_ATTACK { get; set; }
   void Attack(GameObject my,GameObject enemy);
   void isAttack();
   IEnumerator handle_move_enemy(GameObject my, GameObject enemy);
	// Use this for initialization
	
}
