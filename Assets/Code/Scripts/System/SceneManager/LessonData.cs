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
        public AssemblyReferenceAsset[] assemblyReferences;

        public void Awake()
        {
            lessonClasses = lessonClasses.ConvertAll(Instantiate);
            lessonObjectives = lessonObjectives.ConvertAll(Instantiate);

            if (assemblyReferences.Length > 0)
            {
                domain = ScriptDomain.CreateDomain("LessonCode", true);
                
                foreach (AssemblyReferenceAsset reference in assemblyReferences)
                    domain.RoslynCompilerService.ReferenceAssemblies.Add(reference);
            }
        }
    }
}