using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

    {
    
public float moveSpeed = 1f;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public float mouseSensitivity = 1f;
    public GameObject bullet;
    public Transform FirePoint;
    public Transform theCamera;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    private bool _canPlayerJump;
    private Vector3 _moveInput;

    //private Ammo _ammo;
    private CharacterController _characterController;
    //[SerializedField] private Animator _playerAnimator

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
     
    }

    // Update is called once per frame
    void Update()
    {
        //Player jump setup
        float yVelocity = _moveInput.y;

        //Player movement
        //_moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //_moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 forwardDirection = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalDirection = transform.right * Input.GetAxis("Horizontal");

        _moveInput = (forwardDirection + horizontalDirection).normalized;
        _moveInput *= moveSpeed;

        //Apply Jumping
        _moveInput.y = yVelocity;

        _moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        //Check if character controller is on the ground
        if(_characterController.isGrounded)
        {
            _moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        //Check if player can jump
        _canPlayerJump = Physics.OverlapSphere(groundCheckpoint.position, 0.5f, whatIsGround).Length > 0;

        //Make player jump
        if(Input.GetKeyDown(KeyCode.Space) && _canPlayerJump)
        {
            _moveInput.y = jumpForce;
        }

        _characterController.Move(_moveInput * Time.deltaTime);

        //Camera rotation
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        theCamera.rotation = Quaternion.Euler(theCamera.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        //Handle Shooting
       // if(Input.GetMouseButtonDown(0) && _ammo.GetAmmoAmount() > 0)
        {
            //Find the crosshair
            RaycastHit hit;
            if(Physics.Raycast(theCamera.position, theCamera.forward, out hit, 50f))
            {
                if(Vector3.Distance(theCamera.position, hit.point) > 2f)
                {
                    FirePoint.LookAt(hit.point);
                }
            }
            else
            {
                FirePoint.LookAt(theCamera.position + (theCamera.forward * 30f));
            }

            //Create the bullet
            //Instantiate(bullet, FirePoint.position, FirePoint.rotation);

            //Remove ammo
            //_ammo.RemoveAmmo();
        }
    }
}
