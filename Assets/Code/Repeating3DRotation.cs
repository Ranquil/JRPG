using UnityEngine;
using System.Collections;

public class Repeating3DRotation : MonoBehaviour
{

    private Vector3 currentAngle;
    public int framesCount;
    public float animationTimeSeconds;
    private float delta;
    private Vector3 dx;
    public bool x;
    public bool y;
    public bool z;
    public bool xCounterClockwise;
    public bool yCounterClockwise;
    public bool zCounterClockwise;

    // Use this for initialization
    void Start()
    {
        delta = animationTimeSeconds / framesCount;
        dx = new Vector3(360, 360, 360) / framesCount;
        StartCoroutine(Rotation());
    }

    IEnumerator Rotation()
    {
        while (animationTimeSeconds > 0)
        {
            if (x && xCounterClockwise)
                currentAngle.x += dx.x;
            else if (x && !xCounterClockwise)
                currentAngle.x -= dx.x;
            if (y && yCounterClockwise)
                currentAngle.y += dx.y;
            else if (y && !yCounterClockwise)
                currentAngle.y -= dx.y;
            if (z && zCounterClockwise)
                currentAngle.z += dx.z;
            else if (z && !zCounterClockwise)
                currentAngle.z -= dx.z;

            if (currentAngle.x >= 360 || currentAngle.x <= -360)
                currentAngle.x = 0.0f;
            if (currentAngle.y >= 360 || currentAngle.y <= -360)
                currentAngle.y = 0.0f;
            if (currentAngle.z >= 360 || currentAngle.z <= -360)
                currentAngle.z = 0.0f;

            transform.rotation = Quaternion.Euler(currentAngle);

            yield return new WaitForSeconds(delta);
        }
    }

}
