﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabDetecter : MonoBehaviour {

    private EventSystem eventSystem;
    // Use this for initialization
    void Start()
    {
        eventSystem = EventSystem.current;
    }
    // Update is called once per frame
    void Update()
    {
        // When TAB is pressed, we should select the next selectable UI element
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gotoNextSelectable();
        }
    }
    private void gotoNextSelectable()
    {
        Selectable next = null;
        Selectable current = null;

        // Figure out if we have a valid current selected gameobject
        if (eventSystem.currentSelectedGameObject != null)
        {
            // Unity doesn't seem to "deselect" an object that is made inactive
            if (eventSystem.currentSelectedGameObject.activeInHierarchy)
            {
                current = eventSystem.currentSelectedGameObject.GetComponent<Selectable>();
            }
        }

        if (current != null)
        {
            // When SHIFT is held along with tab, go backwards instead of forwards
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                next = current.FindSelectableOnLeft();
                if (next == null)
                {
                    next = current.FindSelectableOnUp();
                }
            }
            else
            {
                next = current.FindSelectableOnRight();
                if (next == null)
                {
                    next = current.FindSelectableOnDown();
                }
            }
        }
        if (next == null)
        {
            // If there is no current selected gameobject, select the first one
            if (Selectable.allSelectables.Count > 0)
            {
                next = Selectable.allSelectables[Selectable.allSelectables.Count - 1];
            }
        }
        next.Select();
    }

}