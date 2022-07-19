using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] _images;
    
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.OnChanged -= UpdateHealth;
    }
    
    private void UpdateHealth(int health)
    {
        for (int i = 0; i < _images.Length; i++)
        {
            if (i < health)
            {
                ActivateHealth(_images[i]);
                continue;
            }

            DeactivateHealth(_images[i]);
        }
    }

    private void ActivateHealth(Image image)
    {
        image.gameObject.SetActive(true);
    }
    
    private void DeactivateHealth(Image image)
    {
        image.gameObject.SetActive(false);
    }
}