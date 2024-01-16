using System.Collections.ObjectModel;
using WPFProject.Interfaces;

namespace WPFProject.Models;

public class DoorTag
{ 
    public string Name;
    Collection<IContentObject> ContentObjects;
}