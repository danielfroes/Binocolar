using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class InfoButton : MonoBehaviour
{

    [SerializeField] private UIView panel;
   public void TogglePanelVisibility()
   {
        print(panel.Visibility);
        if(panel.Visibility != VisibilityState.Visible && panel.Visibility != VisibilityState.Showing )
        {

            panel.SetVisibility(true);
        }
        else
        {
            panel.SetVisibility(false);
        }
   }
}
