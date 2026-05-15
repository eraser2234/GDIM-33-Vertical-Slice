using UnityEngine;

namespace ForestBackgroundsPixelArt
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rb;

        [SerializeField]
        [Range(2.0f, 8.0f)]
        private float speed = 4.0f;

        [SerializeField]
        [Range(10.0f, 20.0f)]
        private float jumpForce = 16.0f;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }
}

