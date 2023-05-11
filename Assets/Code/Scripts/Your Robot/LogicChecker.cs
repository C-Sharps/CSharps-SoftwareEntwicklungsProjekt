using System;
using TMPro;
using UnityEngine;
using RoslynCSharp;
using UnityEngine.UI;
using GameObject = UnityEngine.GameObject;

public class LogicChecker : MonoBehaviour
{
    public AssemblyReferenceAsset[] assemblyReferences;
    private ScriptDomain _domain = null;
    public GameObject robot;
    public TMP_InputField source;

    private void Start()
    {
        // Create the domain
        _domain = ScriptDomain.CreateDomain("YourRobotCode", true);
        
        // Import the needed references
        foreach (AssemblyReferenceAsset reference in assemblyReferences)
            _domain.RoslynCompilerService.ReferenceAssemblies.Add(reference);
        
        
    }

    public void Execute()
    {
        ScriptType type = _domain.CompileAndLoadMainSource(source.text);
        ScriptProxy proxy = type.CreateInstance(gameObject);
        proxy.Call("Start");
    }
}


