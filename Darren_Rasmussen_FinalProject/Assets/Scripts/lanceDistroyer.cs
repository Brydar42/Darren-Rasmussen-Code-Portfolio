using UnityEngine;
using System.Collections;

public class lanceDistroyer : MonoBehaviour
{
    public GameObject Lance;
    public AudioSource breakingLance;
    public AudioClip lanceBreakSound;
    public ParticleSystem woodSplinters;
    public float damage = 20f;
    public enemyAI enemyAI;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        //player lance
        if (collider.gameObject.layer == LayerMask.NameToLayer("enemy")&&gameObject.layer== LayerMask.NameToLayer("PLance"))
        {
            collider.gameObject.GetComponent<enemyAI>().currentHealth -= damage;
            AudioSource.PlayClipAtPoint(lanceBreakSound, gameObject.transform.position);
            ParticleSystem ps = (ParticleSystem)Instantiate(woodSplinters);
            ps.transform.position = gameObject.transform.position;
            ps.Play();
            Destroy(ps.gameObject, ps.startLifetime);
            gameObject.SetActive(false);
        }
        //enemy lance
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player") && gameObject.layer == LayerMask.NameToLayer("ELance"))
        {
            collider.gameObject.GetComponent<Playercontroler>().currentHealth -= damage;
            AudioSource.PlayClipAtPoint(lanceBreakSound, gameObject.transform.position);
            ParticleSystem ps = (ParticleSystem)Instantiate(woodSplinters);
            ps.transform.position = gameObject.transform.position;
            ps.Play();
            Destroy(ps.gameObject, ps.startLifetime);
            gameObject.SetActive(false);
            enemyAI.SwitchState(enemyAI.AISTATE.PickupLance);
        }
    }
}
