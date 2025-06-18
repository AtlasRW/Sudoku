using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace System.Runtime.CompilerServices { internal static class IsExternalInit { } }

public abstract class BaseTests
{
    public void Log(object message) => Debug.Log(message);
    public int RangeLength(int from, int to) => to - from switch { 0 => -1, 1 => 0, _ => from - 1 };
}
