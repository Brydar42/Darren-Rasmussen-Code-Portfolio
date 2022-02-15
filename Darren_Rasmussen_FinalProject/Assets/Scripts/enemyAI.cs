using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyAI : MonoBehaviour {
    public Rigidbody rigidBody;
    public float TotalHealth=100;
    public float currentHealth = 100;
    public Image healthBarFill;
    public GameObject Player;
    public NavMeshAgent agent;
    public Animator animator;
    public GameObject WanderTarget;
    public GameObject WanderCenter;
    public DetectionSphereScript detectionSphere;
    public AttackArea attackarea;
    float wanderangleto;
    float turnspead = 30;
    bool createJitter = false;
    const float wanderspeed = 3;
    const float seekSpeed = 5;
    public GameObject Model;
    bool IsAlive = true;
    public GameObject Pickup;
    Coroutine JitterCoroutine;
    public enum AISTATE
    {
        Attack,
        Wander,
        PickupLance,
        Seek,
        Death
    }
    public AISTATE currAIState = AISTATE.Wander;
    // Use this for initialization
    void Start () {
	
	}
    public void enemyHit(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, TotalHealth);
        healthBarFill.fillAmount = currentHealth / TotalHealth;
        if (currentHealth <= 0)
            SwitchState(AISTATE.Death);
    }
	// Update is called once per frame
	void Update () {
        Vector3 pos = gameObject.transform.position;
        if (pos.y!= -0.765f)
        { pos.y = -0.765f; }
        
        switch(currAIState)
        {
            case AISTATE.Wander:
                Wander();
                break;
            case AISTATE.Seek:
                Seek();
                break;
            case AISTATE.PickupLance:
                pickuplance();
                break;
            case AISTATE.Attack:
                Attack();
                break;
            case AISTATE.Death:
                if(IsAlive)
                Death();
                break;
        }
            
	}
    void Seek()
    {
        if(agent.enabled)
        agent.SetDestination(Player.transform.position);
        FaceAngle();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (currAIState == AISTATE.Wander)
        {
            if (JitterCoroutine != null)
                StopCoroutine(JitterCoroutine);
            createJitter = true;
            ImmediateJitter(90);
        }
        if (collider.gameObject.layer == LayerMask.NameToLayer("till"))
        {
            Vector3 pos = gameObject.transform.position;
            pos.x -= 1;
        }

    }
    void pickuplance()
    {
        if (agent.enabled)
            agent.SetDestination(Player.transform.position);
    }
    void ImmediateJitter(float angle)
    {
        wanderangleto += (Random.Range(0,2)==0)? angle: -angle;
        createJitter = false;
    }
    void Attack()
    {
        if(agent.enabled)
        {
            agent.SetDestination(Player.transform.position);
            FaceAngle();
        }
    }
    void Death()
    {
        IsAlive = false;
        
        animator.SetBool("IsDead", true);
        detectionSphere.gameObject.SetActive(false);
        attackarea.gameObject.SetActive(false);
        StartCoroutine(RemoveEnemy());
    }
    void Wander()
    {
        if(!createJitter)
        {
            JitterCoroutine = StartCoroutine(Jitter(5));
            createJitter = true;
        }
        
        Vector3 direction = WanderTarget.transform.position - WanderCenter.transform.position;
        float angle= Mathf.Atan2(direction.z,direction.x)*Mathf.Rad2Deg;
        //Debug.Log(angle);
       float deltaAngle=  Mathf.DeltaAngle(wanderangleto,angle);
       if (Mathf.Abs(deltaAngle)<turnspead*Time.deltaTime)
        {
           // Debug.Log("Target reached");
        }
        else
        {
            if (deltaAngle < 0)
                WanderTarget.transform.RotateAround(WanderCenter.transform.position, Vector3.up, -turnspead * Time.deltaTime);
            else
                WanderTarget.transform.RotateAround(WanderCenter.transform.position, Vector3.up, turnspead * Time.deltaTime);
        }

        Vector3 dictotarget = WanderTarget.transform.position - Model.transform.position;

        Vector3 dicwithoutY = new Vector3(dictotarget.x, 0, dictotarget.z);

        dicwithoutY.Normalize();

        Vector3 withGravity = new Vector3(dicwithoutY.x*wanderspeed, rigidBody.velocity.y, dicwithoutY.z*wanderspeed);

        rigidBody.velocity = withGravity;

        //rotate to face
        Quaternion rotationToFace = Quaternion.LookRotation(dicwithoutY, Vector3.up);

        Model.transform.rotation = rotationToFace;
    }
    public void SwitchState(AISTATE NextState)
    {
        Debug.Log("switching to " + NextState);
        switch (NextState)
        {
            case AISTATE.Wander:
                agent.enabled=false;
                break;
            case AISTATE.Seek:
                agent.enabled = true;
                agent.Resume();
                break;
            case AISTATE.Attack:
                agent.enabled = true;
                agent.Resume();
                break;
            case AISTATE.Death:
                if (IsAlive)
                    agent.enabled = false;
                    
                break;
        }
        currAIState = NextState;
    }
    void FaceAngle()
    {
        Quaternion rot = Model.transform.localRotation;
        Model.transform.localRotation = Quaternion.Slerp(rot, Quaternion.identity, 0.2f);
    }
    IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("WIN");
    }
    IEnumerator Jitter(float time)
    {
        WaitForSeconds waitForSecods = new WaitForSeconds(time);
        yield return waitForSecods;
        wanderangleto -= Random.Range(-5,6)*10f;
        //Debug.Log("Adding Jitter");
        createJitter = false;
    }
}
