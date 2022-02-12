using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextMesh : MonoBehaviour
{
    TMPro.TextMeshProUGUI mText;
    Result result;

    // Start is called before the first frame update
    void Start()
    {
        result = FindObjectOfType<Result>();

        mText = this.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        Debug.Log("Time :" + result.TotalTime);

        int mins = (int)result.TotalTime / 60;
        int secs = (int)result.TotalTime % 60;

        mText.text = ("Tus apuntes han durado " + mins + ":" + secs);

        Destroy(result.gameObject);
    }
}
