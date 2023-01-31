using System.Collections;
using System.Linq;
using ExtraAssets.Scripts.Movement;
using ExtraAssets.Scripts.PoolOfObject;
using ExtraAssets.Scripts.Stacking;
using ExtraAssets.Scripts.UserInput;
using ExtraAssets.Scripts.View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExtraAssets.Scripts
{
    [RequireComponent(typeof(UserInput.UserInput))]
    public class Root : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private StackMovement stackMovement;
        
        [SerializeField] private TrackSpawner _trackSpawner;
        [SerializeField] private CubeForPickupPool _cubeForPickupPool;
    
        [SerializeField] private StackOfCube _stackOfCube;
        [SerializeField] private FlyingText[] _scoresTemplate;

        [Header("Start/End Screen")]
        [SerializeField] private StartGameScreen _startGameScreen;
        [SerializeField] private EndGameScreen _endGameScreen;
    
        [Header("Warp Effect")]
        [SerializeField] private ParticleSystem _warpEffect;
    
        private IDirectionInput _directionInput;

        private void Awake()
        {
            _directionInput = GetComponent<UserInput.UserInput>();
            stackMovement.Initialize(_directionInput);
            _startGameScreen.Show();
        }
    
        private void OnEnable()
        {
            _player.CollidedWithSurface += PlayerOnCollided;
            _player.CollidedWithRedCube += PlayerOnCollided;
        
            _stackOfCube.CubeAdded += OnCubeAdded;
        }

        private void Start()
        {
            StartCoroutine(WaitingToPutFingerOnScreen());
        }

        private void OnDisable()
        {
            _player.CollidedWithSurface -= PlayerOnCollided;
            _player.CollidedWithRedCube -= PlayerOnCollided;
        
            _stackOfCube.CubeAdded -= OnCubeAdded;
        }

        private IEnumerator WaitingToPutFingerOnScreen()
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            StartGame();
        }

        private void StartGame()
        {
            stackMovement.enabled = true;
            _trackSpawner.gameObject.SetActive(true);
            _cubeForPickupPool.gameObject.SetActive(true);
            _warpEffect.gameObject.SetActive(true);
        
            _startGameScreen.Hide();
        }

        private void StopGame()
        {
            stackMovement.enabled = false;
            _endGameScreen.Show(ReloadGame);
            Time.timeScale = 0;
        }

        private void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }


        private void OnCubeAdded(Vector3 arg1, float arg2) => 
            _scoresTemplate.FirstOrDefault(score => score.gameObject.activeSelf == false)?.StartMoving();
        
        private void PlayerOnCollided() => StopGame();
    }
}