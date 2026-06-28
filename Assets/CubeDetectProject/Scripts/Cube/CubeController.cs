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
           StartCoroutine(HighlightCoroutine());
        }
        private IEnumerator HighlightCoroutine()
        {
            BeforeDetected?.Invoke();
            meshRenderer.material = HighlightMaterial;
            TextObj.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            meshRenderer.material = DefaultMaterial;
            TextObj.SetActive(false);
            AfterDetected?.Invoke();
        }
    }
}

