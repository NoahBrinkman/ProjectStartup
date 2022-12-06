using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class ColourButton : MonoBehaviour
    {
        public Colour color = Colour.None;
        public Button button { get; private set; }

        private void Awake()
        {
            button = GetComponent<Button>();
        }
    }
