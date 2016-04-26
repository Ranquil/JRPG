using UnityEngine;
using System.Collections;

public class Repeating2DMovement : MonoBehaviour
{

    private Vector2 currentPosition;       //The exact position of the object at any given frame.
    public Vector2 position1;      //The first position of the object.
    public Vector2 position2;      //The second position of the object.
    public int framesCount;
    public float animationTimeSeconds;
    private float delta;
    private Vector2 dx;
    private bool upPosition = true;
    public bool inverseMovement;     //Check this if X and Y increase inversely.
    public float z;
    public float waitAtPos1;
    public float waitAtPos2;

    // Use this for initialization
    void Start ()
    {
        currentPosition = position1;
        delta = animationTimeSeconds / framesCount;
        dx = (position2 - position1) / framesCount;

        StartCoroutine(Movement());
	}
	
	
    private IEnumerator Movement()
    {
        while (position1 != position2)
        {
            if (inverseMovement)
            {
                while (upPosition)
                {
                    currentPosition += dx;
                    if (currentPosition.x < position2.x || currentPosition.y > position2.y)
                    {
                        upPosition = false;
                        currentPosition = position2;
                        if (waitAtPos2 > 0)
                            yield return new WaitForSeconds(waitAtPos2);
                    }
                    transform.position = new Vector3(currentPosition.x, currentPosition.y, z);
                    yield return new WaitForSeconds(delta);
                }

                while (!upPosition)
                {
                    currentPosition -= dx;
                    if (currentPosition.x > position1.x || currentPosition.y < position1.y)
                    {
                        upPosition = true;
                        currentPosition = position1;
                        if (waitAtPos1 > 0)
                            yield return new WaitForSeconds(waitAtPos1);
                    }
                    transform.position = new Vector3(currentPosition.x, currentPosition.y, z);
                    yield return new WaitForSeconds(delta);
                }
            }
            else
            {
                while (upPosition)
                {
                    currentPosition += dx;
                    if (currentPosition.x > position2.x || currentPosition.y > position2.y)
                    {
                        upPosition = false;
                        currentPosition = position2;
                        if (waitAtPos2 > 0)
                            yield return new WaitForSeconds(waitAtPos2);
                    }
                    transform.position = new Vector3(currentPosition.x, currentPosition.y, z);
                    yield return new WaitForSeconds(delta);
                }

                while (!upPosition)
                {
                    currentPosition -= dx;
                    if (currentPosition.x < position1.x || currentPosition.y < position1.y)
                    {
                        upPosition = true;
                        currentPosition = position1;
                        if (waitAtPos1 > 0)
                            yield return new WaitForSeconds(waitAtPos1); ;
                    }
                    transform.position = new Vector3(currentPosition.x, currentPosition.y, z);
                    yield return new WaitForSeconds(delta);
                }
            }
        }
    }
    
    
}
