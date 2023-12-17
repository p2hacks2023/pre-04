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
        // �I�u�W�F�N�gA�ƃI�u�W�F�N�gB�̋������v�Z
        float distance = Vector3.Distance(objectA.position, objectB.position);

        // �e�L�X�g�ɋ�����\��
        distanceText.text = Mathf.RoundToInt(distance).ToString();

    }
}
