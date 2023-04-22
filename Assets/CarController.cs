using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float MaxSpeed;
        public float RotationSpeed;
        public float SpeedChangeAmount;
    
        public float currentSpeed;
        private Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
    
        // Update is called once per frame
        void Update()
        {
            rb.velocity = transform.forward * currentSpeed;
            transform.Rotate(0, RotationSpeed * Input.GetAxisRaw("Vertical") * Input.GetAxisRaw("Horizontal"), 0);
            
            if (Input.GetAxisRaw("Vertical") != 0 && currentSpeed<MaxSpeed)
            {
                currentSpeed += SpeedChangeAmount;
            }
            else if (Input.GetAxisRaw("Vertical") != 0 && currentSpeed >= MaxSpeed)
            {
                currentSpeed = MaxSpeed;
            }
            else if (currentSpeed <= 0)
            {
                currentSpeed = 0;
            }
            else
            {
                currentSpeed -= SpeedChangeAmount;
            }
        }
}
