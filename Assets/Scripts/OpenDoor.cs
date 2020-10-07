using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {

    public GameObject OpenPanel = null;

    private bool _isInsideTrigger = false;

    public Animator _animator;

    public string OpenText = "Press 'E' to open";

    public string CloseText = "Press 'E' to close";

    private bool _isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            OpenPanel.SetActive(true);
            UpdatePanelText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);
        }
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    private void UpdatePanelText() 
    {

        Text panelText = OpenPanel.transform.Find("Text").GetComponent<Text>();
        if (panelText != null)
        {
            panelText.text = _isOpen ? CloseText : OpenText;
        }
    }

    private void Update()
    {
        if (IsOpenPanelActive && _isInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isOpen = !_isOpen;

                Invoke("UpdatePanelText", 1.0f);

                _animator.SetBool("open", _isOpen);
            }
        }
    }
}
