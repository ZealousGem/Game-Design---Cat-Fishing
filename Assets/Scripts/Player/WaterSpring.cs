using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WaterSpring : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity = 0f;
    public float force = 0f;
    public float height = 0f;
    private SpriteShapeController work = null;
    public float target_height = 0f;
    int waveIndex = 0;
    public void Init(SpriteShapeController ss)
    {
        var index = transform.GetSiblingIndex();
        waveIndex = index + 1;
        work = ss;
        velocity = 0;
        height = transform.localPosition.y;
        target_height = transform.localPosition.y;
        
    }
    public void SpringUpdate(float springStiff, float damp)
    {
        height = transform.localPosition.y;
        var x = height - target_height;

        var lost = -damp * velocity;
        Debug.Log("aaah");
        force = -springStiff * x + lost;
        velocity += force;
        var y = transform.localPosition.y;
        transform.localPosition = new Vector3(transform.localPosition.x, y+velocity, transform.localPosition.z);
    }

    // Update is called once per frame
    public void WavePointUpdate()
    {
        if (work != null)
        {
            Spline water = work.spline;
            Vector3 wavePos = water.GetPosition(waveIndex);
            water.SetPosition(waveIndex, new Vector3(wavePos.x, transform.localPosition.y, wavePos.z));
        }
    }
}
