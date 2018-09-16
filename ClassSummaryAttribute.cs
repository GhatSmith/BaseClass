#if UNITY_EDITOR
using System.Linq;
#endif


/// <summary> Class comment which can be retrieve by relfection to be dispayed inside inspector </summary>
[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ClassSummaryAttribute : System.Attribute
{
    private string[] comment;


    public ClassSummaryAttribute(params string[] comment)
    {
        this.comment = comment;
    }


#if UNITY_EDITOR
    public static string GetClassSummary(System.Type type)
    {
        ClassSummaryAttribute[] classSummaryAttributes = (type.GetCustomAttributes(typeof(ClassSummaryAttribute), true) as ClassSummaryAttribute[]).ToArray();

        if (classSummaryAttributes == null || classSummaryAttributes.Length == 0) return string.Empty;
        else
        {
            string value = string.Empty;
            for (int i = 0; i < classSummaryAttributes.Length; i++)
            {
                if (i > 0) value += "\n";
                value += string.Join("\n", classSummaryAttributes[i].comment);
            }

            return value;
        }
    }
#endif
}