using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShape : MonoBehaviour
{
    public Material imageMaterial; // マテリアルに使う画像
    // Start is called before the first frame update
    void Start()
    {
        // キューブからスクエアにスケール変更
        ChangeToSquare();

        // 画像をオブジェクトに貼り付ける
        ApplyImage();
    }

    void ChangeToSquare()
    {
        // オブジェクトのスケールを変更してキューブからスクエアにする
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void ApplyImage()
    {
        // マテリアルが指定されている場合に画像をオブジェクトに適用
        if (imageMaterial != null)
        {
            // オブジェクトのRendererコンポーネントを取得
            Renderer objectRenderer = GetComponent<Renderer>();

            // マテリアルを設定
            objectRenderer.material = imageMaterial;
        }
    }
}
