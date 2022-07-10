using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Weapons.Map
{
    public class MapGenerator : MonoBehaviour
    {
        public Texture2D imageToLoad;
        public List<Color> colorPalette;
        public List<Tile> tilePalette;
        public Tilemap tilemap;
        private void Start()
        {
            for (int x = 0; x < imageToLoad.width; x++)
            {
                for (int y = 0; y < imageToLoad.height; y++)
                {
                    var pixel = imageToLoad.GetPixel(x, y);
                    var index = colorPalette.FindIndex(color => pixel==color );
                    var tile = tilePalette[index];
                    tilemap.SetTile(new Vector3Int(x,y,0),tile);
                }
            }
        }

        [ContextMenu("FillColorPalette")]
        public void FillColorPalette()
        {
            if (imageToLoad == null)
            {
                Debug.LogError("image not loaded");
                return;
            }

            colorPalette.Clear();
            for (int x = 0; x < imageToLoad.width; x++)
            {
                for (int y = 0; y < imageToLoad.height; y++)
                {
                    var pixel = imageToLoad.GetPixel(x, y);
                    if (!colorPalette.Contains(pixel))
                    {
                        colorPalette.Add(pixel);
                    }
                }
            }
        }
    }
}