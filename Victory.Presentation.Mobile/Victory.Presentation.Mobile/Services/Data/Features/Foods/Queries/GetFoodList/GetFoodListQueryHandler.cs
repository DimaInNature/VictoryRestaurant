namespace Victory.Presentation.Mobile.Services.Data.Features.Foods;

public class GetFoodListQueryHandler
    : IRequestHandler<GetFoodListQuery, List<Food>?>
{
    public async Task<List<Food>?> Handle(GetFoodListQuery requests, CancellationToken token)
    {
        List<Food> responseList = new();

        try
        {
            string jsonResponse = string.Empty;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUriString: "http://10.0.2.2:7059/Foods");

            webRequest.Timeout = 4000;

            webRequest.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())

            using (Stream stream = response.GetResponseStream())

            using (StreamReader reader = new(stream)) jsonResponse = reader.ReadToEnd();

            responseList = JsonConvert.DeserializeObject<List<Food>>(jsonResponse) ?? new();

            responseList.ForEach(x => x.ImagePath = x.ImagePath?
                .Replace(oldValue: "localhost", newValue: "10.0.2.2"));
        }
        catch
        {
#if DEBUG
            responseList = new()
            {
                new()
                {
                    Name = "Name#1",
                    CostInUSD = 10.99,
                    Description = "Description#1",
                    ImagePath = "IMG01"
                },
                new()
                {
                    Name = "Name#2",
                    CostInUSD = 12.99,
                    Description = "Description#2",
                    ImagePath = "IMG02"
                },
                new()
                {
                    Name = "Name#3",
                    CostInUSD = 5.99,
                    Description = "Description#3",
                    ImagePath = "IMG03"
                },
                new()
                {
                    Name = "Name#4",
                    CostInUSD = 3.99,
                    Description = "Description#4",
                    ImagePath = "IMG04"
                },
                new()
                {
                    Name = "Name#5",
                    CostInUSD = 100.99,
                    Description = "Description#5",
                    ImagePath = "IMG05"
                }
            };
#endif
        }

        return responseList;
    }
}