namespace EatDomicile.Web.ViewModels.Toast;

public enum ToastType
{
    Success,
    Error,
    Info,
    Warning,
}

public class ToastViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public ToastType Type { get; set; } = ToastType.Info;
    
    public string Classes => Type switch
    {
        ToastType.Success => "bg-success text-white",
        ToastType.Error => "bg-danger text-white",
        ToastType.Info => "bg-info text-white",
        ToastType.Warning => "bg-warning text-dark",
        _ => "bg-secondary text-white"
    };
}