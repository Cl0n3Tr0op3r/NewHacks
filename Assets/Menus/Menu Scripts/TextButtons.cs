using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
   public TMP_InputField NameInputField;
   public TMP_Text TimeText;
   public Button RefreshButton;

   private void Awake()
   {
    RefreshButton.onClick.AddListener(RefreshTimeText);
   }

   void OnEnable() => RefreshTimeText();

   // Now this refreshes name
   public void RefreshTimeText()
    {
        TimeText.SetText(NameInputField.text);
    }
}
