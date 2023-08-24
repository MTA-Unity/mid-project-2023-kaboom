using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _scoreButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private GameObject _closeScoreButton;
    [SerializeField] private GameObject _scorePanel;

    private void Awake()
    {
        _playButton.onClick.AddListener(StartGame);   
        _quitButton.onClick.AddListener(QuitGame);   
        _scoreButton.onClick.AddListener(ShowScore);   
        // _closeScoreButton.onClick.AddListener(CloseScore);   
        
        _scorePanel.SetActive(false);
        _closeScoreButton.SetActive(false);
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
    }
    
    private void ShowScore()
    {
        _scorePanel.SetActive(true);
        _closeScoreButton.SetActive(true);
    }
    
    public void CloseScore()
    {
        _scorePanel.SetActive(false);
        _closeScoreButton.SetActive(false);
    }
    
    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(StartGame);   
        _quitButton.onClick.RemoveListener(QuitGame);   
        _scoreButton.onClick.RemoveListener(ShowScore);   
        // _closeScoreButton.onClick.RemoveListener(CloseScore);  
    }
}
