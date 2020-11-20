using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        private const string NAMESPACE = "Stealer";
        public string StealFieldInfo(string investigateClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(NAMESPACE + "." + investigateClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);


            StringBuilder sb = new StringBuilder();

            
            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {NAMESPACE + "." + investigateClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(NAMESPACE + "." + className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);


            StringBuilder sb = new StringBuilder();

            foreach (var field in classFields)
            {
                sb.AppendLine(field.Name + " must be private!");
            }

            foreach (var nonPublicMethod in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine(nonPublicMethod.Name + " have to be public!");
            }

            foreach (var publicMethod in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine(publicMethod.Name + " have to be private!");
            }
            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
