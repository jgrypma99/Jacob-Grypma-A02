using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerTopDown : MonoBehaviour
{
    public float movSpeed;
    float speedX;
    float speedY;
    public Rigidbody2D rb;
    public GameObject Inventory;
    bool isInventoryOpen;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Inventory = GameObject.Find("Inventory");
        //Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        //open inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory.SetActive(true);
        }

    }
}
