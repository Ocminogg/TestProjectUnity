using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass
{
    public int i;
    public int j;
}

public class MyList
{
    private int[] m_array = new int[4];
    public void Push(int i)
    {

    }
    public void IndexOf(int item)
    {

    }

}

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        short s =0;
        int i =0;
        long l = 0;
        float f = 0;
        double d = 0;

        object o = d;
        double d2 = (double)o;

        i = (int)l;
        l = i;
        TestFunc(ref i);
        Debug.Log(i);


        MyClass mc = new MyClass();
        TestFunc(mc);


        Debug.Log($"short: {short.MinValue} - {short.MaxValue}");
        Debug.Log($"int: {int.MinValue} - {int.MaxValue}");
        Debug.Log($"long: {long.MinValue} - {long.MaxValue}");
        Debug.Log($"float: {float.MinValue} - {float.MaxValue}");
        Debug.Log($"double: {double.MinValue} - {double.MaxValue}");
    }
    public void TestFunc(ref int i)
    {
        i = 10;
        //Debug.Log(i);
    }
    public void TestFunc(MyClass mc)
    {
        mc.i = 1;
        mc.j = 2;
    }
}
