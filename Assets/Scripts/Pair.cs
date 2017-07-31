using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pair<T, U>
{
    /// <summary>
    /// 2オブジェクトのペアを作成します。
    /// </summary>
    public Pair()
    {
        First = default(T);
        Second = default(U);
    }

    /// <summary>
    /// 2オブジェクトのペアを作成します。
    /// </summary>
    /// <param name="first">最初のオブジェクト</param>
    /// <param name="second">2つ目のオブジェクト</param>
    public Pair(T first, U second)
    {
        First = first;
        Second = second;
    }

    /// <summary>
    /// 2オブジェクトの値を設定します。
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    public void Set(T first, U second)
    {
        First = first;
        Second = second;
    }

    public T First { get; private set; }
    public U Second { get; private set; }
}