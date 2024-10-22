using System.Text.Json.Serialization;


namespace HelloWorld.Models
{

public class Computer
{
    public int computerId {get; set;}

    [JsonPropertyName("motherboard")]  //Chat böyle bir çözüm buldu ve işe yaradı
    public string MotherBoard {get; set;}

    public int? CpuCores{get; set;}

    public bool HasWiFi{get; set;}

    public bool HasLTE{get; set;}

    public DateTime? ReleaseDate{get; set;}

    public decimal Price{get; set;}

    public string VideoCard{get; set;}

    public Computer()
    {
        if(VideoCard == null)
        {
            VideoCard = "";
        }

        if(MotherBoard == null)
        {
            MotherBoard = "";
        }

        if(CpuCores == null)
        {
            CpuCores = 0;
        }
    }
}

}