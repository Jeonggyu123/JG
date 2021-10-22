using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatePrinter : MonoBehaviour
{
    private TMP_Text m_Text;


    private void Awake()
    {
        m_Text = GetComponent<TMP_Text>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = GameManager.getInstance.m_State.ToString();
    }
}
