using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageAnimation : MonoBehaviour
{
    [SerializeField]Sprite[] sprites;
    [Min(0.1f)][SerializeField] float delayBetweenFrames;

    Image image;
    float timer = 0;
    int currentSprite = 0;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if(timer > delayBetweenFrames)
        {
            timer -= delayBetweenFrames;
            image.sprite = sprites[currentSprite];
            currentSprite++;
            if (currentSprite >= sprites.Length) currentSprite = 0;
        }

        timer += Time.deltaTime;
    }
}
