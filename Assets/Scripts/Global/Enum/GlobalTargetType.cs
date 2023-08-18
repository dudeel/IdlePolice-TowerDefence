using UnityEngine;

public static class GlobalTargetType
{
    public enum Target
    {
        First = 0, // Первая
        Last = 1, // Последняя
        Random = 2, // Случайная
    }

    public static string GetTargetType(Target m_rarity)
    {
        switch (m_rarity)
        {
            case Target.First:
                return "First";
            case Target.Last:
                return "Last";
            case Target.Random:
                return "Random";

            default:
                Debug.LogError("This rarity is not found. Set default = First");
                return "First";
        }
    }
}
