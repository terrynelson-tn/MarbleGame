//Module 8 Midterm Project --- IDataPersistence.cs by Sebastian Ulloa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IDataPersistence 
{
    void LoadData(GameData data);

    void SaveData(GameData data);
}
