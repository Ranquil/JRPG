using UnityEngine;
using System.Collections;

public class BattleMenuTesting : MonoBehaviour
{

    public float posX;
    public float posY;
    public float sizeX;
    public float sizeY;

    enum Menu    {    NOT_ON, MAIN, SKILL, ITEM, DEFENCE    };
    Menu phase;

    public BattleProcessing battle;
    public Enemy enemy;
    public PlayerStats player;

    // Use this for initialization
    void Start ()
    {
        phase = Menu.MAIN;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    void OnGUI()        //This draws all the buttons in the menu.
    {
        if (phase == Menu.MAIN)     //In the main battle menu.
        {
            if (GUI.Button(new Rect(posX, posY, sizeX, sizeY), "Attack"))
            {
                phase = Menu.NOT_ON;
                AttackButton();
                phase = Menu.MAIN;
            }
        }

    }

    void AttackButton()
    {
        
        Debug.Log("You attacked " + enemy.enemyName + "!");

        StartCoroutine(Wait(1));
        int enemyDamage = DamageAlgorithms.DamageCalculation(player.power, enemy.defence, 10, 1f);
        enemy.hp -= enemyDamage;

        Debug.Log(enemy.enemyName + " took " + enemyDamage + " damage!");
        if (enemy.hp <= 0)
            Debug.Log(enemy.enemyName + " was defeated!");

        StartCoroutine(Wait(2));
    }
}
