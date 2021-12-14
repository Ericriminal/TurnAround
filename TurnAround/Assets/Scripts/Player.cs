using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody m_PlayerRB;
    Quaternion m_TargetRotation;
    public Transform camera;
    public float m_Speed;
    public float m_TurnSpeed = 5;
    float step;
	float m_HorizontalCamera = 0f;
    float m_VerticalCamera = 0f;
    bool m_rotating = false;
    public bool grounded = false;
    float rotZ = 0f;
    float m_HorizontalRotation = 0f;
    float m_VerticalRotation = 0f;

    bool m_XPos = false;
    bool m_XNeg = false;
    bool m_YPos = false;
    bool m_YNeg = true;
    bool m_ZPos = false;
    bool m_ZNeg = false;



    // Start is called before the first frame update
    void Start()
    {
        m_PlayerRB = gameObject.GetComponent<Rigidbody>();
        step = 100.0f * Time.deltaTime;
        Physics.gravity = new Vector3(0, -10.0F, 0);
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * m_Speed;
        float vertical = Input.GetAxis("Vertical") * m_Speed;
        if (!m_rotating)
        {
            m_HorizontalCamera += Input.GetAxis("Mouse X") * m_TurnSpeed;
            m_VerticalCamera += Input.GetAxis("Mouse Y") * m_TurnSpeed;
        }


        // Y axis
        // if (Input.GetKeyDown(KeyCode.Alpha4) && !m_YNeg)
        if (Input.GetKeyDown(KeyCode.Alpha1) && m_ZPos)
            ContinuousGravityYNeg();
        // if (Input.GetKeyDown(KeyCode.Alpha3) && !m_YPos)
        else if (Input.GetKeyDown(KeyCode.Alpha1) && m_YNeg)
            ContinuousGravityYPos();
        // X axis
        // if (Input.GetKeyDown(KeyCode.Alpha1) && !m_XPos)
        else if (Input.GetKeyDown(KeyCode.Alpha1) && m_XNeg)
            ContinuousGravityXPos();
        // if (Input.GetKeyDown(KeyCode.Alpha2) && !m_XNeg)
        else if (Input.GetKeyDown(KeyCode.Alpha1) && m_YPos)
            ContinuousGravityXNeg();
        // Z axis
        // if (Input.GetKeyDown(KeyCode.Alpha6) && !m_ZNeg)
        else if (Input.GetKeyDown(KeyCode.Alpha1) && m_XPos)
            ContinuousGravityZNeg();
        // if (Input.GetKeyDown(KeyCode.Alpha5) && !m_ZPos)
        else if (Input.GetKeyDown(KeyCode.Alpha1) && m_ZNeg)
            ContinuousGravityZPos();

        if (Physics.gravity.y == 0 && Physics.gravity.z == 0)
            XGravity();


        if (Physics.gravity.x == 0 && Physics.gravity.z == 0)
            YGravity();


        if (Physics.gravity.x == 0 && Physics.gravity.y == 0)
            ZGravity();
    }

    /// 1
    private void ContinuousGravityXPos()
    {
        m_XPos = true;
        m_rotating = true;
        Physics.gravity = new Vector3(10.0F, 0, 0);
        grounded = false;
        m_VerticalCamera = 0f;
        m_HorizontalCamera = 0f;


        if (m_XNeg)
        {
            m_TargetRotation = Quaternion.Euler(transform.eulerAngles.x, 0, 90.0f);
            m_XNeg = false;
            m_VerticalRotation = 0;
            m_HorizontalRotation = transform.eulerAngles.x;
            rotZ = 90;
        }

        if (m_YNeg || m_YPos || m_ZNeg || m_ZPos)
        {
            m_YNeg = false;
            m_YPos = false;
            m_ZNeg = false;
            m_ZPos = false;
            if (transform.eulerAngles.y > 90 && transform.eulerAngles.y < 270)
            {
                m_TargetRotation = Quaternion.Euler(180f, 0f, 90.0f);
                m_HorizontalRotation = 180f;
            }
            else
            {
                m_TargetRotation = Quaternion.Euler(0f, 0f, 90.0f);
                m_HorizontalRotation = 0f;
            }
            m_VerticalRotation = 0f;
            rotZ = 90;
        }
    }

    // 2
    private void ContinuousGravityXNeg()
    {
        m_XNeg = true;
        m_rotating = true;
        Physics.gravity = new Vector3(-10.0F, 0, 0);
        grounded = false;
        m_HorizontalCamera = 0f;
        m_VerticalRotation = 0f;

        if (m_XPos)
        {
            m_TargetRotation = Quaternion.Euler(transform.eulerAngles.x, 0, 270.0f);
            m_XPos = false;
            m_VerticalRotation = 0;
            m_HorizontalRotation = transform.eulerAngles.x;
            rotZ = 270f;
        }

        if (m_YNeg || m_YPos || m_ZNeg || m_ZPos)
        {
            m_YNeg = false;
            m_YPos = false;
            m_ZNeg = false;
            m_ZPos = false;
            if (transform.eulerAngles.y > 90f && transform.eulerAngles.y < 270f)
            {
                m_TargetRotation = Quaternion.Euler(180f, 0f, 270.0f);
                m_HorizontalRotation = 180f;
            }
            else
            {
                m_TargetRotation = Quaternion.Euler(0f, 0f, 270.0f);
                m_HorizontalRotation = 0f;
            }
            m_VerticalRotation = 0f;
            rotZ = 270f;
        }
    }

    // 3
    private void ContinuousGravityYPos()
    {
        m_YPos = true;
        m_rotating = true;
        Physics.gravity = new Vector3(0, 10.0F, 0);
        m_VerticalCamera = 0f;
        m_HorizontalCamera = 0f;
        grounded = false;

        if (m_YNeg)
        {
            m_TargetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180.0f);
            m_YNeg = false;
            if (camera.eulerAngles.x > 100)
                m_VerticalRotation = camera.eulerAngles.x - 360f;
            else
                m_VerticalRotation = camera.eulerAngles.x;

            m_HorizontalRotation = transform.eulerAngles.y;
            rotZ = 180f;
        }
        if (m_XPos || m_XNeg || m_ZNeg || m_ZPos)
        {
            m_XNeg = false;
            m_XPos = false;
            m_ZNeg = false;
            m_ZPos = false;
            if (transform.eulerAngles.y == 180)
            {
                m_TargetRotation = Quaternion.Euler(0f, 180f, 180f);
                m_HorizontalRotation = 180f;
            }
            else
            {
                m_TargetRotation = Quaternion.Euler(0f, 0f, 180f);
                m_HorizontalRotation = 0f;
            }
            rotZ = 180f;
        }
    }

    // 4
    private void ContinuousGravityYNeg()
    {
        m_YNeg = true;
        m_rotating = true;
        Physics.gravity = new Vector3(0, -10.0F, 0);
        m_VerticalCamera = 0f;
        m_HorizontalCamera = 0f;
        grounded = false;

        if (m_YPos)
        {
            m_TargetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0.0f);
            m_YPos = false;
            if (camera.eulerAngles.x > 100)
                m_VerticalRotation = 360 - camera.eulerAngles.x;
            else
                m_VerticalRotation = -camera.eulerAngles.x;
            m_HorizontalRotation = transform.eulerAngles.y;
            rotZ = 0f;
        }
        if (m_XNeg || m_XPos || m_ZNeg || m_ZPos)
        {
            m_XNeg = false;
            m_XPos = false;
            m_ZNeg = false;
            m_ZPos = false;
            if (transform.eulerAngles.y == 180)
            {
                m_TargetRotation = Quaternion.Euler(0f, 180f, 0f);
                m_HorizontalRotation = 180f;
            }
            else
            {
                m_TargetRotation = Quaternion.Euler(0f, 0f, 0f);
                m_HorizontalRotation = 0f;
            }
            m_VerticalRotation = 0;
            rotZ = 0f;
        }
    }

    // 5
    private void ContinuousGravityZPos()
    {
        m_ZPos = true;
        m_rotating = true;
        Physics.gravity = new Vector3(0,  0, 10.0F);
        m_VerticalCamera = 0f;
        m_HorizontalCamera = 0f;
        grounded = false;

        if (m_ZNeg)
        {
            m_TargetRotation = Quaternion.Euler(transform.eulerAngles.x, 90f, 270f);
            m_ZNeg = false;
            m_VerticalRotation = 0;
            m_HorizontalRotation = transform.eulerAngles.x;
            rotZ = 270f;
        }

        if (m_YPos || m_YNeg || m_XNeg || m_XPos)
        {
            m_YPos = false;
            m_YNeg = false;
            m_XNeg = false;
            m_XPos = false;
            m_TargetRotation = Quaternion.Euler(0f, 90f, 270f);
            m_HorizontalRotation = transform.eulerAngles.y;
            rotZ = 270f;
        }
    }

    // 6
    private void ContinuousGravityZNeg()
    {
        m_ZNeg = true;
        m_rotating = true;
        Physics.gravity = new Vector3(0,  0, -10.0F);
        m_VerticalCamera = 0f;
        m_HorizontalCamera = 0f;
        grounded = false;

        if (m_ZPos)
        {
            m_TargetRotation = Quaternion.Euler(transform.eulerAngles.x, 90f, 90f);
            m_ZPos = false;
            m_VerticalRotation = 0;
            m_HorizontalRotation = transform.eulerAngles.x;
            rotZ = 90f;
        }
        if (m_YPos || m_YNeg || m_XNeg || m_XPos)
        {
            m_YPos = false;
            m_YNeg = false;
            m_XNeg = false;
            m_XPos = false;
            m_TargetRotation = Quaternion.Euler(0f, 90f, 90f);
            m_HorizontalRotation = transform.eulerAngles.y;
            rotZ = 90f;
        }
    }

    private void ZGravity()
    {
        m_PlayerRB.velocity = new Vector3(0, 0, m_PlayerRB.velocity.z);
        if (m_rotating && !grounded && Vector3.Angle(m_TargetRotation.eulerAngles, transform.eulerAngles) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_TargetRotation, step);
            return;
        }
        m_rotating = false;

        if (Physics.gravity.z > 0) {
            PositiveZGravity();
        } else if (Physics.gravity.z < 0) {
            NegativeZGravity();
        }
    }

    private void PositiveZGravity()
    {
        // limit vertical spin on camera
        m_VerticalCamera = Mathf.Clamp(m_VerticalCamera, -20 + m_VerticalRotation, 100 + m_VerticalRotation);

        // player turn around with camera
        transform.localRotation = Quaternion.Euler(m_HorizontalRotation + m_HorizontalCamera, 90.0f, 270.0F);

        // camera movements
        camera.localRotation = Quaternion.Euler(m_VerticalRotation - m_VerticalCamera, 0, 0);
        if (grounded)
            Move();
    }

    private void NegativeZGravity()
    {
        // limit vertical spin on camera
        m_VerticalCamera = Mathf.Clamp(m_VerticalCamera, -20 + m_VerticalRotation, 100 + m_VerticalRotation);

        // player turn around with camera
        transform.localRotation = Quaternion.Euler(m_HorizontalRotation - m_HorizontalCamera, 90.0f, 90.0F);

        // camera movements
        camera.localRotation = Quaternion.Euler(m_VerticalRotation - m_VerticalCamera, 0, 0);
        if (grounded)
            Move();
    }



    private void XGravity()
    {
        m_PlayerRB.velocity = new Vector3(m_PlayerRB.velocity.x, 0, 0);
        if (m_rotating && !grounded && Vector3.Angle(m_TargetRotation.eulerAngles, transform.eulerAngles) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_TargetRotation, step);
            return;
        }
        m_rotating = false;

        if (Physics.gravity.x > 0) {
            PositiveXGravity();
        } else if (Physics.gravity.x < 0) {
            NegativeXGravity();
        }
    }

    private void PositiveXGravity()
    {
        // limit vertical spin on camera
        m_VerticalCamera = Mathf.Clamp(m_VerticalCamera, -20 + m_VerticalRotation, 100 + m_VerticalRotation);

        // player turn around with camera
        transform.localRotation = Quaternion.Euler(m_HorizontalRotation - m_HorizontalCamera, 0, rotZ);

        // // camera movements
        camera.localRotation = Quaternion.Euler(m_VerticalRotation - m_VerticalCamera, 0, 0);
        if (grounded)
            Move();
    }

    private void NegativeXGravity()
    {
        // limit vertical spin on camera
        m_VerticalCamera = Mathf.Clamp(m_VerticalCamera, -20 + m_VerticalRotation, 100 + m_VerticalRotation);

            // player turn around with camera
            transform.localRotation = Quaternion.Euler(m_HorizontalRotation + m_HorizontalCamera, 0, rotZ);

            // // camera movements
            camera.localRotation = Quaternion.Euler(m_VerticalRotation - m_VerticalCamera, 0, 0);
        if (grounded)
            Move();
    }



    private void YGravity()
    {
        m_PlayerRB.velocity = new Vector3(0, m_PlayerRB.velocity.y, 0);
        // Debug.Log(Vector3.Angle(m_TargetRotation.eulerAngles, transform.eulerAngles));
        // Debug.Log(m_TargetRotation.eulerAngles);
        // Debug.Log(transform.eulerAngles);
        if (m_rotating && !grounded && Vector3.Angle(m_TargetRotation.eulerAngles, transform.eulerAngles) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_TargetRotation, step);
            return;
        }
        m_rotating = false;

        if (Physics.gravity.y > 0)
            PositiveYGravity();
        else if (Physics.gravity.y < 0)
            NegativeYGravity();
    }
    private void PositiveYGravity()
    {
        // limit vertical spin on camera
        m_VerticalCamera = Mathf.Clamp(m_VerticalCamera, -20 + m_VerticalRotation, 80 + m_VerticalRotation);

        // player turn around with camera
        transform.localRotation = Quaternion.Euler(0, m_HorizontalRotation - m_HorizontalCamera, rotZ);

        // camera movements
        camera.localRotation = Quaternion.Euler(m_VerticalRotation + -m_VerticalCamera, 0, 0);
        if (grounded)
            Move();
    }

    private void NegativeYGravity()
    {
        // limit vertical spin on camera
        m_VerticalCamera = Mathf.Clamp(m_VerticalCamera, -20 + m_VerticalRotation, 80 + m_VerticalRotation);
        // player turn around with camera
        transform.localRotation = Quaternion.Euler(0, m_HorizontalRotation + m_HorizontalCamera, rotZ);

        // camera movements
        camera.localRotation = Quaternion.Euler(m_VerticalRotation + -m_VerticalCamera, 0, 0);
        if (grounded)
            Move();
    }

    private void Move()
    {
        // right and left
        if (Input.GetKey(KeyCode.RightArrow)) {
            m_PlayerRB.velocity = transform.right * m_Speed;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            m_PlayerRB.velocity = -transform.right * m_Speed;
        }

        // backward and forward
        if (Input.GetKey(KeyCode.DownArrow)) {
            m_PlayerRB.velocity += -transform.forward * m_Speed;
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            m_PlayerRB.velocity += transform.forward * m_Speed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            grounded = true;
    }

}
