using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator _levelLoaderAnimator;

    private List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
    private float _totalSceneProgress;

    public async void LoadNextLevel()
    {
        await LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private async UniTask LoadLevel(int buildIndex)
    {
        _levelLoaderAnimator.SetTrigger("Start");

        foreach (var scene in _scenesLoading)
        {
            _totalSceneProgress = 0;

            foreach (AsyncOperation operation in _scenesLoading)
            {
                _totalSceneProgress += operation.progress;
            }

            _totalSceneProgress = (_totalSceneProgress / _scenesLoading.Count) * 100f;

            //_progressBar.value = Mathf.RoundToInt(_totalSceneProgress);

            await UniTask.WaitUntil(() => scene.isDone);
        }

        SceneManager.LoadScene((int) SceneIndexes.LEVEL2);

    }
}

public enum SceneIndexes
{
    MENU = 1,
    LOADING = 2,
    LEVEL1 = 3,
    LEVEL2 = 4,
    EMPTY = 5,
}
