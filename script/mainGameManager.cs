using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject spawnedBullet; // 生成されたbullet
    private Vector3 mousePos;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            // 既に生成されたbulletがあれば削除
            if (spawnedBullet != null)
            {
                Destroy(spawnedBullet);
            }
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            //ボールを生成
            spawnedBullet = Instantiate(bulletPrefab, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
            // 子オブジェクトに画像を適用
            ApplyImageToChild(spawnedBullet);
        }
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            spawnedBullet.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        }
        if (Input.GetMouseButtonUp(0))//もしマウスが押されたら（0は左1は右）
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;

        }
    }
        void ApplyImageToChild(GameObject parentObject)
        {
        // 親オブジェクトがnullでないことを確認
        if (parentObject != null)
            {
                // レンダラーコンポーネントがアタッチされているか確認
                Renderer parentRenderer = parentObject.GetComponent<Renderer>();
                if (parentRenderer != null)
                {
                    // 親のレンダラーコンポーネントに画像を適用
                    parentRenderer.material = GetImageMaterial(); // GetImageMaterial()は画像のマテリアルを返すメソッドとして実装してください
                }
            }
        }
    Material GetImageMaterial()
        {
            // ここに画像のマテリアルを取得する処理を実装
            // 例えば、Resources.Loadなどを使用してマテリアルを読み込む
            // この例ではResourcesフォルダにマテリアルを配置していると仮定
            Material imageMaterial = Resources.Load<Material>("image/hiepita");


        return imageMaterial;
    }
}
