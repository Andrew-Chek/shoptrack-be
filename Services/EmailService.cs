using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class EmailService
{
    private readonly HttpClient _httpClient;

    public EmailService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> SendEmailAsync(string senderEmail, string recipientEmail, string subject, string body)
    {
        // Construct the HTTP request
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sendpulse.com/smtp/emails");
        request.Headers.Add("Authorization", "Bearer 8a88c298f7d79b91fb5e69a0b828b02b");

        var requestBody = new
        {
            html = body,
            subject,
            from = new
            {
                email = senderEmail
            },
            to = new[]
            {
                new { email = recipientEmail }
            }
        };

        request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

        // Send the request and handle the response
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Email sent successfully.");
            return true;
        }
        else
        {
            Console.WriteLine($"Failed to send email. Status code: {response.StatusCode}");
            return false;
        }
    }
    public string GenerateResetCode(int length)
    {
        const string chars = "0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}

