using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/_Scripts/_Editor/EditorManager.cs
    public static EditorManager Instance;
=======
    public static EditorManager instance;
>>>>>>> Stashed changes:Assets/_Scripts/EditorManager.cs
    PlayerAction inputAction;

    public Camera mainCam;
    public Camera editorCamera;

    public GameObject prefab1;
    public GameObject prefab2;

    public GameObject item;

    public bool editorMode = false;

    public bool instantiated = false;

    Vector3 mousePos;

    Subject subject = new Subject();

<<<<<<< Updated upstream:Assets/_Scripts/_Editor/EditorManager.cs
    iCommand _icommand;

    UIManager UI;
=======
    iCommand command;

    UIManager ui;
>>>>>>> Stashed changes:Assets/_Scripts/EditorManager.cs

    /*
    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }*/

    private void Start()
    {
<<<<<<< Updated upstream:Assets/_Scripts/_Editor/EditorManager.cs

        if(Instance == null)
        {
            Instance = this;
=======
        if(instance == null)
        {
            instance = this;
>>>>>>> Stashed changes:Assets/_Scripts/EditorManager.cs
        }
        //inputAction = new PlayerAction();
        inputAction = PlayerInputController.controller.inputAction;


        inputAction.Editor.Enabled.performed += cntxt => SwitchCamera();
        inputAction.Editor.AddItem1.performed += cntxt => AddItem(1);
        inputAction.Editor.AddItem2.performed += cntxt => AddItem(2);
        inputAction.Editor.DropItem.performed += cntxt => Drop();

        mainCam.enabled = true;
        editorCamera.enabled = false;

<<<<<<< Updated upstream:Assets/_Scripts/_Editor/EditorManager.cs
        UI = GetComponent<UIManager>();
=======
        ui = GetComponent<UIManager>();
>>>>>>> Stashed changes:Assets/_Scripts/EditorManager.cs
    }
    
    private void SwitchCamera()
    {
        mainCam.enabled = !mainCam.enabled;
        editorCamera.enabled = !editorCamera.enabled;

<<<<<<< Updated upstream:Assets/_Scripts/_Editor/EditorManager.cs
        UI.ToggleEditorUI();
=======
        ui.ToggleEditorUI();
>>>>>>> Stashed changes:Assets/_Scripts/EditorManager.cs
    }

    private void AddItem(int itemID)
    {
        if(editorMode && !instantiated)
        {
            switch(itemID)
            {
                case 1:
                    item = Instantiate(prefab1);
                    SpikeBall spike1 = new SpikeBall(item, new GreenMat());
                    subject.AddObserver(spike1);
                    break;
                case 2:
                    item = Instantiate(prefab2);
                    SpikeBall spike2 = new SpikeBall(item, new YellowMat());
                    subject.AddObserver(spike2);
                    break;


                    default:
                    break;
            }
            subject.Notify();
            instantiated = true;
        }
    }

    private void Drop()
    {
<<<<<<< Updated upstream:Assets/_Scripts/_Editor/EditorManager.cs
        if(editorMode && instantiated)
=======
        if(editorMdoe && instantiated)
>>>>>>> Stashed changes:Assets/_Scripts/EditorManager.cs
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<SphereCollider>().enabled = true;

<<<<<<< Updated upstream:Assets/_Scripts/_Editor/EditorManager.cs
            _icommand = new PlaceItemCommand(item.transform.position, item.transform);
            CommandInvoker.AddCommand(_icommand);

            instantiated = false;
        }
=======
            command = new PlaceItemCommand(item.transform.position, item.transform);
            CommandInvoker.addCommand(command);

            instantiated = false;
        }
        
>>>>>>> Stashed changes:Assets/_Scripts/EditorManager.cs
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCam.enabled == false && editorCamera.enabled == true)
        {
            editorMode = true;
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            editorMode = false;
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(instantiated)
        {
            mousePos = Mouse.current.position.ReadValue();
            mousePos = new Vector3(mousePos.x, mousePos.y, 10.0f);

            item.transform.position = editorCamera.ScreenToWorldPoint(mousePos);
        }
    }
}
