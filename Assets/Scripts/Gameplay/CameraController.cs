using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class CameraController : MonoBehaviour
    {
        private enum TypeCamera { Update, FixedUpdate }

        [SerializeField] private Transform target;
        [SerializeField] private float smooth = 5f;
        [SerializeField] private TypeCamera typeCamera;

        private Vector3 offset;

        private void Start()
        {
            if (target != null)
                offset = transform.position - target.position;
        }

        private void Update()
        {
            if (target == null || typeCamera != TypeCamera.Update)
                return;

            transform.position = Vector3.Lerp(transform.position, target.position + offset, smooth * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (target == null || typeCamera != TypeCamera.FixedUpdate)
                return;

            transform.position = Vector3.Lerp(transform.position, target.position + offset, smooth * Time.fixedDeltaTime);

        }
    }
}
