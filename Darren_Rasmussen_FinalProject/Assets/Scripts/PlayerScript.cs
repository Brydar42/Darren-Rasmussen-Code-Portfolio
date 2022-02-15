using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour {
    public static float MIN_X_BOUNDS;
    public static float MAX_X_BOUNDS;
    public AudioSource m_Asource;
    public AudioClip eat;
    public AudioClip coinCollect;
    public PlayerInputScript m_playerInputscript;
    public float totalHealth = 30f, currentHealth = 30f;
    public Image healthBar;
    public Text M_healthCount;
    public 
    void Start () {
        MIN_X_BOUNDS = -(Camera.main.aspect * Camera.main.orthographicSize);
        MAX_X_BOUNDS = Camera.main.aspect * Camera.main.orthographicSize;
        M_healthCount.text = currentHealth.ToString();
        //m_totalCount.text = (PlayerPrefs.GetInt(SaveData.SaveType.TotalCount.ToString())).ToString();
    }

    // Update is called once per frame
    void Update () {
        
        currentHealth = Mathf.Clamp(currentHealth, 0, totalHealth);
        M_healthCount.text = currentHealth.ToString();
        healthBar.fillAmount = currentHealth / totalHealth;
        if (currentHealth <= 0)
        {
            m_playerInputscript.m_Animator.SetBool("IsDead", true);
            SceneManager.LoadScene("GameLose");
        }
        //Rigidbody2D.AddForce((transform.position - hunter.transform.position).normalized * force * rigidbody.mass, ForceMode.Impulse);
    }
   /* public void playerEat()
    {
        m_Asource.PlayOneShot(eat);
    }*/
    public void Playercollect()
    {
        m_Asource.PlayOneShot(coinCollect);
    }
    /*public void SaveTotalCount()
    {
        int TotalSaved = PlayerPrefs.GetInt(SaveData.SaveType.TotalCount.ToString());
        TotalSaved += M_collectcount;
        PlayerPrefs.SetInt(SaveData.SaveType.TotalCount.ToString(), TotalSaved);
        m_totalCount.text = TotalSaved.ToString();
        M_collectcount = 0;
    }*/
}
