using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsStatus : MonoBehaviour
{
    public UnityEngine.UI.Text textComponent; 
    private int _points;
    
    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = _points.ToString();
    }

    public void AddPoints(int numberOfPoints)
    {
        _points += numberOfPoints;
    }
}
