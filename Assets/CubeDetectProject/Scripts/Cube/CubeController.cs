using System.Collections;
using UnityEngine;
using UnityEngine.Events;
namespace Project1
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Material DefaultMaterial , HighlightMaterial;
        [SerializeField] private GameObject TextObj;
        public UnityEvent BeforeDetected;
        public UnityEvent AfterDetected;
        public void HighlightCube()
        {
           StartCoroutine(HighlightCoroutine());// Color Change Coroutine
        }
        //Cube Highlight Coroutine
        private IEnumerator HighlightCoroutine()
        {
            BeforeDetected?.Invoke();// Invoke BeforeDetected Event
            meshRenderer.material = HighlightMaterial;
            TextObj.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            meshRenderer.material = DefaultMaterial;
            TextObj.SetActive(false);
            AfterDetected?.Invoke();// Invoke AfterDetected Event
        }
    }
}

