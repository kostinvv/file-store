namespace FileStore.Server.Models;

/// <summary>
/// Представляет модель данных для описания информации об объектах, которые содержаться в S3 хранилище.
/// </summary>
public class StorageObject
{
    /// <summary> Идентификатор объекта. </summary>
    public Guid Id { get; init; }
    
    /// <summary> Наименование объекта. </summary>
    public string Name { get; init; }
    
    /// <summary> Ключ объекта в хранилище. </summary>
    public string Key { get; init; } 
    
    /// <summary> Размер объекта. </summary>
    public string Size { get; init; }
    
    /// <summary> Дата и время создание объекта. </summary>
    public DateTime CreatedAt { get; init; }
    
    /// <summary> Тип файла. </summary>
    public string FileType { get; init; }
    
    /// <summary> Флаг обозначает является объект директорией или файлом. </summary>
    public bool IsDirectory { get; init; }
    
    /// <summary> Идентификатор пользователя, которому принадлежит объект. </summary>
    public Guid UserId { get; init; }
}