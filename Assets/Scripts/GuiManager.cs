using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    // Menu +++++++++++++++++++++++++++++++
    [SerializeField] private CanvasGroup _menu;
    public void SetActiveMenu(bool isActive)
    {
        _menu.alpha = isActive == true ? 1 : 0;
        _menu.blocksRaycasts = isActive;
    }
    // -------------------------------------------
    
    public void SetActiveScoreBoard(bool isActive)
    {
        _scoreBoard.alpha = isActive == true ? 1 : 0;
        _scoreBoard.blocksRaycasts = isActive;
    }
    
    
    // Score Board +++++++++++++++++++++++++++++++
    [SerializeField] private Text _visualCorrectUi;
    [SerializeField] private Text _visualIncorrectUi;
    [SerializeField] private Text _auditoryCorrectUi;
    [SerializeField] private Text _auditoryIncorrectUi;
    [SerializeField] private CanvasGroup _scoreBoard;
    public void ScoreBoard(int visualCorrect , int visualIncorrect , int auditoryCorrect , int auditoryIncorrect)
    {
        _scoreBoard.alpha = 1;
        _scoreBoard.blocksRaycasts = true;
        _visualCorrectUi.text = $"Correct : {visualCorrect}";
        _auditoryCorrectUi.text = $"Correct : {auditoryCorrect}";
        _visualIncorrectUi.text = $"Incorrect : {visualIncorrect}";
        _auditoryIncorrectUi.text = $"Incorrect : {auditoryIncorrect}";
        _visualIncorrectUi.color = Color.red;
        _auditoryIncorrectUi.color = Color.red;
    }
    // -------------------------------------------
}
