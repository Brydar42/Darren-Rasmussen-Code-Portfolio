using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class BasicAI : MonoBehaviour {
    CommandMovement movementScript;
    public GameWinLossDecision lossOfUnits;
    public float TotalHealth = 100;
    public float currentHealth = 100;
    public bool attackStarted = false;
    const float ENEMY_DAMAGE = 5f;
    public bool weaponAdvantage=false;
    const float ENEMY_ATTACK_SPEED = 2f;
    public enum AI_TYPES
    {
        spearman,//beats calvery,loses archer
        archer,  //beats spearman,loses calvery
        calvery  //beats archer,loses spearman
    }
    public enum AiStates
    {
        idle,
        selected,
        moving,
        attacking,
        dead
    }
    public AiStates currentstate;
    public AI_TYPES unittype;
    // Use this for initialization
    void Start () {
        movementScript = gameObject.GetComponent<CommandMovement>();
        currentstate = AiStates.idle;

    }
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0.0f)
        {
            if (gameObject.tag == "Player1units")
            {
                lossOfUnits.Player1units -= 1;
            }
            else if (gameObject.tag == "Player1units")
            {
                lossOfUnits.Player2units -= 1;
            }
            currentstate = AiStates.dead;
        }
        switch (currentstate)
        {
            //idle
            case AiStates.idle:
                if (movementScript.isSelected == true)
                    currentstate = AiStates.selected;
                break;
            //selected
            case AiStates.selected:
                //enter avatar mode
                break;
            case AiStates.moving:
                //don't do anything just move
                break;
            case AiStates.attacking:
                //
                if (!attackStarted)
                {
                    StartCoroutine(AttackProcess());
                    attackStarted = true;
                }
                break;
            case AiStates.dead:
                
                gameObject.SetActive(false);
                break;
        }
                           

	}
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.GetComponent<BasicAI>().unittype==AI_TYPES.archer&&((gameObject.tag == "Player1units" && other.gameObject.tag == "Player2units") || (gameObject.tag == "Player2units" && other.gameObject.tag == "Player1units")))
        {
            //if the archer is real close then the archer will try to get out of melea range
            if (gameObject.transform.position.x - other.gameObject.transform.position.x < 5)
                ArcherRunAway(gameObject.transform.position, other.gameObject.transform.position);
            else if (gameObject.transform.position.z - other.gameObject.transform.position.z < 5)
                ArcherRunAway(gameObject.transform.position, other.gameObject.transform.position);
        }
        if(gameObject.tag=="Player1units")
        {
            if (other.gameObject.tag == "Player2units")
            {
                currentstate = AiStates.attacking;
                //since only units get here casting data to ai
                BasicAI oposition = other.gameObject.GetComponent<BasicAI>();
                     oposition.currentstate = AiStates.attacking;
                if (unittype == AI_TYPES.calvery && oposition.unittype == AI_TYPES.spearman|| unittype == AI_TYPES.spearman && oposition.unittype == AI_TYPES.archer|| unittype == AI_TYPES.archer && oposition.unittype == AI_TYPES.calvery)
                    weaponAdvantage = true;
                    }
        }
        if (gameObject.tag == "Player2units")
        {
            if (other.gameObject.tag == "Player1units")
            {
                currentstate = AiStates.attacking;
                //since only units get here casting data to ai
                BasicAI oposition = other.gameObject.GetComponent<BasicAI>();
                oposition.currentstate = AiStates.attacking;
                if (unittype == AI_TYPES.calvery && oposition.unittype == AI_TYPES.spearman || unittype == AI_TYPES.spearman && oposition.unittype == AI_TYPES.archer || unittype == AI_TYPES.archer && oposition.unittype == AI_TYPES.calvery)
                    weaponAdvantage = true;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        
        if (gameObject.tag == "Player1units" && attackStarted==false)
        {
            if (other.gameObject.tag == "Player2units")
            {
                if (currentstate == AiStates.attacking)
                    if (!attackStarted)
                    {
                        StartCoroutine(AttackProcess());
                        other.GetComponent<BasicAI>().StartCoroutine(AttackProcess());
                        attackStarted = true;
                    }
                currentstate = AiStates.attacking;
            }
        }
        if (gameObject.tag == "Player2units"&& attackStarted==false)
        {
            if (other.gameObject.tag == "Player1units")
            {
                if (currentstate == AiStates.attacking)
                    if (!attackStarted)
                    {
                        StartCoroutine(AttackProcess());
                        other.GetComponent<BasicAI>().StartCoroutine(AttackProcess());
                        attackStarted = true;
                    }
                currentstate = AiStates.attacking;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(currentstate==AiStates.attacking)
        currentstate = AiStates.idle;
        weaponAdvantage = false;
    }
    void Destroy()
    {
        DestroyObject(gameObject);
    }
    void ArcherRunAway(Vector3 archer, Vector3 enemy)
    {
        Vector3 enemyPostion = archer - enemy;
        enemyPostion.y = 1;
        movementScript.UnitSpeed = 1.25f*Time.deltaTime;
        movementScript.CmdScrPlayerSetDestination(enemyPostion + new Vector3(5, 0, 5));
    }
    IEnumerator AttackProcess()
    {
        
        int random = Random.Range(0, 101);
        //makeing sure that theres a good chance to hit
        if ((unittype == AI_TYPES.archer && random > 66) || unittype != AI_TYPES.archer)
        {
            //unit has adventage double damage
            if (weaponAdvantage)
                currentHealth -= ENEMY_DAMAGE;
            currentHealth -= ENEMY_DAMAGE;
        
        Debug.Log("!!!DMG!!!");
        }
        currentstate = AiStates.attacking;
        yield return new WaitForSeconds(ENEMY_ATTACK_SPEED);

        attackStarted = false;
    }
}
