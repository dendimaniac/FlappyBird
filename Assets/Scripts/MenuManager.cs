using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [SerializeField] private List<Menu> menuList = new List<Menu>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        ToggleCanvas(MenuName.Score);
    }
    
    public void ToggleCanvas(MenuName menuName)
    {
        foreach (var menu in menuList)
        {
            if (menu.menuName == menuName)
            {
                menu.gameObject.SetActive(true);
                continue;
            }
            menu.gameObject.SetActive(false);
        }
    }
}