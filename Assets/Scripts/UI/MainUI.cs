using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Scripts.Management;

namespace Scripts.UI
{
    public class MainUI : Singleton<MainUI>
    {
        [SerializeField] private List<UIMenu> menus = new List<UIMenu>();
        [SerializeField] private UIMenu currentPanel;

        public static T GetPanel<T>() where T : UIMenu
        {
            UIMenu panel = Instance.menus.FirstOrDefault(x => x.GetComponent<T>() != null);
            return (T)panel;
        }

        public static T OpenPanel<T>() where T : UIMenu
        {
            T panel = GetPanel<T>();
            panel.Open();
            Instance.currentPanel = panel;
            return panel;
        }

        public static void ClosePanel<T>() where T : UIMenu
        {
            T panel = GetPanel<T>();
            panel.Close();
        }

        public static void CloseCurrentPanel()
        {
            Instance.currentPanel.Close();
        }

        public static T OpenPanelAndCloseCurrentPanel<T>() where T : UIMenu
        {
            CloseCurrentPanel();
            return OpenPanel<T>();
        }

        public void FindMenus()
        {
            UIMenu[] objects = GetComponentsInChildren<UIMenu>();
            menus = new List<UIMenu>(objects);
        }
    }
}
