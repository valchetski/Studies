using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Django_Unchained.Bars;
using Django_Unchained.Entities;
using Django_Unchained.Entities.Bonuses;
using Django_Unchained.Levels;
using Microsoft.Xna.Framework;

namespace Django_Unchained.SaveAndLoad
{
    public class Saves : GameComponent
    {
        private const string fileName = "save.bin";
        private readonly ConvertTo convertTo;

        public Saves(Game game) : base(game)
        {
            convertTo = new ConvertTo(game);
        }

        #region Save
        public static void SaveAll(GameComponentCollection gameComponentCollection)
        {
            var savingObjects = new List<SavingObject>();
            foreach (var component in gameComponentCollection)
            {
                if (component.GetType() == typeof(Django))
                {
                    savingObjects.Add(ConvertTo.SavingObject((Django)component));
                }
                else if (component.GetType() == typeof(Enemy))
                {
                    savingObjects.Add(ConvertTo.SavingObject((Enemy)component));
                }
                else if (component.GetType() == typeof(HealthBonus))
                {
                    savingObjects.Add(ConvertTo.SavingObject((HealthBonus)component));
                }
                else if (component.GetType() == typeof(Platform))
                {
                    savingObjects.Add(ConvertTo.SavingObject((Platform)component));
                }
                else if (component.GetType() == typeof(Level))
                {
                    savingObjects.Add(ConvertTo.SavingObject((Level)component));
                }
                else if (component.GetType() == typeof(HealthBar))
                {
                    savingObjects.Add(ConvertTo.SavingObject((HealthBar)component));
                }
                else if (component.GetType() == typeof(BulletsBar))
                {
                    savingObjects.Add(ConvertTo.SavingObject((BulletsBar)component));
                }
            }
            Save(savingObjects);
        }

        private static void Save(List<SavingObject> savingObjects)
        {
            var formatter = new BinaryFormatter();
            using (Stream s = File.Create(fileName))
                formatter.Serialize(s, savingObjects);
        }
        #endregion

        #region Load

        public bool LoadSaves()
        {
            var loadedComponents = LoadAll();
            Game.Components.Clear();
            foreach (var loadedComponent in loadedComponents)
            {
                if (loadedComponent.type == typeof(Django))
                {
                    Game.Components.Add(convertTo.Django(loadedComponent));
                }
                else if (loadedComponent.type == typeof(Platform))
                {
                    Game.Components.Add(convertTo.Platform(loadedComponent));
                }
                else if (loadedComponent.type == typeof(HealthBar))
                {
                    Game.Components.Add(convertTo.HealthBar(loadedComponent));
                }
                else if (loadedComponent.type == typeof(BulletsBar))
                {
                    Game.Components.Add(convertTo.BulletsBar(loadedComponent));
                }
                else if (loadedComponent.type == typeof(HealthBonus))
                {
                    Game.Components.Add(convertTo.HealthBonus(loadedComponent));
                }
                else if (loadedComponent.type == typeof(Enemy))
                {
                    Game.Components.Add(convertTo.Enemy(loadedComponent));
                }
                else if (loadedComponent.type == typeof(Level))
                {
                    Game.Components.Add(convertTo.Level1(loadedComponent));
                }
            }
            return (loadedComponents.Count > 0);
        }

        public static void DeleteSaves()
        {
            File.Delete(fileName);
        }
        private static List<SavingObject> LoadAll()
        {
            var savingObjects = new List<SavingObject>();
            try
            {
                var formatter = new BinaryFormatter();
                using (Stream s = File.OpenRead(fileName))
                {
                    savingObjects = (List<SavingObject>)formatter.Deserialize(s);
                }
            }
            catch (SerializationException) { }
            catch (TypeLoadException) { }
            catch (FileNotFoundException) { }
            return savingObjects;
        }
        #endregion
    }
}
