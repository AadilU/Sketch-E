using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer l;
    public EdgeCollider2D e;
    public float pointDistance = 0.1f;

    List<Vector2> p;

    public void UpdateLine(Vector2 pos, bool isRed)
    {
        if (p == null)
        {
            p = new List<Vector2>();
            SetPoint(pos, isRed);
            return;
        }

        if (Vector2.Distance(p.Last(), pos) > pointDistance)
        {
            SetPoint(pos, isRed);
        }
    }

    void SetPoint(Vector2 pos1, bool isRed)
    {
        p.Add(pos1);

        l.positionCount = p.Count;
        l.SetPosition(p.Count - 1, pos1);
        

        if (!isRed)
        {
            return;
        }

        if(p.Count > 1)
            e.points = p.ToArray();
    }

    public void lvl12UpdateLine(Vector2 pos, bool isRed)
    {
        if (p == null)
        {
            p = new List<Vector2>();
            SetPoint(pos, isRed);
            return;
        }
            SetPoint(pos, isRed);
    }
}
