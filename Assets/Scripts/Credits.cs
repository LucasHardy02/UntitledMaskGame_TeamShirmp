using UnityEditor;
using UnityEngine;

public class Credits : MonoBehaviour
{
    //To set the menus back to normal
    public GameObject _menu;
    public GameObject _credits;

    //To track what page we're on
    private int _currentPage = 1;
    private int _maxPages = 6;
    private int _minPages = 1;

    //All the wonderful people
    public GameObject _percy;
    public GameObject _tristan;
    public GameObject _hunter;
    public GameObject _charlie;
    public GameObject _zander;
    public GameObject _lucas;

    //Goes back to the main menu
    public void OnBackButton()
    {
        _menu.SetActive(true);
        _credits.SetActive(false);
    }

    public void OnLeftArrow()
    {
        if(_currentPage > _minPages) _currentPage--;
    }
    
    public void OnRightArrow()
    {
        if(_currentPage < _maxPages) _currentPage++;
    }

    //Checking what page we're on
    private void Update()
    {
        if(_currentPage == 1)
        {
            _percy.SetActive(true);
            _tristan.SetActive(false);
        }
        else if(_currentPage == 2)
        {
            _percy.SetActive(false);
            _tristan.SetActive(true);
            _hunter.SetActive(false);
        }
        else if(_currentPage == 3)
        {
            _tristan.SetActive(false);
            _hunter.SetActive(true);
            _charlie.SetActive(false);
        }
        else if(_currentPage == 4)
        {
            _hunter.SetActive(false);
            _charlie.SetActive(true);
            _zander.SetActive(false);
        }
        else if(_currentPage == 5)
        {
            _charlie.SetActive(false);
            _zander.SetActive(true);
            _lucas.SetActive(false);
        }
        else
        {
            _zander.SetActive(false);
            _lucas.SetActive(true);
        }
    }
}
