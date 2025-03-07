using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] _resolutions;
    private readonly List<Resolution> _resList = new();
    public GameObject mainMenu;
    public GameObject selectMenu;

    public void Start() {
        AddResolutionsToDropdown();
    }

    public void SelectLevel1() {
        SceneManager.LoadSceneAsync(1);
    }
    
    public void SelectLevel2() {
        SceneManager.LoadSceneAsync(2);
    }
    
    public void SelectLevel3() {
        SceneManager.LoadSceneAsync(3);
    }

    public void SetFullScreen(bool iSFullScreen) {
        Screen.fullScreen = iSFullScreen;
    }

    private void AddResolutionsToDropdown() {
        _resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new();

        for (var i = 0; i < _resolutions.Length; i++) {
            var currentRefreshRate = Screen.currentResolution.refreshRateRatio;

            if (!_resolutions[i].refreshRateRatio.Equals(currentRefreshRate)) continue;
            
            options.Add(_resolutions[i].width + "x" + _resolutions[i].height + " (" + _resolutions[i].refreshRateRatio + "hz)");
            _resList.Add(_resolutions[i]);

            if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height){
                resolutionDropdown.value = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

        foreach (var res in _resolutions) {
            Debug.Log($"{res.width}x{res.height}, refresh rate: {res.refreshRateRatio}");
        }
    }

    public void SetResolution(int i) {
        Screen.SetResolution(_resList[i].width, _resList[i].height, Screen.fullScreen);
        Debug.Log($"{_resList[i].width}x{_resList[i].height}, refresh rate: {_resList[i].refreshRateRatio}");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
