using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwap : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _characters;

    [SerializeField]
    private CinemachineVirtualCamera _playerFollowCamera;


    private int _characterIndex;

    private GameObject _currentCharacter;

    [HideInInspector]
    public StarterAssetsInputs input;
    private FirstPersonController _firstPersonController;
    private CharacterController _characterController;
    private PlayerInput _playerInput;

    private AudioSource _audioSource;


    private void Awake()
    {
        _currentCharacter = _characters[_characterIndex % _characters.Count];

        input = _currentCharacter.GetComponent<StarterAssetsInputs>();

        _firstPersonController = _currentCharacter.GetComponent<FirstPersonController>();
        _characterController = _currentCharacter.GetComponent<CharacterController>();
        _playerInput = _currentCharacter.GetComponent<PlayerInput>();

        _audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        Transform playerCameraRoot = _currentCharacter.transform.Find("PlayerCameraRoot");
        _playerFollowCamera.Follow = playerCameraRoot;
    }

    private void Update()
    {
        if (input.switchCharacter)
        {
            _audioSource.Play();
            _characterIndex++;

            DisabelCurrentCharacter();
            _currentCharacter = _characters[_characterIndex % _characters.Count];
            UpdateCurrentCharacter();

            input.switchCharacter = false;
        }
    }

    private void DisabelCurrentCharacter()
    {
        _firstPersonController.enabled = false;
        _characterController.enabled = false;
        _playerInput.enabled = false;

        Transform capsule = _currentCharacter.transform.Find("Sphere");
        capsule.gameObject.SetActive(true);
    }

    private void UpdateCurrentCharacter()
    {
        input = _currentCharacter.GetComponent<StarterAssetsInputs>();


        _firstPersonController = _currentCharacter.GetComponent<FirstPersonController>();
        _firstPersonController.enabled = true;

        _characterController = _currentCharacter.GetComponent<CharacterController>();
        _characterController.enabled = true;

        _playerInput = _currentCharacter.GetComponent<PlayerInput>();
        _playerInput.enabled = true;

        Transform playerCameraRoot = _currentCharacter.transform.Find("PlayerCameraRoot");
        _playerFollowCamera.Follow = playerCameraRoot;

        Transform capsule = _currentCharacter.transform.Find("Sphere");
        capsule.gameObject.SetActive(false);
    }
}
