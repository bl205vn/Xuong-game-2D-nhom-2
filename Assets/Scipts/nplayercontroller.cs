using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nplayercontroller : MonoBehaviour
{
    [SerializeField] private float tocdo = 5f;
    [SerializeField] private float nhay = 25f;
    [SerializeField] private float tocdoleo = 10f;
    [SerializeField] private LayerMask matdat;
    [SerializeField] private LayerMask cauthang;
    [SerializeField] private Transform vitriktra;
    [SerializeField] private Transform vtrict;
    [SerializeField] private bool xacthuc;
    [SerializeField] private bool leothang;
    private float gravitystart;
    private Rigidbody2D rb;
    private Animator ani;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gravitystart = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        kiemtract();
        dichuyen();
        Nhay();
        Leoct();
        TanCong();
        nedon();
    }
    private void dichuyen()
    {
        // tao van toc cua nhan vat 
        float moveinput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveinput * tocdo, rb.linearVelocity.y);
        //Lat anh nhan vat.
        if (moveinput > 0) GetComponent<SpriteRenderer>().flipX = false;
        else if (moveinput < 0) GetComponent<SpriteRenderer>().flipX = true;
        // goi animation
        ani.SetTrigger("Run");

    }
    private void Nhay()
    {
        xacthuc = Physics2D.OverlapCircle(vitriktra.position, 1.5f, matdat);
        if (Input.GetButtonDown("Jump") && xacthuc)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, nhay);
            ani.SetTrigger("Jump");
        }
    }
    private void kiemtract()
    {
        if (Physics2D.OverlapCircle(vtrict.position, 0.5f, cauthang))
        {
            leothang = true;
            rb.gravityScale = 0;
        }
        else
        {
            leothang = false;
            rb.gravityScale = gravitystart;
        }
    }
    private void Leoct()
    {
        if (leothang)
        {
            float moveinput = Input.GetAxis("Vertical");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveinput * tocdoleo);
            ani.SetTrigger("climp");
        }
    }
    private void TanCong()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ani.SetTrigger("Attack");
        }
    }
    private void nedon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ani.SetTrigger("Dodge");
        }
    }
}