using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject m_BulletPrefab;
    [SerializeField] private float m_ForceBullet; 
    [SerializeField] private Vector3 Offset;
    private float time = 0;
    private bool isFinished = false;

    void Update()
    {
        if(!isFinished){
            time = time + Time.deltaTime;
            if(time>=1){
                FindObjectOfType<GameManager>().OutputReady();
            }

            if(Input.GetKeyDown(KeyCode.Space) && time>=1)
            {
                time = 0;
                GameObject bullet = Instantiate(m_BulletPrefab,transform.position + Offset,Quaternion.identity,transform);
                AudioManager.instance.Play("LaserGun");
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * m_ForceBullet);
                FindObjectOfType<GameManager>().OutputCooldown();
            }
        }
        
    }
    public void FinishGame(){
        isFinished = true;
    }
}
