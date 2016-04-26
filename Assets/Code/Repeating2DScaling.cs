using UnityEngine;
using System.Collections;

public class Repeating2DScaling : MonoBehaviour
{

    private Vector2 currentScale;       //The exact scale of the object at any given frame.
    public Vector2 scale1;      //The first scale of the object. If directly proportional, this one is smaller. If inversly, X is bigger.
    public Vector2 scale2;      //The second scale of the object. If directly proportional, this one is bigger. If inversly, Y is bigger.
    public int framesCount;
    public float animationTimeSeconds;
    private float delta;
    private Vector2 dx;
    private bool upScale = true;
    public bool inverseScaling;     //Check this if X and Y scale inversly.

    // Use this for initialization
    IEnumerator Start ()
    {
        currentScale = scale1;
        delta = animationTimeSeconds / framesCount;
        dx = (scale2 - scale1) / framesCount;

        while (scale1 != scale2)
        {
            if (inverseScaling)
            {
                while (upScale)
                {
                    currentScale += dx;
                    if (currentScale.x < scale2.x || currentScale.y > scale2.y)
                    {
                        upScale = false;
                        currentScale = scale2;
                    }
                    transform.localScale = new Vector3(currentScale.x, currentScale.y, 1.0f);
                    yield return new WaitForSeconds(delta);
                }

                while (!upScale)
                {
                    currentScale -= dx;
                    if (currentScale.x > scale1.x || currentScale.y < scale1.y)
                    {
                        upScale = true;
                        currentScale = scale1;
                    }
                    transform.localScale = currentScale;
                    yield return new WaitForSeconds(delta);
                }
            }
            else
            {
                while (upScale)
                {
                    currentScale += dx;
                    if (currentScale.x > scale2.x || currentScale.y > scale2.y)
                    {
                        upScale = false;
                        currentScale = scale2;
                    }
                    transform.localScale = currentScale;
                    yield return new WaitForSeconds(delta);
                }

                while (!upScale)
                {
                    currentScale -= dx;
                    if (currentScale.x < scale1.x || currentScale.y < scale1.y)
                    {
                        upScale = true;
                        currentScale = scale1;
                    }
                    transform.localScale = currentScale;
                    yield return new WaitForSeconds(delta);
                }
            }
        }
    }
    
    
}
