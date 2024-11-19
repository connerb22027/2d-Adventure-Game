using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{  
       
   public InputAction moveAction;

       Rigidbody2D  rigidbody2d;
       Vector2 move;
   
    // Start is called before the first frame update
    void Start()
    {
       moveAction.Enable();
       rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
      Debug.Log(move);
        

        Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
         transform.position = position;
    }
    void FixedUpdate()
    { 
      Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
      rigidbody2d.MovePosition(position);
    }

}
