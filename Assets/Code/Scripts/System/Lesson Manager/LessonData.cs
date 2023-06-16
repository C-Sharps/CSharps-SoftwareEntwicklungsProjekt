/**
 * Author: Robin Intrieri
 * C-Sharps Software-Entwicklungsprojekt SS 2023
*/
using System.Collections.Generic;
using RoslynCSharp;
using UnityEngine;

namespace Code.Scripts.System.SceneManager
{
    public class LessonData : MonoBehaviour
    {
        public List<LessonClass> lessonClasses = new List<LessonClass>();
        public List<LessonObjective> lessonObjectives = new List<LessonObjective>();
        
        public ScriptDomain domain;
        public AssemblyReferenceAsset[] assemblyReferences = new AssemblyReferenceAsset[3];

        public void Awake()
        {
            lessonClasses = lessonClasses.ConvertAll(Instantiate);
            lessonObjectives = lessonObjectives.ConvertAll(Instantiate);

            assemblyReferences[0] = Resources.Load<AssemblyReferenceAsset>("Assembly/assemblysharp");
            assemblyReferences[1] = Resources.Load<AssemblyReferenceAsset>("Assembly/netstandard");
            assemblyReferences[2] = Resources.Load<AssemblyReferenceAsset>("Assembly/UnityEngine");
            
            if (assemblyReferences.Length > 0)
            {
                domain = ScriptDomain.CreateDomain("LessonCode", true);
                
                foreach (AssemblyReferenceAsset reference in assemblyReferences)
                    domain.RoslynCompilerService.ReferenceAssemblies.Add(reference);
            }
        }
    }
}