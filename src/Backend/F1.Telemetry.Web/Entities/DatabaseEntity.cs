using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace F1.Telemetry.Web.Entities;

public class DatabaseEntity<T> where T : struct
{
    [Column("id")]
    public long Id { get; set; }

    [Column("data")]
    public DateTime Data { get; set; }
    
    [Column("conteudo")]
    [JsonIgnore]
    public string Conteudo { get; set; }
    
    [Column("sessiontimestamp")]
    public float SessionTimestamp { get; set; }
    
    [Column("sessionid")]
    public string SessionId { get; set; }
    
    public T ReadAsStruct()
    {
        return JsonConvert.DeserializeObject<T>(Conteudo);
    }
    
    private T? _dados;
    
    [NotMapped]
    public T Dados
    {
        get
        {
            _dados ??= ReadAsStruct();
            return (T)_dados;
        }
    }
}