
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static
            | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder builder = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        builder.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return builder.ToString().Trim();
    }
    public string AnalyzeAcessModifiers(string investigatedClass)
    {

        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public);

        MethodInfo[] classPublicMethods = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Public);

        MethodInfo[] classNonPublicMethods = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            stringBuilder.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m =>m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be private!");
        }

        return stringBuilder.ToString().Trim();
    }
    public string RevealPrivateMethods(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);

        MethodInfo[] classMethods = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"All Private Methods of Class: {investigatedClass}")
            .AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            stringBuilder.AppendLine(method.Name);
        }

        return stringBuilder.ToString().Trim();
    }
    public string CollectGettersAndSetters(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);

        MethodInfo[] classMethods = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return stringBuilder.ToString().Trim();
    }
}
