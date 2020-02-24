using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;

        private Vector2 movement = Vector2.zero;
        private bool flipX;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            GetInput();
            Flip();
            Animation();
        }

        private void GetInput()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }

        private void Flip()
        {
            if (movement.x != 0)
            {
                flipX = (movement.x > 0) ? false : true;
            }
            spriteRenderer.flipX = flipX;
        }

        private void Animation()
        {
            animator.SetFloat("Velocity", movement.magnitude);
        }

        private void FixedUpdate()
        {
            Move(movement * moveSpeed * Time.fixedDeltaTime);
        }

        private void Move(Vector2 direction)
        {
            rb.MovePosition(rb.position + direction);
        }

    }
}
