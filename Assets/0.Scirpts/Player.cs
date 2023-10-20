using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CapsuleCollider cc;
    public float jumpPower = 5;
    public bool isGround;
    public LayerMask ground;

    private float speed = 3f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * speed);
        isGround = Physics.Raycast(cc.bounds.center, Vector3.down, cc.bounds.extents.z + 0.8f, ground);
        if (Input.GetKey(KeyCode.LeftAlt) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.z, jumpPower);
        }
    }
}
