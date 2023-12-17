using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;
    public TextMeshProUGUI distanceText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトAとオブジェクトBの距離を計算
        float distance = Vector3.Distance(objectA.position, objectB.position);

        // テキストに距離を表示
        distanceText.text = Mathf.RoundToInt(distance).ToString();

    }
}
