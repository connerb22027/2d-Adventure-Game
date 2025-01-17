using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{  
       
   public InputAction moveAction;

       Rigidbody2D  rigidbody2d;
       Vector2 move;

      // Variables related to temporary invincibility
      public float timeInvincible = 2.0f;
      bool isInvincible;
      float damageCooldown;

      // Variables related to animation
      Animator animator;
      Vector2 moveDirection = new Vector2(1,0);
       
        // Variables related to the health system
       public int maxHealth =5;
       public int health { get { return currentHealth; }}
       int currentHealth;
   
    // Start is called before the first frame update
    void Start()
    {
       moveAction.Enable();
       rigidbody2d = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();

        // currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
      //Debug.Log(move);
      if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y,0.0f))
        {
           moveDirection.Set(move.x, move.y);
           moveDirection.Normalize();
        }


     animator.SetFloat("Look X", moveDirection.x);
     animator.SetFloat("Look Y", moveDirection.y);
     animator.SetFloat("Speed", move.magnitude);


        

        Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
         transform.position = position;
    }
    void FixedUpdate()
    { 
      Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
      rigidbody2d.MovePosition(position);
    }
    
    public void ChangeHealth (int amount)
    {
      if (amount < 0)
     {
        if (isInvincible)
        {
           return;
        }
     isInvincible = true;
     damageCooldown = timeInvincible;
     animator.SetTrigger("Hit");
     }

      currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
       Debug.Log(currentHealth + "/" + maxHealth);
    }

}
