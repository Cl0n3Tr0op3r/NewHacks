using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class EndGame : MonoBehaviourPunCallbacks
{
    public GameObject winnerPanel;
    public GameObject loserPanel;
    public PhotonView view;
    public bool hasWon; // Set this to true when the player wins

    public void CheckEndGame()
    {
        if (view.IsMine) // Ensure the code only runs for the local player
        {
            if (hasWon)
            {
                SetPanelAlpha(winnerPanel, 255);
                SetPanelAlpha(loserPanel, 0);
            }
            else
            {
                SetPanelAlpha(winnerPanel, 0);
                SetPanelAlpha(loserPanel, 255);
            }
        }
    }

    private void SetPanelAlpha(GameObject panel, float alpha)
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = alpha / 255f; // Unity alpha values are 0-1, so we normalize by dividing by 255
            canvasGroup.interactable = alpha > 0;
            canvasGroup.blocksRaycasts = alpha > 0;
        }
    }
}
