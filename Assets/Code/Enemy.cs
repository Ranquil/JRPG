using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    
    public static int enemyId;

    public string enemyName;
    public int hp;
    public int hpMax;
    public int mp;
    public int mpMax;
    public int power;
    public int defence;



    // Use this for initialization
    void Start () {
        hp = hpMax;
        mp = mpMax;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


