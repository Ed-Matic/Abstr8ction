using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public float healthBarLength;

    public Texture2D healthBar;

    int foundFriends;

    // Use this for initialization
    void Start ()
    {
        healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        AdjustCurrentHealth(0);
    }

    //Drawing the Health Bar GUI on the Screen
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, healthBarLength, 20), healthBar);
        GUI.Box(new Rect(10, 10, healthBarLength, 20), "Player Health:  " + currentHealth + "/" + maxHealth);

        GUI.Box(new Rect(340, 10, (Screen.width / 2) - 80, 40), "Mission: \n Find all four of your friends");


    }

    public void AdjustCurrentHealth(int adj)
    {
        //Adds positive/negative points to the current health bar. either damage or potions
        currentHealth += adj;

        //Making sure the player health does not go below 0 or above 100
        if (currentHealth <= 0)
        {
            //currentHealth = 0;
            Application.LoadLevel(4);
        }

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        //Checking to make sure no max or scaling error
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        //Full length of health bar multiplying it by the percentage of our current health
        healthBarLength = (Screen.width / 2) * (currentHealth / (float)maxHealth);
    }
}
