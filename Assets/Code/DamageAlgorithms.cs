using UnityEngine;
using System.Collections;

public class DamageAlgorithms : MonoBehaviour
{


    public static int DamageCalculation(int pow, int def, int atk, float elem)
    {
        float damage = 
            5 * Mathf.Sqrt(pow / def * atk) * elem * Random.Range(0.95f, 1.05f);
        int finalDmg = (int)Mathf.Round(damage);

        return finalDmg;
    }
}
