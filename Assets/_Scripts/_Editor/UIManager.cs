<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas editorUI;

    bool editorMode;

    private void Start()
    {
        editorMode = GetComponent<EditorManager>().editorMode;

        if (editorMode == false)
        {
            editorUI.enabled = false;
        }
    }

    public void ToggleEditorUI()
    {
        editorUI.enabled = !editorUI.enabled;
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas editorUI;

    bool editorMode;
    // Start is called before the first frame update
    void Start()
    {
        editorMode = GetComponent<EditorManager>().editorMdoe;

        if(editorMode == false)
        {
            editorUI.enabled = false;
        }
    }

    // Update is called once per frame
    public void ToggleEditorUI()
    {
        editorUI.enabled = !editorUI.enabled;
    }
}
>>>>>>> Stashed changes
