using JetBrains.Annotations;
using Unity.Cinemachine;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static CinemachineConfiner2D currentConfiner;

    private CinemachineBrain brain;
    private CinemachineCamera cam;

    static BoxCollider2D currentSection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        brain = CinemachineBrain.GetActiveBrain(0);
        currentConfiner = GameObject.Find("CM").GetComponent<CinemachineConfiner2D>();
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void changeSection(string sectionName)
    {
        currentSection = GameObject.Find(sectionName).GetComponent<BoxCollider2D>();
        
        if(currentSection)
        {   //Faz com que a camera limpe o cache do confiner anterior, esquecer o confiner anterior
            currentConfiner.InvalidateBoundingShapeCache();
            //Define o novo confiner da camera
            currentConfiner.BoundingShape2D = currentSection;
            //Reposicionar o right limiter, alinhado max x do confine (Direita do confiner)
            GameObject rightLimiter = GameObject.Find("Right");

            rightLimiter.transform.position = new Vector3(currentConfiner.BoundingShape2D.bounds.max.x, rightLimiter.transform.position.y);





        }
    }
}
