using UnityEngine;
using UnityEngine.UI;
using RoslynCSharp;

public class ButtonScript : MonoBehaviour
{
    public InputField Script;

    public void ExecuteScript()
    {
        ScriptDomain domain = ScriptDomain.CreateDomain("MyTestDomain", true);
        ScriptType type = domain.CompileAndLoadMainSource(Script.text);
        ScriptProxy proxy = type.CreateInstance(gameObject);

        proxy.Call("Start");
    }
}
