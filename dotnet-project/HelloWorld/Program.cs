// See https://aka.ms/new-console-template for more information

using System;
using System.Data;
using System.Text.Json;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
// using System.Text.Json;  .Net 6 için gerekli ama galiba artık değil..!

namespace HelloWorld
{

internal class Program
{
    
    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        DataContextDapper dapper = new DataContextDapper(config);


        //Console.WriteLine(rightNow);

        // Computer myComputer = new Computer()
        // {
        //     MotherBoard = "Z690",
        //     HasWiFi = true,
        //     HasLTE = true,
        //     ReleaseDate = DateTime.Now,
        //     Price = 14.055m,
        //     VideoCard = "RTX 2060"

        // };


        //File.WriteAllText("log.txt","\n" + sql + "\n");  //dosyayı açar ve bir kere yazar üzerine yazılmaz..!
        // using StreamWriter openFile = new ("log.txt", append: true );
        // openFile.WriteLine("\n" + sql + "\n");
        // openFile.Close();  // Yazma işlemi bittikten sonra kapatmazsak okumaz.

        string compJson = File.ReadAllText("Computers.json");
        //Console.WriteLine(compJson);

        JsonSerializerOptions options = new JsonSerializerOptions() // --> newtonsoft eklenmeden onceki hali
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Json dosyasıyla kodumuzdaki isimlendirmeyi eşleştirir. 
        };

        IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(compJson, options);
        IEnumerable<Computer>?  computersNewtonsft= JsonConvert.DeserializeObject<IEnumerable<Computer>>(compJson);  //Newtonjson paketi kullanıldı


        if(computersNewtonsft != null)
        {
            foreach(Computer computer in computersNewtonsft)
            {
                DateTime releaseDate = Convert.ToDateTime(computer.ReleaseDate);

                //@ birden fazla satıra erişime izin verir
                string sql = @"INSERT INTO TutorialAppSchema.Computer(   
                MotherBoard , 
                HasWiFi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
                )
                VALUES('"+ escapeSingleQuote(computer.MotherBoard)
                + "'," + (computer.HasWiFi ? 1 : 0)  // Boolean için 1 veya 0 kullanılır
                + "," + (computer.HasLTE ? 1 : 0)
                + ",'" + releaseDate.ToString("yyyy-MM-dd")
  
                + "'," + computer.Price.ToString(System.Globalization.CultureInfo.InvariantCulture)  // Ondalık sayılar
                + ",'" + escapeSingleQuote(computer.VideoCard)
                + "')";

                dapper.ExecuteSql(sql);
                }
        }

        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        string computersCopyNewtonsoft = JsonConvert.SerializeObject(compJson, settings);  //--> Database yazma işlemi serialize oluyor ve Ns isimleri kodumuzda olduğu gibi saklar
        File.WriteAllText("computersCopyNewtonsoft.txt",computersCopyNewtonsoft);


        string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(compJson, options);  //--> Newtonsoft kullanmadan seerialize oluyor.
        File.WriteAllText("computersCopySystem.txt",computersCopySystem);
    }

    static string escapeSingleQuote(string input)
    {
        string output = input.Replace("'","''");  //güzel bi metod, ' yerine '' koyarak hatadan kaçındık
        return output;
    }
}
}



    