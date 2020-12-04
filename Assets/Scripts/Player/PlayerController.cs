using System.Collections.Generic;
using UnityEngine;

struct Cmd
{
    public float forwardMove;
    public float rightMove;
    public float upMove;
}

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;
    public void Awake()
    {
        instance = this;
    }
    #endregion

    public Transform playerView;
    public GameObject Shuriken;
    public float playerViewYOffset = 0.6f;
    public float xMouseSensitivity = 30.0f;
    public float yMouseSensitivity = 30.0f;

    public float gravity = 20.0f;

    public float friction = 6;

    public int health = 100;

    public float defaultMoveSpeed = 7.0f;
    public float moveSpeed = 7.0f;
    public float crouchSpeed = 4.5f;
    public float runAcceleration = 14.0f;
    public float runDeacceleration = 10.0f;
    public float airAcceleration = 2.0f;
    public float airDecceleration = 2.0f;
    public float airControl = 0.3f;
    public float sideStrafeAcceleration = 50.0f;
    public float sideStrafeSpeed = 1.0f;
    public float jumpSpeed = 8.0f;
    public bool holdJumpToBhop = false;
    public LayerMask layerMask;

    public GUIStyle style;

    public float fpsDisplayRate = 4.0f;

    private int frameCount = 0;
    private float dt = 0.0f;
    private float fps = 0.0f;

    private CharacterController _controller;

    private float rotX = 0.0f;

    [SerializeField]
    private float rotY = 0.0f;

    private Vector3 moveDirectionNorm = Vector3.zero;
    private Vector3 playerVelocity = Vector3.zero;
    private float playerTopVelocity = 0.0f;

    private bool wishJump = false;

    private float playerFriction = 0.0f;

    private Cmd _cmd;

    private float height;
    private bool isCrouched;
    private bool isSliding;
    private bool isJumping;
    private bool haveSlided;

    private GameObject weaponGameObject;
    private List<GameObject> acquiredWeaponList = new List<GameObject>();
    private IRangedWeapon currentWeapon;
    private int currentWeaponIndex;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (playerView == null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
                playerView = mainCamera.gameObject.transform;
        }

        weaponGameObject = GameObject.FindGameObjectWithTag("Weapon");

        playerView.position = new Vector3(
            transform.position.x,
            transform.position.y + playerViewYOffset,
            transform.position.z);

        _controller = GetComponent<CharacterController>();

        height = _controller.height;

        TakeWeapon(Shuriken);
        SelectWeaponByIndex(currentWeaponIndex);
    }

    private void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0 / fpsDisplayRate)
        {
            fps = Mathf.Round(frameCount / dt);
            frameCount = 0;
            dt -= 1.0f / fpsDisplayRate;
        }
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            if (Input.GetButtonDown("Fire1"))
                Cursor.lockState = CursorLockMode.Locked;
        }
        SwitchWeapons();
        if (!GameController.Instance.IsGameOver && health > 0)
        {
            if (currentWeapon != null)
            {
                currentWeapon.Shoot();
            }

            rotX -= Input.GetAxisRaw("Mouse Y") * xMouseSensitivity * 0.02f;
            rotY += Input.GetAxisRaw("Mouse X") * yMouseSensitivity * 0.02f;

            if (rotX < -90)
                rotX = -90;
            else if (rotX > 90)
                rotX = 90;

            this.transform.rotation = Quaternion.Euler(0, rotY, 0);
            playerView.rotation = Quaternion.Euler(rotX, rotY, 0);
            weaponGameObject.transform.rotation = Quaternion.Euler(rotX, rotY, 0);

            Crouch();
            QueueJump();
            if (_controller.isGrounded)
                GroundMove();
            else if (!_controller.isGrounded)
                AirMove();

            _controller.Move(playerVelocity * Time.deltaTime);

            if ((playerVelocity.x != 0 || playerVelocity.z != 0) && OnSlope() && !isJumping)
            {
                _controller.Move(Vector3.down * _controller.height / 2 * 20 * Time.deltaTime);
            }

            if (_controller.isGrounded) isJumping = false;

            Vector3 udp = playerVelocity;
            udp.y = 0.0f;
            if (udp.magnitude > playerTopVelocity)
                playerTopVelocity = udp.magnitude;

            playerView.position = new Vector3(
                transform.position.x,
                transform.position.y + playerViewYOffset,
                transform.position.z);
        }
        else
        {
            GameController.Instance.EndGame(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void TakeWeapon(GameObject weapon)
    {
        foreach (var w in acquiredWeaponList)
        {
            if (w.name.Equals(weapon.gameObject.name))
            {
                return;
            }
        }
        acquiredWeaponList.Add(weapon);
        SelectWeaponByIndex(acquiredWeaponList.IndexOf(weapon));
    }

    private void SelectWeaponByIndex(int index)
    {
        foreach (Transform childObject in weaponGameObject.transform)
        {
            Destroy(childObject.gameObject);
        }

        var instantiatedWeapon = Instantiate(acquiredWeaponList[index], weaponGameObject.transform);
        currentWeapon = instantiatedWeapon.GetComponent<IRangedWeapon>();
        currentWeaponIndex = index;
    }

    public void SwitchWeapons()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeaponIndex = (int)Mathf.Repeat(++currentWeaponIndex, acquiredWeaponList.Count);
            SelectWeaponByIndex(currentWeaponIndex);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeaponIndex = (int)Mathf.Repeat(--currentWeaponIndex, acquiredWeaponList.Count);
            SelectWeaponByIndex(currentWeaponIndex);
        }
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, 100);
        GameUIController.Instance.SetHealthText(health);
    }

    public void Heal(int healing)
    {
        health = Mathf.Clamp(health + healing, 0, 100);
        GameUIController.Instance.SetHealthText(health);
    }

    private void SetMovementDir()
    {
        _cmd.forwardMove = Input.GetAxisRaw("Vertical");
        _cmd.rightMove = Input.GetAxisRaw("Horizontal");
    }

    private bool OnSlope()
    {
        if (isJumping)
            return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, _controller.height / 2 * 5, layerMask))
        {
            if (hit.normal != Vector3.up)
                return true;
        }
        return false;
    }

    private void Slide(Vector3 wishdir, float accel)
    {
        if (Input.GetKey(KeyCode.C) && isCrouched && !isSliding && playerVelocity.magnitude > 5 && !haveSlided)
        {
            isSliding = true;
        }

        if (isSliding)
        {
            if (OnSlope() && IsSlopeDownhill())
            {
                ApplyFriction(0.0f);
                Accelerate(wishdir, playerVelocity.magnitude * 10f, 0.05f);
            }
            else if (OnSlope() && !IsSlopeDownhill())
            {
                ApplyFriction(0.3f);
                if (!haveSlided)
                {
                    Accelerate(wishdir, moveSpeed * 7, moveSpeed * 7);
                    haveSlided = true;
                }

                if (playerVelocity.magnitude <= 4.5f)
                {
                    isSliding = false;
                }
            }
            else
            {
                ApplyFriction(0.1f);
                if (!haveSlided)
                {
                    Accelerate(wishdir, moveSpeed * 7, moveSpeed * 7);
                    haveSlided = true;
                }

                if (playerVelocity.magnitude <= 4.5f)
                {
                    isSliding = false;
                }
            }
        }
    }

    private bool IsSlopeDownhill()
    {
        float slope = 0;
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, .25f, Vector3.down, out hit, 3f))
        {
            slope = Vector3.Dot(transform.right, (Vector3.Cross(Vector3.up, hit.normal)));
        }

        if (slope > 0)
        {
            return true;
        }
        else return false;
    }

    private void Crouch()
    {
        var h = height;

        if (Input.GetKey(KeyCode.C))
        {
            h = 0.5f * height;
            isCrouched = true;
            moveSpeed = crouchSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            isCrouched = false;
            moveSpeed = defaultMoveSpeed;
            isSliding = false;
            haveSlided = false;
            ApplyFriction(1.0f);
        }

        _controller.height = Mathf.Lerp(_controller.height, h, 10 * Time.deltaTime);
    }
    private void QueueJump()
    {
        if (holdJumpToBhop)
        {
            wishJump = Input.GetButton("Jump");
            return;
        }

        if (Input.GetButtonDown("Jump") && !wishJump)
        {
            wishJump = true;
            isJumping = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            wishJump = false;
        }
    }
    private void AirMove()
    {
        Vector3 wishdir;
        float wishvel = airAcceleration;
        float accel;
        SetMovementDir();
        isJumping = true;

        wishdir = new Vector3(_cmd.rightMove, 0, _cmd.forwardMove);
        wishdir = transform.TransformDirection(wishdir);

        float wishspeed = wishdir.magnitude;
        wishspeed *= moveSpeed;

        wishdir.Normalize();
        moveDirectionNorm = wishdir;
        float wishspeed2 = wishspeed;
        if (Vector3.Dot(playerVelocity, wishdir) < 0)
            accel = airDecceleration;
        else
            accel = airAcceleration;
        if (_cmd.forwardMove == 0 && _cmd.rightMove != 0)
        {
            if (wishspeed > sideStrafeSpeed)
                wishspeed = sideStrafeSpeed;
            accel = sideStrafeAcceleration;
        }

        Accelerate(wishdir, wishspeed, accel);
        if (airControl > 0)
            AirControl(wishdir, wishspeed2);
        playerVelocity.y -= gravity * Time.deltaTime;
    }
    private void AirControl(Vector3 wishdir, float wishspeed)
    {
        float zspeed;
        float speed;
        float dot;
        float k;
        if (Mathf.Abs(_cmd.forwardMove) < 0.001 || Mathf.Abs(wishspeed) < 0.001)
            return;
        zspeed = playerVelocity.y;
        playerVelocity.y = 0;
        speed = playerVelocity.magnitude;
        playerVelocity.Normalize();

        dot = Vector3.Dot(playerVelocity, wishdir);
        k = 32;
        k *= airControl * dot * dot * Time.deltaTime;
        if (dot > 0)
        {
            playerVelocity.x = playerVelocity.x * speed + wishdir.x * k;
            playerVelocity.y = playerVelocity.y * speed + wishdir.y * k;
            playerVelocity.z = playerVelocity.z * speed + wishdir.z * k;

            playerVelocity.Normalize();
            moveDirectionNorm = playerVelocity;
        }

        playerVelocity.x *= speed;
        playerVelocity.y = zspeed;
        playerVelocity.z *= speed;
    }
    private void GroundMove()
    {
        Vector3 wishdir;
        if (!wishJump)
        {
            if (!isSliding)
                ApplyFriction(1.0f);
        }
        else
        {
            ApplyFriction(0);
        }

        SetMovementDir();

        wishdir = new Vector3(_cmd.rightMove, 0, _cmd.forwardMove);
        wishdir = transform.TransformDirection(wishdir);
        wishdir.Normalize();
        moveDirectionNorm = wishdir;

        var wishspeed = wishdir.magnitude;
        wishspeed *= moveSpeed;

        Slide(wishdir, _controller.velocity.magnitude * 0.5f);
        if (!isSliding)
        {
            Accelerate(wishdir, wishspeed, runAcceleration);
        }
        playerVelocity.y = -gravity * Time.deltaTime;

        if (wishJump)
        {
            playerVelocity.y = jumpSpeed;
            wishJump = false;
        }
    }
    private void ApplyFriction(float t)
    {
        Vector3 vec = playerVelocity;
        float speed;
        float newspeed;
        float control;
        float drop;

        vec.y = 0.0f;
        speed = vec.magnitude;
        drop = 0.0f;
        if (_controller.isGrounded)
        {
            control = speed < runDeacceleration ? runDeacceleration : speed;
            drop = control * friction * Time.deltaTime * t;
        }

        newspeed = speed - drop;
        playerFriction = newspeed;
        if (newspeed < 0)
            newspeed = 0;
        if (speed > 0)
            newspeed /= speed;

        playerVelocity.x *= newspeed;
        playerVelocity.z *= newspeed;
    }

    private void Accelerate(Vector3 wishdir, float wishspeed, float accel)
    {
        float addspeed;
        float accelspeed;
        float currentspeed;

        currentspeed = Vector3.Dot(playerVelocity, wishdir);
        addspeed = wishspeed - currentspeed;
        if (addspeed <= 0)
            return;
        accelspeed = accel * Time.deltaTime * wishspeed;
        if (accelspeed > addspeed)
            accelspeed = addspeed;

        playerVelocity.x += accelspeed * wishdir.x;
        playerVelocity.z += accelspeed * wishdir.z;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 400, 100), "FPS: " + fps, style);
        var ups = _controller.velocity;
        ups.y = 0;
        GUI.Label(new Rect(0, 15, 400, 100), "Speed: " + Mathf.Round(ups.magnitude * 100) / 100 + "ups", style);
        GUI.Label(new Rect(0, 30, 400, 100), "Top Speed: " + Mathf.Round(playerTopVelocity * 100) / 100 + "ups", style);
    }
}