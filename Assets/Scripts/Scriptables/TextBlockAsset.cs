using UnityEngine;

[CreateAssetMenu(menuName = "Question System/Profes", fileName ="ProfesText")]
public class TextBlockAsset : ScriptableObject
{
    public string GetAsignatura(int asignatura)
    {
        if (asignatura - 1 >= textos.Length) return "No deberias estar viendo esto";
        else return textos[asignatura - 1];
    }

    [SerializeField] private string[] textos;
}
