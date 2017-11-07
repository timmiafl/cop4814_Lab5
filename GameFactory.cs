using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Game
{
    public class GameFactory
    {
        StreamWriter sw;
        StreamReader sr;
        XmlSerializer serial;
        List<GameT> gameList;
        
        public void CreateGameList()
        {
            gameList = new List<GameT>();
            GameT G = new GameT("Golden State Warriors", "Boston Cetics", 95, 4);
            gameList.Add(G);
            G = new GameT("CleveLand Cavaliers", "Los Angeles Lakers", 45, 60);
            gameList.Add(G);
            G = new GameT("Charlotte Hornets", "Miami Heat", 79, 81);
            gameList.Add(G);
            G = new GameT("New Orlean Pelicans", "New York Knicks", 75, 76);
            gameList.Add(G);
            G = new GameT("Chicago Bull", "Brooklyn Nets", 100, 90);
            gameList.Add(G);
            G = new GameT("Indiana Pacers", "Atlanta Hawks", 75, 64);
            gameList.Add(G);

        }

        public void FilePath()
        {
            const string GAME_FILENAME = @"..\..\game.xml";

            sw = new StreamWriter(GAME_FILENAME);
      
        }

        public Boolean SerializeGameList(out string resultMessage)
        {
            try
            {
                FilePath();
                serial = new XmlSerializer(gameList.GetType());
                serial.Serialize(sw, gameList);
                sw.Close();
                resultMessage = "XML file done";
                return true;
            }
            catch
            {
                resultMessage = "XML Seriazlizer missing. Did you click Call before Write?";
                return false;
            }
        
        }

        public List<GameT> DeserializeGameList(out string resultMessage)
        {
            
            try
            {
                sr = new StreamReader(@"..\..\game.xml");
                gameList = new List<GameT>();
                serial = new XmlSerializer(gameList.GetType());
                gameList = (List<GameT>)serial.Deserialize(sr);
                sr.Close();
                resultMessage = "Found and Read Data";
                return gameList;
            }
            catch (Exception ex)
            {
                resultMessage = "Expection thrown:" + ex.Message;
                return null;
            }

        }

    }
    }
