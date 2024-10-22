using System.Collections;
using System.Collections.Generic;
using Myd.Platform;
using UnityEngine;

public class ParallaxGround : MonoBehaviour
{
    void Start()
    {
        cameraTransform = Camera.main.transform;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeX = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Update()
    {
        float deltaMoveX = cameraTransform.position.x - lastFrameCameraPos.x;
        float deltaMoveY = cameraTransform.position.y - lastFrameCameraPos.y;
        transform.position = transform.position + new Vector3(deltaMoveX * parallaxFactor.x, deltaMoveY * parallaxFactor.y, 0);
        lastFrameCameraPos = cameraTransform.position;
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            transform.position = new Vector3(cameraTransform.position.x, transform.position.y);
        }
    }
    private Transform cameraTransform;
    private Vector3 lastFrameCameraPos;
    private float textureUnitSizeX;
    [SerializeField] private Vector2 parallaxFactor;
}
