using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static StarterAssets.FirstPersonController;

public class SpecialMoveSwap : MonoBehaviour
{
    [SerializeField]
    private CharacterSwap _characterSwap;

    [SerializeField]
    private List<FirstPersonController> _controllers;

    [SerializeField]
    private List<Image> _images;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_characterSwap.input.switchSpecialMove)
        {
            _audioSource.Play();

            SwitchIcons();
            SwitchMoves();

            _characterSwap.input.switchSpecialMove = false;
        }
    }

    private void SwitchIcons()
    {
        List<Vector3> originalPositions = new List<Vector3>(_images.Count);
        for (int i = 0; i < _images.Count; i++)
        {
            originalPositions.Add(_images[i].GetComponent<RectTransform>().position);
        }

        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].GetComponent<RectTransform>().position = originalPositions[(i + 2) % _images.Count];
        }
    }

    private void SwitchMoves()
    {
        List<SpecialMove> originalMoves = new List<SpecialMove>(_controllers.Count);
        for (int i = 0; i < _controllers.Count; i++)
        {
            originalMoves.Add(_controllers[i].specialMove);
        }

        for (int i = 0; i < _controllers.Count; i++)
        {
            _controllers[i].specialMove = originalMoves[(i + 1) % _controllers.Count];
        }
    }
}
