using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Vector2 move;

    Vector2 offset;
    Material material;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset += move * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
