using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedLine : MonoBehaviour
{
    public LineRenderer l1;
    public EdgeCollider2D e1;
    public float pointDistance1 = 0.1f;

    List<Vector2> p1;

    public void UpdateLine1(Vector2 pos, bool isRed)
    {
        if (p1 == null)
        {
            p1 = new List<Vector2>();
            SetPoint1(pos, isRed);
            return;
        }

        SetPoint1(pos, isRed);
    }

    void SetPoint1(Vector2 pos1, bool isRed)
    {
        p1.Add(pos1);

        l1.positionCount = p1.Count;
        l1.SetPosition(p1.Count - 1, pos1);
        

        if (!isRed)
        {
            return;
        }

        if(p1.Count > 1)
            e1.points = p1.ToArray();
    }
}
