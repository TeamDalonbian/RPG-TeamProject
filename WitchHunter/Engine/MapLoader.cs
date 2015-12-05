using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WitchHunter.Models;
using WitchHunter.Models.Characters.Heroes;
using WitchHunter.Models.MapTextures;

namespace WitchHunter.Engine
{
    public static class MapLoader
    {
        public static List<GameObject> LoadMap(SpriteBatch spriteBatch)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            string map = "../../../Maps/FirstMap.txt";

            try
            {
                using (StreamReader sr = new StreamReader(map))
                {
                    int positionX = 0;
                    int positionY = 0;

                    const int textureSize = 50;

                    string line = sr.ReadToEnd();

                    for (int i = 0; i < line.Length; i++)
                    {
                        char currentSymbol = line[i];
                        Rectangle rect;

                        switch (currentSymbol)
                        {
                            case 'P':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    textureSize,
                                    textureSize);

                                gameObjects.Add(new Player(GameEngine.playerText, rect));
                                break;
                            case 'T':
                                rect = new Rectangle(
                                    positionX - GameEngine.Offset,
                                    positionY - GameEngine.Offset,
                                    textureSize,
                                    textureSize);
                                gameObjects.Add(new Tree(GameEngine.treeText, rect));
                                break;
                            case '\n':
                                positionY += textureSize;
                                positionX = 0;
                                break;
                        }

                        rect = new Rectangle(
                                   positionX - GameEngine.Offset,
                                   positionY - GameEngine.Offset,
                                   textureSize,
                                   textureSize);

                        gameObjects.Add(new Grass(GameEngine.grasText, rect));
                        positionX += textureSize;
                    }
                }

                return gameObjects;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
