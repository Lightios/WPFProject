using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFProject.Interfaces;
using Newtonsoft.Json;
using System.IO;
using WPFProject.Controls;

namespace WPFProject.Models;

public class DoorTag
{ 
    public string Name;
    Collection<IContentObject> _contentObjects;
    
    public DoorTag()
    {
        _contentObjects = new Collection<IContentObject>();
        Name = "Default DoorTag";
    }
    
    public void AddContentObject(IContentObject contentObject)
    {
        _contentObjects.Add(contentObject);
    }

    public void Serialize(string path)
    {
       List<string> jsonList = new List<string>();
       foreach (var contentObject in _contentObjects)
       {
           jsonList.Add(contentObject.Serialize());
       }
       var json = JsonConvert.SerializeObject(jsonList);
       File.WriteAllText(path, json);
    }
    
    public void Deserialize(string path)
    {
        var json = File.ReadAllText(path);
        var jsonList = JsonConvert.DeserializeObject<List<string>>(json);
        
        for (int i = 0; i < jsonList.Count; i++)
        {
            var contentObject = _contentObjects[i];
            contentObject.Deserialize(jsonList[i]);
        }
    }
    
}