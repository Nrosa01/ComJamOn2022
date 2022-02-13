using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextMesh : MonoBehaviour
{
    TMPro.TextMeshProUGUI mText;
    Result result;
    [SerializeField] TextBlockAsset profesText;

    // Start is called before the first frame update
    void Start()
    {
        result = FindObjectOfType<Result>();

        mText = this.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        Debug.Log("Time :" + result.TotalTime);

        int mins = (int)result.TotalTime/ 60;
        int secs = (int)result.TotalTime % 60;

        int creditos = (((int)result.TotalTime - 20) / 10) * 6; 

        mText.text = ("Tus apuntes han durado " + mins + ":" + secs.ToString().PadLeft(2, '0') + "\nTus creditos son " + creditos);

        string deathMessage = profesText.GetAsignatura(creditos / 6); ;

        //switch(creditos/6)
        //{
        //    case 1:
        //        deathMessage = "Un fracaso mecánico, dinámico y estético. Incluso Diseño de Videojuegos fue demasiado para ti.";
        //        break;
        //    case 2:
        //        deathMessage = "Eres el complemento a dos de la miseria. Fundamentos de Computadores rompió tus sueños.";
        //        break;
        //    case 3:
        //        deathMessage = "La programación es un arte, y tú no eres ningún artista. Fundamentos de la Programación I se mostró implacable.";
        //        break;
        //    case 4:
        //        deathMessage = "Ojalá esta asignatura viniese más tarde con contenido más relevante. Motores de Videojuegos acabó con tu paciencia.";
        //        break;
        //    case 5:
        //        deathMessage = "No mires su canal de youtube. Matemática Discreta no fue como ningún videojuego que hayas jugado.";
        //        break;
        //    case 6:
        //        deathMessage = "Tu organización es un desastre. Las Métodologías Ágiles de Producción requieren más de ti.";
        //        break;
        //    case 7:
        //        deathMessage = "¿Métodos Matemáticos? ¿Quién metió tantas matemáticas en mi carrera de maquinitas?";
        //        break;
        //    case 8:
        //        deathMessage = "¿Te duele el culo? Esos bancos de Fundamentos de Color y Composición han cobrado muchas víctimas.";
        //        break;
        //    case 9:
        //        deathMessage = "Aprobar esta carrera requiere aguante. Fundamentos de la Programación II fue un fundamento más del que podías tolerar.";
        //        break;
        //    case 10:
        //        deathMessage = "Da igual lo bien que sé te de vomitar teoría. Si no tienes ética laboral, Proyectos I estará siempre fuera de tu alcance.";
        //        break;
        //    default:
        //        deathMessage = "Dejaste la carrera para hacer algo mejor con tu vida. Quizá te fuiste a vivir en un campo, rodeado de flores.";
        //        break;
        //}

        Destroy(result.gameObject);
    }
}
