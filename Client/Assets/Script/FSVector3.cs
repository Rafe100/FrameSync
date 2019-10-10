using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public struct FSVector3
{
    FSFloat xValue;
    FSFloat yValue;
    FSFloat zValue;

    public int X {
        get { return xValue.GetValue(); }
    }

    public int Y {
        get { return yValue.GetValue(); }
    }

    public int Z {
        get { return zValue.GetValue(); }
    }

    public FSVector3(int x, int y, int z) {
        xValue = x;
        yValue = y;
        zValue = z;
    }

    public void SetFSVector3(int x, int y, int z) {
        xValue = x;
        yValue = y;
        zValue = z;
    }

    public Vector3 ToVec3() {
        return new Vector3(xValue.ToFloat(), yValue.ToFloat(), zValue.ToFloat());
    }

    public static explicit operator FSVector3(Vector3 v) {
        return new FSVector3((int)v.x, (int)v.y, (int)v.z);
    }

    public static FSVector3 operator+ (FSVector3 v1,FSVector3 v2) {
        v1.SetFSVector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        return v1;
    }

    public static FSVector3 operator*(FSVector3 v,int s) {
        v.SetFSVector3(v.X * s, v.Y * s, v.Z * s);
        return v;
    }

    public static FSVector3 Zero = new FSVector3(0, 0, 0);

    public static bool operator==(FSVector3 v1, FSVector3 v2) {
        return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
    }

    public static bool operator !=(FSVector3 v1, FSVector3 v2) {
        return v1.X != v2.X || v1.Y != v2.Y && v1.Z != v2.Z;
    }

    public static FSVector3 Lerp(FSVector3 a, FSVector3 b, FSFloat f) {
        return new FSVector3(
            (int)(((long)(b.X - a.X) * f.GetValue()) / FSFloat.precision) + a.X,
            (int)(((long)(b.Y - a.Y) * f.GetValue()) / FSFloat.precision) + a.Y,
            (int)(((long)(b.Z - a.Z) * f.GetValue()) / FSFloat.precision) + a.Z);
    }


    public static FSVector3 Lerp(FSVector3 a, FSVector3 b, float f) {
        return new FSVector3(
            (int)(((b.X - a.X) * f)) + a.X,
            (int)(((b.Y - a.Y) * f)) + a.Y,
            (int)(((b.Z - a.Z) * f)) + a.Z);
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        sb.Append("X:").Append(X).Append(" Y:").Append(Y).Append(" Z:").Append(Z);
        return sb.ToString();
    }

}
