namespace TestProject1Spoon.Demo.Application.Tests;

using System.Reflection;

public static class ClassType
{
    public static Type GetClassType(string className)
    {
           
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (Assembly assembly in assemblies)
        {
            Type classType = assembly.GetTypes().FirstOrDefault(t => t.Name == className);

            if (classType != null)
                return classType;
        }

        return null;
    }
}