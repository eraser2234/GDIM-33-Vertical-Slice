using UnityEngine;

namespace ForestBackgroundsPixelArt
{
    public class ParallaxEffect : MonoBehaviour
    {
        private Transform mainCamera;
        private Transform player;

        public float parallaxIntensityX;
        public float parallaxIntensityY;
        public float independantSpeed;

        private float cameraSize;
        private float spriteWidth;
        private Vector2 initialPos;
        private float translationOffset = 0;

        private void Start()
        {
            mainCamera = Camera.main.transform;
            cameraSize = Camera.main.orthographicSize;
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x / 3;

            initialPos = transform.position;
        }

        private void LateUpdate()
        {
            translationOffset += independantSpeed * Time.deltaTime * parallaxIntensityX;

            float parallaxOffsetX = (mainCamera.position.x * (1 - (parallaxIntensityX / 2))) + translationOffset;

            transform.position = new Vector2(
                initialPos.x + parallaxOffsetX,
                initialPos.y
            );

            float cameraOffsetX = mainCamera.position.x - transform.position.x;

            if (cameraOffsetX > spriteWidth / 2)
                initialPos.x += spriteWidth;
            else if (cameraOffsetX < -spriteWidth / 2)
                initialPos.x -= spriteWidth;
        }
    }
}

