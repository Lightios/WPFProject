namespace WPFProject.Interfaces;

public interface IContentObject
{
    string Serialize();
    void Deserialize(string json);

    void SetPosition(int x, int y);
    
    void SetSize(int x, int y);
}