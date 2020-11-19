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
    }
}
