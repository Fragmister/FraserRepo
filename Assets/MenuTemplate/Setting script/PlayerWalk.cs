using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalk : MonoBehaviour
{
    public InputActionAsset inputActions;

    private InputAction m_moveAction;
    private InputAction m_lookAction;
    private InputAction m_jumpAction;
    private InputAction m_menuAction;
   

    private Vector2 m_moveAmt;
    private Vector2 m_lookAmt;
    private Animator m_animator;
    private Rigidbody m_rigidbody;

    public float WalkSpeed = 5;
    public float RotateSpeed = 5;
    public float JumpSpeed = 5;

    
    public GameObject MenuObject;

    private void Awake()
    {
        m_moveAction = inputActions.FindAction("Move");
        m_lookAction = inputActions.FindAction("Look");
        m_jumpAction = inputActions.FindAction("Jump");
        m_menuAction = inputActions.FindAction("Menu");
       

        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();

        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
            inputActions.LoadBindingOverridesFromJson(rebinds);
    }

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Update()
    {
        m_moveAmt = m_moveAction.ReadValue<Vector2>();
        m_lookAmt = m_lookAction.ReadValue<Vector2>();

        if (m_jumpAction.WasPressedThisFrame())
        {
            Jump();
        }

        if (m_menuAction.WasPressedThisFrame())
        {
            Menu();
        }
        
     
        
    }

    public void Menu()
    {
        if (MenuObject.activeInHierarchy)
        {
            MenuObject.SetActive(false);
        }
        else
        {
            MenuObject.SetActive(true);
        }
    }

     public void Jump()
    {
        m_rigidbody.AddForceAtPosition(new Vector3(0, 5f, 0), Vector3.up, ForceMode.Impulse);
        m_animator.SetTrigger("Jump");
    }
   
    
}
