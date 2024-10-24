using System.Text.Json.Serialization;


namespace HelloWorld.Models
{

public class Computer
{
    [JsonPropertyName("computer_id")]
    public int computerId {get; set;}


    [JsonPropertyName("motherboard")]  //Chat böyle bir çözüm buldu ve işe yaradı
    public string MotherBoard {get; set;}


    [JsonPropertyName("cpu_cores")]
    public int? CpuCores{get; set;}


    [JsonPropertyName("has_wifi")]
    public bool HasWiFi{get; set;}


    [JsonPropertyName("has_lte")]
    public bool HasLTE{get; set;}


    [JsonPropertyName("release_date")]
    public DateTime? ReleaseDate{get; set;}


    [JsonPropertyName("price")]
    public decimal Price{get; set;}


    [JsonPropertyName("video_card")]
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