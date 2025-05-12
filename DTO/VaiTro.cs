public class VaiTroItem
{

    public string Key { get; set; }

    public string DisplayText { get; set; }
    public string DbValue { get; set; }

    public override string ToString()
    {
        return DisplayText;
    }
}
