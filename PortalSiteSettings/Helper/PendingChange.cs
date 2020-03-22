using Microsoft.Xrm.Sdk;
/// <summary>
/// Helper class to report back which values have changed
/// </summary>
public class PendingChange
{
    public string Action { get; set; }
    public Entity Entity { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public string ValidationMessage { get; set; } = "";
    public bool IsRequired { get; set; } = false;
}