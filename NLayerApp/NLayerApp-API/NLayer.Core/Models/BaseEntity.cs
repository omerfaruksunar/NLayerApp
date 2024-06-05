namespace NLayer.Core.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

//Abstractlar newlenmeyecegi icin bu yazim oop'ye daha uygun.