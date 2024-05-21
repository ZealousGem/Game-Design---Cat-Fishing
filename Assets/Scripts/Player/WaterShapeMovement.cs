using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class WaterShapeMovement : MonoBehaviour
{

    public GameObject Waterpoint;
    public GameObject WaterpointPrefab;

    // Start is called before the first frame update
    public float springStiffness = 0.1f;
    public float dampening = 0.03f;
    public float spread = 0.006f;
    private List<WaterSpring> waterSpringList = new();
    public int cornerCounter = 2;
    public SpriteShapeController controller;
    public int waves = 6;


    // Update is called once per frame
    private void Start()
    {
        setWaves();
      
    }
    private void FixedUpdate()
    {
        foreach(WaterSpring waterSpringCompoent in waterSpringList)
        {
            waterSpringCompoent.SpringUpdate(springStiffness, dampening);
            waterSpringCompoent.WavePointUpdate();
        }

        UpdateSprings();
    }

    public void UpdateSprings()
    {
        int count = waterSpringList.Count;
        float[] left_delts = new float[count];
        float[] right_delts = new float[count];

        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                left_delts[i] = spread * (waterSpringList[i].height - waterSpringList[i -1].height);
                waterSpringList[i - 1].velocity += left_delts[i];
            }

            if (i < waterSpringList.Count - 1)
            {
                right_delts[i] = spread * (waterSpringList[i].height - waterSpringList[i+1].height);
                waterSpringList[i - 1].velocity += right_delts[i];
            }
        }
    }

    private void Splashing(int index, float speed)
    {
        if (index >= 0 && index < waterSpringList.Count)
        {
            waterSpringList[index].velocity += speed;
        }
    }

    private void setWaves()
    {
        Spline waterSpline =  controller.spline;
        int waterpointcounter = waterSpline.GetPointCount();

        for (int i = cornerCounter; i < waterpointcounter - cornerCounter; i++)
        {
            waterSpline.RemovePointAt(cornerCounter);
        }

        Vector3 watertopleftCounter = waterSpline.GetPosition(1);
        Vector3 watertoprightCounter = waterSpline.GetPosition(2);
        float waterWidth = watertoprightCounter.x - watertopleftCounter.x;

        float SpacingPerWave = waterWidth / (waves+1);

        for (int i = waves; i > 0; i--)
        {
            int index = cornerCounter;
            float xpos = watertopleftCounter.x + (SpacingPerWave*i);
            Vector3 wavePoint = new Vector3(xpos, watertopleftCounter.y, watertopleftCounter.z);
            waterSpline.InsertPointAt(index, wavePoint);
            waterSpline.SetHeight(index, 0.1f);
            waterSpline.SetCorner(index, false);
            Debug.Log("work");
           // CreateSprings(waterSpline);
        }
    }

    private void CreateSprings(Spline waterSpline)
    {
        waterSpringList = new();
        for (int i = 0; i <= waves+1; i++)
        {
            int index = i + 1;
            GameObject wavePoint = Instantiate(WaterpointPrefab, Waterpoint.transform, false);
            wavePoint.transform.localPosition = waterSpline.GetPosition(index);
            WaterSpring waterSpring = wavePoint.GetComponent<WaterSpring>();
            waterSpring.Init(controller);
            Splashing(5, 1f);
            waterSpringList.Add( waterSpring ); 
            //    GameObject wavepoint = Instantiate();
        }
    }
}
