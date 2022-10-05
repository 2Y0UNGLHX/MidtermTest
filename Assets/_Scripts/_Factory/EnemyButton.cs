<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using Unity.VisualScripting;

public class EnemyButton : MonoBehaviour
{
    private EnemyFactory _factory;

    private EditorManager _editor;

    TextMeshProUGUI _btnText;

    private void Start()
    {
        _factory = GameObject.Find("GameManager").GetComponent<EnemyFactory>();

        _editor = EditorManager.Instance;

        _btnText = GetComponentInChildren<TextMeshProUGUI>();

        if (_factory.prefab1 == null)
            Debug.Log("Prefab1 is null");
    }

    public void OnClickSpawn()
    {
        switch(_btnText.text)
        {
            case "crab":
                _editor.item = _factory.GetEnemy("crab").Create(_factory.prefab1);
                break;

            case "monster":
                _editor.item = _factory.GetEnemy("monster").Create(_factory.prefab2);
                break;
        }

        _editor.instantiated = true;
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyButton : MonoBehaviour
{

    private EnemyFactory factory;

    private EditorManager editor;

    TextMeshProUGUI btnText;

    // Start is called before the first frame update
    void Start()
    {
        factory = GameObject.Find("Game Manager").GetComponent<EnemyFactory>();
        editor = EditorManager.instance;

        btnText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClickSpawn()
    {
        switch (btnText.text)
        {
            case "crab":
                editor.item = factory.GetEnemy("crab").Create(factory.prefab1);
                break;
            case "monster":
                editor.item = factory.GetEnemy("mosnter").Create(factory.prefab2);
                break;
            default:
                break;
        }

        editor.instantiated = true;
    }
   
}
>>>>>>> Stashed changes
