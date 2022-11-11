using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text LivesText;
    public Text CooldownText;
    private int Lives;
    private Animator animator;

    private void Start(){
        Lives = 3;
        GameObject[] Cooldowntxts = GameObject.FindGameObjectsWithTag("CoolDown");
        GameObject Cooldowntxt = Cooldowntxts[0];
        animator = Cooldowntxt.GetComponent<Animator>();
    }
    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0){
            LivesText.text = "Victory!";
            CooldownText.text = "";
            FindObjectOfType<PlayerMovement>().FinishGame();
            FindObjectOfType<Shooter>().FinishGame();

        }
    }
    public void OutputLives()
    {
        if(Lives>0){
            Lives--;
        }

        LivesText.text = Lives.ToString();
        if(Lives==0){
            LivesText.text = "Game Over";
            CooldownText.text = "";
            FindObjectOfType<PlayerMovement>().FinishGame();
            FindObjectOfType<Shooter>().FinishGame();
        }
    }
    public void OutputCooldown()
    {
        animator.SetBool("isReady", false);
        CooldownText.text = "Weapons\nCoolDown!";
        

    }
    public void OutputReady()
    {
        CooldownText.text = "Weapons\nReady!";
        animator.SetBool("isReady", true);
    }
}
   
