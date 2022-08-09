namespace DemoDay1
{
    public interface IManager
    {
        void addList(string code);
        void showList();
        void update(string code, string name, int mark);
        bool checkCode(string code);
        void detele(string code);
        void saveFile();
        void readFile();
        bool checkNull(string code);
    }
}