namespace Units {
    /// <summary>
    /// Classes extending this interface can take damage
    /// </summary>
    public interface IDamagable {
        void TakeDamage(int damage);
        void GainHealth(int healValue);
    }
}
