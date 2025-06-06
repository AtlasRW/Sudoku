using System.Collections;
using UnityEngine.TestTools;

public class NewTestScript
{
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        yield return null;
    }
}
