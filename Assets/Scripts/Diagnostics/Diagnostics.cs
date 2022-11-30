using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Diagnostics : MonoBehaviour
{

    [SerializeField] private Button _back;
    [SerializeField] private Button _next;
    [SerializeField] private TMP_Text _question;
    [SerializeField] private Transform _pathToggles;
    [SerializeField] private GameObject _toggleCheckText;
    [SerializeField] private GameObject _resultsPnl;
    [SerializeField] private GameObject _diagPnl;

    private int _points;
    private string[] _questionsContainer;
    private Toggle[] _toggles;
    private int _questionCount;

    /*private void OnEnable()
    {
        _points = 0;
        _questionCount = 0;
    }*/

    private void OnEnable()
    {
        //Все вопросы
        _questionsContainer = new string[] {
            "Вопрос №1",
            "Вопрос №2",
            "Вопрос №3",
            "Вопрос №4",
            "Вопрос №5"
        };

        //Отображение первого вопроса
        _questionCount = 0;
        _question.text = _questionsContainer[_questionCount];
        _questionCount++;

        //Создаем массив из Toggle
        _toggles = new Toggle[_pathToggles.childCount];

        for (int i = 0; i < _pathToggles.childCount; i++)
        {
            _toggles[i] = _pathToggles.GetChild(i).gameObject.GetComponent<Toggle>();            
        }

    }

    public void ResetToggles()
    {
        for (int i = 0; i < _toggles.Length; i++)
        {
            _toggles[i].isOn = false;
        }
    }


    public void NextQuestion()
    {
        if (_questionCount < _questionsContainer.Length) //Длина = 5
        {
            //Если не выбран ни один тоггл
            if (_toggles[0].isOn == false && _toggles[1].isOn == false && _toggles[2].isOn == false)
            {
                _toggleCheckText.SetActive(true);
                return;
            } else
            {
                //начисление баллов
                if (_toggles[0].isOn)
                    _points += 2;
                if (_toggles[1].isOn)
                    _points += 1;

                _question.text = _questionsContainer[_questionCount];
                _questionCount++;              
            }                   
        } 
        else
        {
            // т.к. происходит выход из условия на послднем Count и не засчитываются баллы
            if (_toggles[0].isOn)
                _points += 2;
            if (_toggles[1].isOn)
                _points += 1;

            _questionCount = 0;

            _resultsPnl.SetActive(true);
            _diagPnl.SetActive(false);           
        }     
    }

    public void ResetPoints()
    {
        _points = 0;       
    }
}
