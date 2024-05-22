using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem
{
    public event EventHandler OnPointSystemChanged;

    private int poinAmount;
    private int currentPoint = 0;

    public void AddPoin(int poinAmount)
    {
        this.poinAmount = poinAmount;
        currentPoint += this.poinAmount;

        OnPointSystemChanged.Invoke(this, EventArgs.Empty);
    }

    public int GetCurrenttPoint()
    {
        return currentPoint;
    }
}
