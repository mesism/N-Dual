using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private Piece[] _pieces;
    [SerializeField] private List<int> _piecesViewed;
    [SerializeField] private AudioClip[] _sounds;
    [SerializeField] private List<int> _soundsHeard;
    [SerializeField] private int _stepCount;
    [SerializeField] private TimerClass _timer;
    [SerializeField] private float _flashDelay = 1f;
    [SerializeField] private Button _visualBtn;
    [SerializeField] private Button _auditoryBtn;
    [SerializeField] private Text _visualCorrectUi;
    [SerializeField] private Text _visualIncorrectUi;
    [SerializeField] private Text _auditoryCorrectUi;
    [SerializeField] private Text _auditoryIncorrectUi;
    [SerializeField] private Text _nDualUi;
    [SerializeField] private Text _stepIndexUi;
    [SerializeField] private AudioSource _audioSource;
    private bool _isFlashing;
    private bool _isAuditory;
    private bool _isVisual;
    private int _stepIndex = -1;
    private int _visualCorrectCount;
    private int _visualCount;
    private int _auditoryCorrectCount;
    private int _auditoryCount;
    [SerializeField]private int _nDual = 1;
    private void Start()
    {
        _pieces = FindObjectsOfType<Piece>();

        for (int i = 0; i < _stepCount; i++)
        {
            int pieceRand = Random.Range(0, _pieces.Length);
            int soundRand = Random.Range(0, _sounds.Length);

            _piecesViewed.Add(pieceRand);
            _soundsHeard.Add(soundRand);
        }
        
        Flash();
        
    }
    public void Flash()
    {
        _timer.StartTimer(_flashDelay , () =>
        {
            _stepIndex++;
            _visualBtn.interactable = true;
            _auditoryBtn.interactable = true;
            _isAuditory = false;
            _isVisual = false;
            _isFlashing = true;
            if (_stepIndex == _stepCount)
            {

                FinishGame();
                return;

            }

            _pieces[_piecesViewed[_stepIndex]].StartFlash(OnFinishedFlash);
            _audioSource.PlayOneShot(_sounds[_soundsHeard[_stepIndex]]);
            _stepIndexUi.text = _stepIndex.ToString();
        });
    }
    public void OnFinishedFlash()
    {
        _isFlashing = false;
        CheckAction();
        Flash();
    }
    public void VisualBtn()
    {
        if(_isFlashing)
            _isVisual = true;
        _visualBtn.interactable = false;
    }
    public void AuditoryBtn()
    {
        if(_isFlashing)
            _isAuditory = true;
        _auditoryBtn.interactable = false;
    }
    private void CheckAction()
    {
    
        if (_stepIndex > _nDual - 1)
        {
            if (_sounds[_soundsHeard[_stepIndex]] == _sounds[_soundsHeard[_stepIndex - _nDual]])
            {
                _auditoryCount++;

                if (_isAuditory)
                {
                    _auditoryCorrectCount++;
                }
            }
        }
        
        if (_stepIndex > _nDual - 1)
        {
            if (_pieces[_piecesViewed[_stepIndex]] == _pieces[_piecesViewed[_stepIndex - _nDual]])
            {
                _visualCount++;

                if (_isVisual)
                {
                    _visualCorrectCount++;
                }
            }
        }
        _nDualUi.text = $"N : {_nDual}";
    }

    private void FinishGame()
    {
        GameManager.Instance.GuiManager.ScoreBoard(_visualCorrectCount , _visualCount - _visualCorrectCount ,
            _auditoryCorrectCount ,  _auditoryCount - _auditoryCorrectCount );
    }

    // Score Board +++++++++++++++++++++++++++++++
    [SerializeField] private CanvasGroup _scoreBoard;
    private void ScoreBoard()
    {
        _scoreBoard.alpha = 1;
        _scoreBoard.blocksRaycasts = true;
        _visualCorrectUi.text = $"Correct : {_visualCorrectCount}";
        _auditoryCorrectUi.text = $"Correct : {_auditoryCorrectCount}";
        _visualIncorrectUi.text = $"Incorrect : {_visualCount - _visualCorrectCount}";
        _auditoryIncorrectUi.text = $"Incorrect : {_auditoryCount - _auditoryCorrectCount}";
        _visualIncorrectUi.color = Color.red;
        _auditoryIncorrectUi.color = Color.red;
    }
    // -------------------------------------------
    
    

}
