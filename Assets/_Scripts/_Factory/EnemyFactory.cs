<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System.Reflection;
using System;
using TMPro;
using Unity.VisualScripting;

public class EnemyFactory : MonoBehaviour
{
    public GameObject prefab1;

    public GameObject prefab2;

    public GameObject _btnPanel;
    public GameObject _btnPrefab;

    List<Enemy> _enemies;

    private void Start()
    {
        var enemyTypes = Assembly.GetAssembly(typeof(Enemy)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Enemy)));


        _enemies = new List<Enemy>();

        foreach(var type in enemyTypes)
        {
            var tempType = Activator.CreateInstance(type) as Enemy;

            _enemies.Add(tempType);
        }

        ButtonPanel();
    
    }

    public Enemy GetEnemy(string enemyType)
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy.Name == enemyType)
            {
                Debug.Log("Enemy is found!");
                var target = Activator.CreateInstance(enemy.GetType()) as Enemy;

                return target;
            }

        }
        
        return null;
    }

    void ButtonPanel()
    {
        foreach(Enemy enemy in _enemies)
        {
            var button = Instantiate(_btnPrefab);
            button.transform.SetParent(_btnPanel.transform);
            button.gameObject.name = enemy.Name + "Button";

            //button.GetComponentInChildren<TMP_Text>().text = enemy.Name;
            button.GetComponentInChildren<TextMeshProUGUI>().text = enemy.Name;
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
using TMPro;

public class EnemyFactory : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;

    public GameObject buttonPanel;
    public GameObject buttonPrefab;

    List<Enemy> enemies;

    // Start is called before the first frame update
    void Start()
    {
        var enemyTypes = Assembly.GetAssembly(typeof(Enemy)).GetTypes().Where(myType=>myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Enemy)));
        enemies = new List<Enemy>();

        foreach(var type in enemyTypes)
        {
            var tempType = Activator.CreateInstance(typeof(Enemy)) as Enemy;
            enemies.Add(tempType);
        }

        ButtonPanel();
    }

   public Enemy GetEnemy(string enemyType)
    {
        foreach(Enemy enemy in enemies)
        {
            if(enemy.name == enemyType)
            {
                Debug.Log("Enemy found!");
                var target = Activator.CreateInstance(enemy.GetType()) as Enemy;

                return target;
            }
        }

        return null;
    }

    void ButtonPanel()
    {
        foreach(Enemy enemy in enemies)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(buttonPanel.transform);
            button.gameObject.name = enemy.Name + " Button";

            button.GetComponentInChildren<TextMeshProUGUI>().text = enemy.Name;
        }
    }
}
>>>>>>> Stashed changes