using UnityEngine;

public class BasicHitbox : MonoBehaviour
{
    public int LifeSec;
    public int Damage;
    public string Effect = "Knockback";
    public int Knockback;
    public bool DeactivateOnImpact;
    public GameObject Parent;
    private float _lifeTimer;

    private void OnEnable() {
        _lifeTimer = LifeSec;
    }
    
    private void Update() {
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer <= 0.0f) gameObject.SetActive(false);
    }
    
    public void HasCollided() {
        if (DeactivateOnImpact) gameObject.SetActive(false);
    }
}
