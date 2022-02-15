using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HunterScript : MonoBehaviour {
    float HunterMOVESPEED = 4f;
    SpriteRenderer M_Renderer;
    public GameObject m_target;
    public Text m_distance;
    float distance;
    // Use this for initialization
    void Start () {
        M_Renderer = GetComponent<SpriteRenderer>();
        distance = m_target.transform.position.x - transform.position.x;
        m_distance.text=distance.ToString();
}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = m_target.transform.position - transform.position;
        dir.Normalize();
        transform.position += new Vector3(dir.x * HunterMOVESPEED * Time.deltaTime, dir.y * HunterMOVESPEED * Time.deltaTime, 0);
        if (dir.x > 0)
        {
            M_Renderer.flipX = false;
        }
        else if (dir.x < 0)
        {
            M_Renderer.flipX = true;
        }
        distance = m_target.transform.position.x - transform.position.x;
        m_distance.text = distance.ToString();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            SceneManager.LoadScene("Hunted");
        }

    }
}
