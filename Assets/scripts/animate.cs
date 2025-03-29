using UnityEngine;
using UnityEngine.UI;

public class UIAnimatedSprite : MonoBehaviour
{
    public Sprite[] frames;  // Array de sprites para la animación
    public float frameRate = 0.1f;  // Tiempo entre frames

    private Image image;
    private int currentFrame;
    private float timer;

    void Start()
    {
        image = GetComponent<Image>();  // Obtiene la referencia al Image
        currentFrame = 0;
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer = 0;
            currentFrame = (currentFrame + 1) % frames.Length;
            image.sprite = frames[currentFrame];  // Cambia el sprite
        }
    }
}
