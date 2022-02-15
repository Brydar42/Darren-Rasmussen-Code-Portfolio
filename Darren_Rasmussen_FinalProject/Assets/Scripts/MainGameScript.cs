using UnityEngine;
using System.Collections;

public class MainGameScript : MonoBehaviour {
    //public GameObject[] m_EnemyArray = new GameObject[5];
    public GameObject[] m_BackgroundObjectArray;
    int m_BackgroundIndex = 1;
    float m_BackgroundSize;
    public GameObject m_Player;
    public GameObject[] m_MidGroundObjectsArray;
    const float MID_GROUND_SPEED = 0.005f;
    const float MID_GROUND_OFFSET = 10f;
    int m_MidGroundRightMost = 3;
    int m_MidGroundLeftMost = 0;
    void ParallaxBackground()
    {
        GameObject rightBackground = m_BackgroundObjectArray[m_BackgroundIndex];
        GameObject leftBackground = m_BackgroundObjectArray[(m_BackgroundIndex >= m_BackgroundObjectArray.Length - 1) ? 0 : m_BackgroundIndex + 1];

        if (m_Player.transform.position.x >= rightBackground.transform.position.x)
        {
            if (m_BackgroundIndex < m_BackgroundObjectArray.Length - 1)
                m_BackgroundIndex++;
            else
                m_BackgroundIndex = 0;

            m_BackgroundObjectArray[m_BackgroundIndex].transform.position = new Vector3(rightBackground.transform.position.x + m_BackgroundSize, rightBackground.transform.position.y, 0f);

            //Debug.Log("POSITIONING TO THE RIGHT");

        }
        else if (m_Player.transform.position.x < leftBackground.transform.position.x && m_Player.transform.position.x > 0)
        {
            m_BackgroundObjectArray[m_BackgroundIndex].transform.position = new Vector3(leftBackground.transform.position.x - m_BackgroundSize, rightBackground.transform.position.y, 0f);
            //Debug.Log("POSITIONING TO THE LEFT");

        }
    }
    void FollowCamera()
    {
        if (m_Player.transform.position.x >= 0)
        {
            Vector3 campos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(m_Player.transform.position.x, campos.y, campos.z);
        }
    }
    void MoveMidGround()
    {
        if (m_Player.transform.position.x - m_Player.GetComponent<SpriteRenderer>().bounds.extents.x > PlayerScript.MIN_X_BOUNDS)
        {
            for (int i = 0; i < m_MidGroundObjectsArray.Length; i++)
            {
                Vector3 midPos = m_MidGroundObjectsArray[i].transform.position;

                //This line makes our Midground elements move based on how fast the player is moving
                m_MidGroundObjectsArray[i].transform.position = new Vector3(midPos.x - m_Player.GetComponent<Rigidbody2D>().velocity.x * MID_GROUND_SPEED, midPos.y, midPos.z);

                GameObject midGround = m_MidGroundObjectsArray[i];
                float midGroundExtent = midGround.GetComponent<SpriteRenderer>().bounds.extents.x;

                //Catch mid grounds that are out of the left side of the screen and and place them to the Right
                if (midPos.x + midGroundExtent < m_Player.transform.position.x + PlayerScript.MIN_X_BOUNDS)
                {
                    midGround.transform.position = new Vector3(m_MidGroundObjectsArray[m_MidGroundRightMost].transform.position.x + MID_GROUND_OFFSET, midPos.y, midPos.z);
                    m_MidGroundRightMost = (m_MidGroundRightMost >= m_MidGroundObjectsArray.Length - 1) ? 0 : m_MidGroundRightMost + 1;
                    m_MidGroundLeftMost = (m_MidGroundLeftMost >= m_MidGroundObjectsArray.Length - 1) ? 0 : m_MidGroundLeftMost + 1;
                }
                //Catch mid grounds that are out of the right side of the screen and and place them to the left
                else if (midPos.x - midGroundExtent > m_Player.transform.position.x + PlayerScript.MAX_X_BOUNDS * 3f)
                {
                    midGround.transform.position = new Vector3(m_MidGroundObjectsArray[m_MidGroundLeftMost].transform.position.x - MID_GROUND_OFFSET, midPos.y, midPos.z);

                    m_MidGroundRightMost = (m_MidGroundRightMost <= 0) ? m_MidGroundObjectsArray.Length - 1 : m_MidGroundRightMost - 1;
                    m_MidGroundLeftMost = (m_MidGroundLeftMost <= 0) ? m_MidGroundObjectsArray.Length - 1 : m_MidGroundLeftMost - 1;
                }

            }
        }

    }
    // Use this for initialization
    void Start () {
        m_BackgroundSize = m_BackgroundObjectArray[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update () {
        ParallaxBackground();
        FollowCamera();
        MoveMidGround();
        /*
        for (int i = 0; i < m_EnemyArray.Length; i++)
        {
            GameObject enemy = m_EnemyArray[i];
            Vector3 Dicection=enemy.transform.position-m_Player.transform.position;
            Quaternion lookRot=Quaternion.identity;
            if(m_Player.transform.position.x<enemy.transform.position.x)
            {
                lookRot = Quaternion.LookRotation(Dicection,Vector3.up);
            }
            else
            {
                lookRot = Quaternion.LookRotation(Dicection, Vector3.down);
            }
            lookRot.x=0;
            lookRot.y = 0;
            enemy.transform.rotation = lookRot;
            //enemy.transform.Rotate(0, 0, 20f * Time.deltaTime);
        }
        */
        
    }
}
