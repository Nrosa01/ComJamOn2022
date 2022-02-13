using UnityEngine;

[CreateAssetMenu(menuName = "Question System/Profes", fileName ="ProfesText")]
public class TextBlockAsset : ScriptableObject
{
    public string GetAsignatura(int asignatura)
    {
        if (asignatura >= textos.Length) return "No deberias estar viendo esto";
        else return textos[asignatura];
    }

    [SerializeField] private string[] textos;
}
