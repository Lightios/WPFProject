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

    public void Serialize()
    {
        // var settings = new JsonSerializerSettings
        // {
        //     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        // };
        //
        // var json = JsonConvert.SerializeObject(_contentObjects[0], settings);
        // File.WriteAllText(@$"{Name}.json", json);
        foreach (var contentObject in _contentObjects)
        {
            contentObject.Serialize();
        }
    }
    
    public void Deserialize()
    {
        foreach (var contentObject in _contentObjects)
        {
            contentObject.Deserialize();
        }
        // var json = File.ReadAllText(@$"{Name}.json");
        // _contentObjects[0] = JsonConvert.DeserializeObject<LogoObject>(json);
    }
    
}