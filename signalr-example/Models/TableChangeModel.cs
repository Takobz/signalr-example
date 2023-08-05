public class TableChangeModel
{
    public string TableName { get; set; } = string.Empty;
    public int ItemId { get; set; }
}

public class PersonChangeModel 
{
    public int PersonId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string ChangeReason { get; set; } = string.Empty;
}