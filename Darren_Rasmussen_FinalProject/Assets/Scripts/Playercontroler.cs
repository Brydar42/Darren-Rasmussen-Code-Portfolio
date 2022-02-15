using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Playercontroler : MonoBehaviour {
    const float TotalHealth = 100;
    public float currentHealth = 100;
    public Image healthBarFill;
    public Animator PlayerAnimator;
    public Animator enemyAnimator;
    public Camera PlayerCamra;
    public GameObject Lance;
    public GameObject Shield;
    public GameObject TargetRedicul;
    //public float Punchforce = 20f;
	// Use this for initialization
	void Start () {
	}
	/*void OnCollisionEnter(Collision collision)
    {
        
        ContactPoint[] contacts = collision.contacts;
        if (contacts[0].thisCollider.gameObject.layer == LayerMask.NameToLayer("arm") && contacts[0].otherCollider.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            enemyAI enemy = contacts[0].otherCollider.gameObject.GetComponent<enemyAI>();
            enemy.rigidBody.AddForce(PlayerCamra.transform.forward*Punchforce,ForceMode.Impulse);
        }
            
    }*/
    /*void Shoot()
    {
        Ray ray = new Ray(TargetRedicul.transform.position, TargetRedicul.transform.forward);
        RaycastHit[] hitTargets = Physics.RaycastAll(ray,10);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue, 100);
        if(hitTargets.Length>0)
        {
            for (int i=0; i < hitTargets.Length; i++)
            {
                if (hitTargets[i].collider.gameObject.layer == LayerMask.NameToLayer("enemy"))
                {
                    enemyAI enemy = hitTargets[i].collider.gameObject.GetComponent<enemyAI>();
                    enemy.enemyHit(RifleDamage);
                    //Debug.Log("baam");
                }
            }
        }
    }*/
    void attack()
    {

    }
	// Update is called once per frame
	void Update () {
        currentHealth = Mathf.Clamp(currentHealth, 0, TotalHealth);
        healthBarFill.fillAmount = currentHealth / TotalHealth;
        if (currentHealth <= 0)
            Death();
        if (Input.GetMouseButtonDown(0))
        {
            PlayerAnimator.SetTrigger("Left Trigger");
            attack();
            
        }
        
        
        else if (Input.GetMouseButtonDown(1))
        {
            PlayerAnimator.SetTrigger("Right Trigger");
            //shield
        }
    }
    void Death()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LOSE");
    }
}
