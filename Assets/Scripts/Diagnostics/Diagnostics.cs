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
        //��� �������
        _questionsContainer = new string[] {
            "������ �1",
            "������ �2",
            "������ �3",
            "������ �4",
            "������ �5"
        };

        //����������� ������� �������
        _questionCount = 0;
        _question.text = _questionsContainer[_questionCount];
        _questionCount++;

        //������� ������ �� Toggle
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
        if (_questionCount < _questionsContainer.Length) //����� = 5
        {
            //���� �� ������ �� ���� �����
            if (_toggles[0].isOn == false && _toggles[1].isOn == false && _toggles[2].isOn == false)
            {
                _toggleCheckText.SetActive(true);
                return;
            } else
            {
                //���������� ������
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
            // �.�. ���������� ����� �� ������� �� �������� Count � �� ������������� �����
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
