using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed=1f;
    private Rigidbody2D m_PlayerRB2D;
    private Animator animator;
    private Vector3 respawnPoint;
    private bool isRespawning;
    public int Lives;
    private bool isPlayerDead = false;
    private bool isFinished = false;
    private bool PlayerWon = false;
    
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        m_PlayerRB2D = gameObject.GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        Lives = 3;
    }
    private void Update()
    {
        if(!isFinished){
            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            if (inputHorizontal > 0) 
            {
                m_PlayerRB2D.velocity = new Vector2 (m_Speed, m_PlayerRB2D.velocity.y);
            }
            else if(inputHorizontal < 0)
            {
                m_PlayerRB2D.velocity = new Vector2(-m_Speed, m_PlayerRB2D.velocity.y);
            }
            else 
            {
                m_PlayerRB2D.velocity = new Vector2(0, m_PlayerRB2D.velocity.y);
            }

            if (inputVertical > 0) 
            {
                m_PlayerRB2D.velocity = new Vector2 (m_PlayerRB2D.velocity.x, m_Speed);
            }
            else if(inputVertical < 0)
            {
                m_PlayerRB2D.velocity = new Vector2(m_PlayerRB2D.velocity.x, -m_Speed);
            }
            else 
            {
                m_PlayerRB2D.velocity = new Vector2(m_PlayerRB2D.velocity.x, 0);
            }
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Respawning") && isRespawning == true){
                animator.SetBool("isRespawning", false);
                isRespawning = false;
            }
        }else if(isPlayerDead){
            Destroy(this.gameObject);
             AudioManager.instance.Play("GameOver");

        }else if(!PlayerWon){
            AudioManager.instance.Play("Victory");
            PlayerWon = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll) {
        // vaghti ba dota enemy hamzaman collision darim as lives 2ta kam mishe.
		if (coll.gameObject.tag == "Enemy") { 
            Lives = Lives - 1;
            FindObjectOfType<GameManager>().OutputLives();
            if (Lives > 0){
                transform.position = respawnPoint;
                AudioManager.instance.Play("Respawning");
                animator.SetBool("isRespawning", true);
                isRespawning = true;
            }else{
                isPlayerDead = true;
            }
        }
	}
    public void FinishGame(){
        isFinished = true;
        m_PlayerRB2D.velocity = new Vector2(0, 0);
    }
}

