using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public int playerLives = 3;
    public TextMeshProUGUI lifesAmount;
    
    public CharacterController m_Player;

    private float pushFroce = 2;

    public GameObject heartIcon1;
    public GameObject heartIcon2;
    public GameObject heartIcon3;
    public GameObject heartIcon4;
    public GameObject heartIcon5;

    public TextMeshProUGUI deathMessageUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        deathMessageUI.enabled = false;
        lifesAmount.text = "x0";
        //healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage, Transform enemyLocation)
    {
        applyForceToPlayer(enemyLocation);
        currentHealth -= damage;

      switch (currentHealth)
      {
        case 5:
            Debug.Log("5 Health");
            break;
        case 4:
            heartIcon5.SetActive(false);
            break;
        case 3:
            heartIcon5.SetActive(false);
            heartIcon4.SetActive(false);
            break;
        case 2:
            heartIcon5.SetActive(false);
            heartIcon4.SetActive(false);
            heartIcon3.SetActive(false);
            break;
        case 1:
            heartIcon5.SetActive(false);
            heartIcon4.SetActive(false);
            heartIcon3.SetActive(false);
            heartIcon2.SetActive(false);
            break;
        default:
            heartIcon5.SetActive(false);
            heartIcon4.SetActive(false);
            heartIcon3.SetActive(false);
            heartIcon2.SetActive(false);
            heartIcon1.SetActive(false);
            playerDie();
            break;
      }
    }

    public void applyForceToPlayer(Transform enemyLocation)
    {    
        Vector3 dir = enemyLocation.position - transform.position;  // Calculate Angle Between the collision point and the player

        m_Player.Move(-dir.normalized * pushFroce);
    }

    public void playerDie()
    {
        this.gameObject.SetActive(false);
        deathMessageUI.enabled = true;
    }

    public void playerRespawn()
    {
        this.gameObject.SetActive(true);
        deathMessageUI.enabled = false;
    }

}
