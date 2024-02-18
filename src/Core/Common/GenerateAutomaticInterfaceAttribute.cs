namespace Rinha.MMXXIV.Q1.Core.Common;

[AttributeUsage(AttributeTargets.Class)]
public class GenerateAutomaticInterfaceAttribute : Attribute
{
    public GenerateAutomaticInterfaceAttribute(string namespaceName = "")
    {
    }
}
