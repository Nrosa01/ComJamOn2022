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
        //        deathMessage = "Un fracaso mec�nico, din�mico y est�tico. Incluso Dise�o de Videojuegos fue demasiado para ti.";
        //        break;
        //    case 2:
        //        deathMessage = "Eres el complemento a dos de la miseria. Fundamentos de Computadores rompi� tus sue�os.";
        //        break;
        //    case 3:
        //        deathMessage = "La programaci�n es un arte, y t� no eres ning�n artista. Fundamentos de la Programaci�n I se mostr� implacable.";
        //        break;
        //    case 4:
        //        deathMessage = "Ojal� esta asignatura viniese m�s tarde con contenido m�s relevante. Motores de Videojuegos acab� con tu paciencia.";
        //        break;
        //    case 5:
        //        deathMessage = "No mires su canal de youtube. Matem�tica Discreta no fue como ning�n videojuego que hayas jugado.";
        //        break;
        //    case 6:
        //        deathMessage = "Tu organizaci�n es un desastre. Las M�todolog�as �giles de Producci�n requieren m�s de ti.";
        //        break;
        //    case 7:
        //        deathMessage = "�M�todos Matem�ticos? �Qui�n meti� tantas matem�ticas en mi carrera de maquinitas?";
        //        break;
        //    case 8:
        //        deathMessage = "�Te duele el culo? Esos bancos de Fundamentos de Color y Composici�n han cobrado muchas v�ctimas.";
        //        break;
        //    case 9:
        //        deathMessage = "Aprobar esta carrera requiere aguante. Fundamentos de la Programaci�n II fue un fundamento m�s del que pod�as tolerar.";
        //        break;
        //    case 10:
        //        deathMessage = "Da igual lo bien que s� te de vomitar teor�a. Si no tienes �tica laboral, Proyectos I estar� siempre fuera de tu alcance.";
        //        break;
        //    default:
        //        deathMessage = "Dejaste la carrera para hacer algo mejor con tu vida. Quiz� te fuiste a vivir en un campo, rodeado de flores.";
        //        break;
        //}

        Destroy(result.gameObject);
    }
}
