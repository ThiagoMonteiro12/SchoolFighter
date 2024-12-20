using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ao colidir, salva na variavel enemy, o inimigo que foi colidido
        EnemyMeleeController enemy = collision.GetComponent<EnemyMeleeController>();

        //Ao colidir salva na bariavel player que o player foi atingido
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            player.takeDamage(damage);
        }
        // Se a colis�o foi com um inimigo
        if (enemy != null)
        {
            // Inimigo recebe dano
            enemy.TakeDamage(damage);
        }
    }

}
