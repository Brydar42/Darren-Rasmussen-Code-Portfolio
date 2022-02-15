using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {
    public enemyAI enemyAI;
    public Animator animator;
    public Playercontroler playerScript;
    bool attackStarted=false;
    const float ENEMY_DAMAGE = 5f;
    const float ENEMY_ATTACK_SPEED = 2f;
    // Use this for initialization
    void Start () {
	
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetBool("IsAttacking", true);
            enemyAI.SwitchState(enemyAI.AISTATE.Attack);
        }
    }
    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.layer== LayerMask.NameToLayer("Player"))
        {
            if(enemyAI.currAIState==enemyAI.AISTATE.Attack)
            if(!attackStarted)
            {
                StartCoroutine(AttackProcess());
                attackStarted = true;
            }
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetBool("IsAttacking", false);
            enemyAI.SwitchState(enemyAI.AISTATE.Wander);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
    IEnumerator AttackProcess()
    {
        playerScript.currentHealth -= ENEMY_DAMAGE;

        Debug.Log("!!!DMG!!!");

        yield return new WaitForSeconds(ENEMY_ATTACK_SPEED);

        attackStarted = false;
    }
}
