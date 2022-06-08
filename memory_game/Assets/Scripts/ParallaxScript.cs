using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float textureUnitSizeX;
    public float parallaxEffect;
    public GameObject camObj;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = spriteRenderer.sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    void Update()
    {
        Vector3 cameraMovement = cameraTransform.position - lastCameraPosition;
        transform.position -= new Vector3(cameraMovement.x *  parallaxEffect, transform.position.y, transform.position.z);
        lastCameraPosition = cameraTransform.position;        
        if (lastCameraPosition.x - transform.position.x >= textureUnitSizeX)
        {
            float offsetPositionX = (lastCameraPosition.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(lastCameraPosition.x + offsetPositionX, transform.position.y, transform.position.z);
        }
    }
}
