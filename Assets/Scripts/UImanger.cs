using UnityEngine;
using UnityEngine.UI;

public class UImanger : MonoBehaviour
{
    public Slider playerHealthbar;
    public Image PlayerImage;

    public GameObject enemyUI;
    public Slider enemyHealthBar;
    public Image enemyImage;

    //Objet o para armazenar estados do player
    private PlayerController Player;
    //Timers e controles do enemyUI
    public float enemyUITimer = 4f;
    private float enemyTimer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Obtem os dados do player
        //
        Player = FindFirstObjectByType<PlayerController>();

        playerHealthbar.maxValue = Player.maxHealth;

        //Inicia a healthbar cheia
        playerHealthbar.value = playerHealthbar.maxValue;

        PlayerImage.sprite = Player.playerImage;
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer += Time.deltaTime;
        if(enemyUITimer >= enemyUITimer)
        {
            enemyUI.SetActive(false);

            enemyTimer = 0;
        }
    }
    public void updateplayerheatlh(int amount)
    {
        playerHealthbar.value = amount;
    }
    public void UpdateenemyUI(int maxHealth, int currentHealth, Sprite image)
    {

        //Atualiza os dados do inimigo de acordo com o inimigo atacado
        enemyHealthBar.maxValue = maxHealth;
        enemyHealthBar.value = currentHealth;
        enemyImage.sprite = image;

        //Zera o timer para começar a contar os 4 segundos
        enemyTimer = 0;
        //Habilida a enemyUI, deixando-a visível
        enemyUI.SetActive(true);

    }
}
