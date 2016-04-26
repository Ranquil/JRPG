using UnityEngine;
using System.Collections;

public enum EnemyType
{
    FAIRY = 0,
    TITANIA
};

public class BattleProcessing : MonoBehaviour
{

    public static EnemyType publicEnemy = EnemyType.TITANIA;
    enum BattlePhase
    {
        PLAYER_TURN,
        ENEMY_TURN
    };
    BattlePhase battlePhase;

    
    public Enemy[] enemies;
    public BattleMenuTesting menu;

	// Use this for initialization
	void Start ()
    {
        battlePhase = BattlePhase.PLAYER_TURN;

        Enemy enemy = Instantiate(enemies[(int)publicEnemy], Vector3.zero, Quaternion.identity) as Enemy;
        menu.enemy = enemy;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
