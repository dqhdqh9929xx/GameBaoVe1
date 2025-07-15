using UnityEngine;
using UnityEngine.UI;

public class DrawOnCanvas : MonoBehaviour
{
    public RawImage rawImage;
    public Color drawColor = Color.black;
    public int brushSize = 5;

    private Texture2D drawTexture;

    void Start()
    {
        Texture2D originalTex = rawImage.texture as Texture2D;

        if (originalTex == null)
        {
            Debug.LogError("RawImage chưa được gán Texture2D!");
            enabled = false;
            return;
        }

        drawTexture = new Texture2D(originalTex.width, originalTex.height, TextureFormat.RGBA32, false);
        drawTexture.SetPixels(originalTex.GetPixels());
        drawTexture.Apply();
        rawImage.texture = drawTexture;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 localPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rawImage.rectTransform,
                Input.mousePosition,
                null,
                out localPos
            );

            Rect rect = rawImage.rectTransform.rect;
            float px = (localPos.x - rect.x) / rect.width;
            float py = (localPos.y - rect.y) / rect.height;

            int texX = Mathf.FloorToInt(px * drawTexture.width);
            int texY = Mathf.FloorToInt(py * drawTexture.height);

            DrawAtPosition(texX, texY);
        }
    }


    void DrawAtPosition(int centerX, int centerY)
    {
        int halfBrush = brushSize / 2;

        for (int dx = -halfBrush; dx <= halfBrush; dx++)
        {
            for (int dy = -halfBrush; dy <= halfBrush; dy++)
            {
                int x = centerX + dx;
                int y = centerY + dy;

                if (x >= 0 && x < drawTexture.width && y >= 0 && y < drawTexture.height)
                {
                    drawTexture.SetPixel(x, y, drawColor);
                }
            }
        }

        drawTexture.Apply();
    }
}
