using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   public GameObject[] enemyArray;

    public int numberOfEnemies;
    public int currentEnemies;

    public float spawnTime;

    public string nextSection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void spawnEnemy()
    {
        //posição de spawn do inimigo
        Vector2 spawnPosition;

        //Limites Y
        //-0.35
        //Limite X
        //-0.95
         
        spawnPosition.y = Random.Range(-0.95f, -0.35f);

        //POsição X maximo (direita) do confiner da camera +1 de distancia
        /*
         Pegar RightBound (Limite direito) da Section (Confiner) como base

         */
        float rightSectionBound = LevelManager.currentConfiner.BoundingShape2D.bounds.max.x;
        spawnPosition.x = rightSectionBound;

        Instantiate(enemyArray[Random.Range(0,enemyArray.Length)], spawnPosition, Quaternion.identity).SetActive(true);

        currentEnemies++;

        if(currentEnemies < numberOfEnemies)
        {
            Invoke("SpawnEnemey", spawnTime);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player =  collision.GetComponent<PlayerController>();

        if(player != null)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;

            spawnEnemy();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentEnemies >=  numberOfEnemies)
        {
            //Contar a quantidade de inimigos ativos na cena
            int enemies = FindObjectsByType<EnemyMeleeController>(FindObjectsSortMode.None).Length;
            if(enemies <= 0)
            {
                //Avança de sessão
                LevelManager.changeSection(nextSection);

                //Desabilita o spawner
                this.gameObject.SetActive(false);
            }
        }
    }
}
