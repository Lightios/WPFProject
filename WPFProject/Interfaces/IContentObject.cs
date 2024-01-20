namespace WPFProject.Interfaces;

public interface IContentObject
{
    void Serialize();
    void Deserialize();
    void SetPosition(int x, int y);
    void SetSize(int x, int y);
}