using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CharacterComponent character;
    private CharacterControlSystem characterControlSystem;


    private void Awake()
    {
        Singleton.Initialize();
    }

    private void Start()
    {
        characterControlSystem = new CharacterControlSystem(character, mainCamera);
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        characterControlSystem.OnUpdate(deltaTime);
    }

    private void OnDestroy()
    {

    }
}
