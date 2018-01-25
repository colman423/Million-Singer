using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManageHandler : MonoBehaviour {
    private EventSystem eventSystem;
    public GameObject lyricsContainer;
    public GameObject lyricsRawPrefab;
    public Scrollbar scrollbarVertical;

    // Use this for initialization
    void Start()
    {
        eventSystem = EventSystem.current;
    }

    public void createLyricsRaw()
    {
        GameObject raw = Instantiate(lyricsRawPrefab);
        raw.transform.parent = lyricsContainer.transform;

        GameObject objMinute = raw.transform.Find("Time").Find("Start Time").Find("min").gameObject;
        objMinute.GetComponent<Selectable>().Select();

        scrollbarVertical.value = 0; //TODO
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
    private void gotoNextSelectable() { 
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
        if( next==null )
        {
            // If there is no current selected gameobject, select the first one
            if (Selectable.allSelectables.Count > 0)
            {
                next = Selectable.allSelectables[Selectable.allSelectables.Count-1];
            }
        }
        next.Select();
    }

}
